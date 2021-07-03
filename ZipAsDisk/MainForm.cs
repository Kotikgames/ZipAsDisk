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
using Ionic.Zip;
using Microsoft.VisualBasic.FileIO;
using DiscUtils.Ntfs;
using System.Management.Automation;
using DiscUtils.Iso9660;
using System.Diagnostics;

namespace ZipAsDisk
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void MakeISO(string archivePath, string vhdPath)
        {
            CDBuilder builder = new CDBuilder();
            builder.UseJoliet = true;
            builder.VolumeIdentifier = "Архив";
            using(ZipFile zip = ZipFile.Read(archivePath))
            {
                zip.ExtractAll("extract\\");
            }
            List<Stream> streams = new List<Stream>();
            foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
            {
                Stream s = File.OpenRead(f);
                streams.Add(s);
                builder.AddFile(Path.GetFileName(f), s);
            }
            builder.Build(vhdPath);
            foreach(Stream s in streams)
                s.Close();
        }

        public void MakeVHD(string archivePath, string vhdPath)
        {
            using(ZipFile zip = ZipFile.Read(archivePath))
            {
                zip.ExtractAll("extract\\");
            }
            long filesSize = 0;
            // problem in filesSize
            foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
                using(FileStream fs = File.OpenRead(f))
                    filesSize += fs.Length; 
            long diskSize =  30 * 1024 * 1024; // ?
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
                        MessageBox.Show(dir);
                        if(dir != string.Empty)
                        {
                            destNtfs.CreateDirectory(dir);
                        }
                        using(Stream s = File.OpenRead(f))
                        {
                            using(Stream stream = destNtfs.OpenFile(dir + "\\" + Path.GetFileName(f), FileMode.Create))
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
            statusLabel.Text = "Монтирование...";
            Mount(AppDomain.CurrentDomain.BaseDirectory + "output.vhd");
            statusLabel.Text = "Готово";
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
    }
}
