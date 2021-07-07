using DiscUtils.Partitions;
using DiscUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscUtils.Vhd;
using DiscUtils.Fat;
using Microsoft.VisualBasic.FileIO;
using DiscUtils.Ntfs;
using System.Management.Automation;
using DiscUtils.Iso9660;
using System.Diagnostics;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;

namespace ZipAsDisk
{
    public partial class MainForm : Form
    {
        private string archivePath;
        public MainForm()
        {
            InitializeComponent();
            ZipStrings.UseUnicode = true;
        }


        public void MakeISO(string archivePath, string vhdPath)
        {
            CDBuilder builder = new CDBuilder();
            builder.UseJoliet = true;
            builder.VolumeIdentifier = "Архив";
            FastZip zip = new FastZip();
            zip.ExtractZip(archivePath, "extract\\", null);
            List<Stream> streams = new List<Stream>();
            foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
            {
                string dir = Path.GetDirectoryName(f);
                dir = dir.Replace("extract", "");
                if(dir != string.Empty)
                {
                    builder.AddDirectory(dir);
                }
                Stream s = File.OpenRead(f);
                streams.Add(s);
                builder.AddFile(dir + '\\' + Path.GetFileName(f), s);
            }
            builder.Build(vhdPath);
            foreach(Stream s in streams)
                s.Close();
        }

