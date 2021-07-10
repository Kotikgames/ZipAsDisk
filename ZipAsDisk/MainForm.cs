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
            Settings.LoadSettings();
        }

        public string GetExtractPath()
        {
            return Settings.settings.ExtractPath == "Temp" ? Path.GetTempPath() + "zipasdisk_extract" : Settings.settings.ExtractPath;
        }

        public string GetDiskImagesPath()
        {
            if(Settings.settings.DiskImagesPath == "Temp")
            {
                Directory.CreateDirectory(Path.GetTempPath() + "zipasdisk_disks");
                return Path.GetTempPath() + "zipasdisk_disks";
            }
            return Settings.settings.DiskImagesPath;
        }

        public void RemoveDiskImages()
        {
            statusLabel.Text = "Удаление образов дисков...";
            string path = GetDiskImagesPath();
            if(File.Exists(path + "\\output.vhd"))
                FileSystem.DeleteFile(path + "\\output.vhd", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
            if(File.Exists(path + "\\output.iso"))
                FileSystem.DeleteFile(path + "\\output.iso", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently, UICancelOption.DoNothing);
            statusLabel.Text = "Готово";
        }


        public void MakeISO(string archivePath, string isoPath)
        {
            CDBuilder builder = new CDBuilder();
            builder.UseJoliet = true;
            builder.VolumeIdentifier = "Архив";
            FastZip zip = new FastZip();
            zip.ExtractZip(archivePath, GetExtractPath(), null);
            List<Stream> streams = new List<Stream>();
            if(!Directory.Exists(Path.GetDirectoryName(isoPath)))
            {
                MessageBox.Show("Не удалось найти путь: " + Path.GetDirectoryName(isoPath), "Ошибка создания ISO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ошибка создания";
                return;
            }
            foreach(string f in Directory.GetFiles(GetExtractPath(), "*.*", System.IO.SearchOption.AllDirectories))
            {
                string dir = Path.GetDirectoryName(f);
                dir = dir.Replace(GetExtractPath(), "");
                if(dir != string.Empty)
                {
                    builder.AddDirectory(dir);
                }
                Stream s = File.OpenRead(f);
                streams.Add(s);
                builder.AddFile(dir + '\\' + Path.GetFileName(f), s);
            }
            builder.Build(isoPath);
            foreach(Stream s in streams)
                s.Close();
        }

        public void MakeVHD(string archivePath, string vhdPath)
        {
            FastZip zip = new FastZip();
            zip.ExtractZip(archivePath, GetExtractPath(), null);
            long filesSize = 0;
            // problem in filesSize
            /*foreach(string f in Directory.GetFiles(GetExtractPath(), "*.*", System.IO.SearchOption.AllDirectories))
                using(FileStream fs = File.OpenRead(f))
                    filesSize += fs.Length; */
            long diskSize =  125 * 1024 * 1024; // ?
                                                //MessageBox.Show((diskSize / 1024).ToString());
            if(!Directory.Exists(Path.GetDirectoryName(vhdPath))){
                MessageBox.Show("Не удалось найти путь: " + Path.GetDirectoryName(vhdPath), "Ошибка создания VHD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ошибка создания";
                return;
            }
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

                    foreach(string f in Directory.GetFiles(GetExtractPath(), "*.*", System.IO.SearchOption.AllDirectories))
                    {
                        string dir = Path.GetDirectoryName(f);
                        dir = dir.Replace(GetExtractPath(), "");
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
            FileSystem.DeleteDirectory(GetExtractPath(), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
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
                if(Settings.settings.OpenInExplorer)
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
            Dismount(GetDiskImagesPath() + "\\output.vhd");
            statusLabel.Text = "Создание VHD";
            MakeVHD(openArchive.FileName, GetDiskImagesPath() + "\\output.vhd");
            archivePath = openArchive.FileName;
            statusLabel.Text = "Монтирование...";
            Mount(GetDiskImagesPath() + "\\output.vhd");
            statusLabel.Text = "Готово";
            diskArchiveChangeWatcher.EnableRaisingEvents = Settings.settings.EditArchiveInRealTime;
        }

        private void openArchiveButton_Click(object sender, EventArgs e)
        {
            openArchive.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            statusLabel.Text = "Размонтирование дисков...";
            Dismount(GetDiskImagesPath() + "\\output.vhd");
            Dismount(GetDiskImagesPath() + "\\output.iso");
            RemoveDiskImages();
        }

        private void openArchiveAsIso_FileOk(object sender, CancelEventArgs e)
        {
            statusLabel.Text = "Размонтирование диска...";
            Dismount(GetDiskImagesPath() + "\\output.iso");
            statusLabel.Text = "Создание ISO";
            MakeISO(openArchiveAsIso.FileName, GetDiskImagesPath() + "\\output.iso");
            FileSystem.DeleteDirectory(GetExtractPath(), UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
            statusLabel.Text = "Монтирование...";
            Mount(GetDiskImagesPath() + "\\output.iso", true);
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
                        ZipEntry entry = zip.GetEntry(renamedEvent.OldFullPath.Remove(0, 3).Replace('\\', '/'));
                        zip.Add(e.FullPath);
                        zip.Delete(entry);
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
                catch(Exception ex) when (ex is UnauthorizedAccessException || ex is IOException)
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

        private void settingsToolStripItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
        }
    }
}