        public void MakeVHD(string archivePath, string vhdPath)
        {
            FastZip zip = new FastZip();
            zip.ExtractZip(archivePath, "extract\\", null);
            long filesSize = 0;
            // problem in filesSize
            foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
                using(FileStream fs = File.OpenRead(f))
                    filesSize += fs.Length; 
            long diskSize =  60 * 1024 * 1024; // ?
            //MessageBox.Show((diskSize / 1024).ToString());
            using(var fs = new FileStream(vhdPath, FileMode.OpenOrCreate))
            {
                VirtualDisk destDisk = Disk.InitializeDynamic(fs, DiscUtils.Streams.Ownership.None, diskSize);

                BiosPartitionTable.Initialize(destDisk, WellKnownPartitionType.WindowsNtfs);
                var volMgr = new VolumeManager(destDisk);

                var label = $"Архив " + Path.GetFileNameWithoutExtension(archivePath);

                using(var destNtfs = NtfsFileSystem.Format(volMgr.GetLogicalVolumes()[0], label, new NtfsFormatOptions()))
                {
                    //MessageBox.Show((destNtfs.UsedSpace / 1024).ToString());
                    destNtfs.NtfsOptions.ShortNameCreation = ShortFileNameOption.Disabled;

                    foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
                    {
                        string dir = Path.GetDirectoryName(f);
                        dir = dir.Replace("extract", "");
                        if(dir != string.Empty)
                        {
                            destNtfs.CreateDirectory(dir);
                        }
                        using(Stream s = File.OpenRead(f))
                        {
                            using(Stream stream = destNtfs.OpenFile(dir + '\\' + Path.GetFileName(f), FileMode.Create))
                            {
                                try
                                {
                                    statusLabel.Text = "Добавление: " + Path.GetFileName(f);
                                    s.CopyTo(stream);
                                    stream.Flush();
                                }catch(IOException e)
                                {
                                    MessageBox.Show(e.Message);
                                    MessageBox.Show((destNtfs.AvailableSpace / 1024).ToString());
                                }
                            }
                        }
                    }
                }
                fs.Flush();
            }
            FileSystem.DeleteDirectory("extract/", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
        }

        public void Mount(string path, bool isIso = false)
        {
            using(var ps = PowerShell.Create())
            {
                var command = ps.AddCommand("Mount-DiskImage");
                command.AddParameter("ImagePath", path);
                command.AddParameter("PassThru");
                if(!isIso)
                    command.AddCommand("Get-Disk").AddCommand("Get-Partition");
                command.AddCommand("Get-Volume");
                var result = command.Invoke();
                // Get Drive Letter 
                string letter = result[0].Properties["DriveLetter"].Value.ToString();
                if(openInExplorerCheckBox.Checked)
                    Process.Start("explorer", letter + ":\\");
                if(!isIso)
                    diskArchiveChangeWatcher.Path = letter + ":\\";
                //MessageBox.Show(command.Streams.Error.ReadAll()[0].ToString());
            }
        }
        public void Dismount(string vhdPath)
        {
            using(var ps = PowerShell.Create())
            {
                var command = ps.AddCommand("Dismount-DiskImage");
                command.AddParameter("ImagePath", vhdPath);
                command.Invoke();
                //MessageBox.Show(command.Streams.Error.ReadAll()[0].ToString());
            }
        }

        private void openArchive_FileOk(object sender, CancelEventArgs e)
        {
            statusLabel.Text = "Размонтирование диска...";
            Dismount(AppDomain.CurrentDomain.BaseDirectory + "output.vhd");
            statusLabel.Text = "Создание VHD";
            MakeVHD(openArchive.FileName, "output.vhd");
            archivePath = openArchive.FileName;
            statusLabel.Text = "Монтирование...";
            Mount(AppDomain.CurrentDomain.BaseDirectory + "output.vhd");
            statusLabel.Text = "Готово";
            diskArchiveChangeWatcher.EnableRaisingEvents = true;
        }

        private void openArchiveButton_Click(object sender, EventArgs e)
        {
            openArchive.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusLabel.Text = "Размонтирование дисков...";
            Dismount(AppDomain.CurrentDomain.BaseDirectory + "output.vhd");
            Dismount(AppDomain.CurrentDomain.BaseDirectory + "output.iso");
        }

        private void openArchiveAsIso_FileOk(object sender, CancelEventArgs e)
        {
            statusLabel.Text = "Размонтирование диска...";
            Dismount(AppDomain.CurrentDomain.BaseDirectory + "output.iso");
            statusLabel.Text = "Создание ISO";
            MakeISO(openArchiveAsIso.FileName, "output.iso");
            FileSystem.DeleteDirectory("extract/", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
            statusLabel.Text = "Монтирование...";
            Mount(AppDomain.CurrentDomain.BaseDirectory + "output.iso", true);
            statusLabel.Text = "Готово";
        }

        private void openArchiveAsIsoButton_Click(object sender, EventArgs e)
        {
            openArchiveAsIso.ShowDialog();
        }

        private void applyChanges(object sender, FileSystemEventArgs e)
        {
            statusLabel.Text = "Применение изменений...";
            using(ZipFile zip = new ZipFile(archivePath))
            {
                zip.BeginUpdate();
                try
                {
                    if(e.ChangeType == WatcherChangeTypes.Created)
                    {
                        FileAttributes attr = FileAttributes.Normal;
                        try
                        {
                            attr = File.GetAttributes(e.FullPath);
                            if(attr.HasFlag(FileAttributes.Directory))
                                zip.AddDirectory(e.FullPath);
                            else
                                zip.Add(e.FullPath);
                        }
                        catch(UnauthorizedAccessException) { }
                    }
                    if(e.ChangeType == WatcherChangeTypes.Renamed)
                    {
                        RenamedEventArgs renamedEvent = (RenamedEventArgs)e;
                        FileAttributes attr = FileAttributes.Normal;
                        try
                        {
                            attr = File.GetAttributes(renamedEvent.FullPath);
                        }
                        catch(Exception) { }
                        /*if(attr.HasFlag(FileAttributes.Directory))
                            zip.UpdateDirectory(renamedEvent.FullPath).FileName = renamedEvent.Name;
                        else
                            zip.UpdateFile(renamedEvent.OldFullPath).FileName = renamedEvent.Name;*/
                    }
                    if(e.ChangeType == WatcherChangeTypes.Deleted)
                    {
                        zip.Delete(zip.GetEntry(e.FullPath.Remove(0, 3).Replace('\\', '/')));
                    }
                }
                catch(ArgumentException)
                {

                }
                try
                {
                    zip.CommitUpdate();
                }
                catch(IOException ex)
                {
                    MessageBox.Show("Ошибка при сохранении архива: " + ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = "Ошибка сохранения";
                }
            }
            statusLabel.Text = "Готово";
        }


        private void diskArchiveChangeWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            applyChanges(sender, e);
        }
    }
}
