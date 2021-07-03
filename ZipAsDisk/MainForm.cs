﻿using DiscUtils.Partitions;
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
            foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
            {

                Stream s = File.OpenRead(f);
                builder.AddFile(Path.GetFileName(f), s);
            }
            builder.Build(vhdPath);
        }

        public void MakeVHD(string archivePath, string vhdPath)
        {
            using(ZipFile zip = ZipFile.Read(archivePath))
            {
                zip.ExtractAll("extract\\");
            }
            long zipSize = 0;
            using(FileStream fs = File.OpenRead(archivePath)) {
                zipSize = fs.Length;
            }
            long diskSize = zipSize * 1024 * 1024 + 1024; // ?
            using(var fs = new FileStream(vhdPath, FileMode.OpenOrCreate))
            {
                VirtualDisk destDisk = Disk.InitializeDynamic(fs, DiscUtils.Streams.Ownership.None, diskSize);


                BiosPartitionTable.Initialize(destDisk, WellKnownPartitionType.WindowsNtfs);
                var volMgr = new VolumeManager(destDisk);

                var label = $"Архив " + Path.GetFileNameWithoutExtension(archivePath);

                using(var destNtfs = NtfsFileSystem.Format(volMgr.GetLogicalVolumes()[0], label, new NtfsFormatOptions()))
                {
                    destNtfs.NtfsOptions.ShortNameCreation = ShortFileNameOption.Disabled;

                    foreach(string f in Directory.GetFiles("extract", "*.*", System.IO.SearchOption.AllDirectories))
                    {

                        using(Stream s = File.OpenRead(f))
                        {
                            using(Stream stream = destNtfs.OpenFile(Path.GetFileName(f), FileMode.Create))
                            {
                                s.CopyTo(stream);
                                stream.Flush();
                            }
                        }
                    }
                }
                fs.Flush();
            }
            FileSystem.DeleteDirectory("extract/", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
        }

        public void Mount(string vhdPath)
        {
            using(var ps = PowerShell.Create())
            {
                var command = ps.AddCommand("Mount-DiskImage");
                command.AddParameter("ImagePath", vhdPath);
                command.Invoke();
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
            MakeVHD(openArchive.FileName, "output.vhd");
            Mount(AppDomain.CurrentDomain.BaseDirectory + "output.vhd");
        }

        private void openArchiveButton_Click(object sender, EventArgs e)
        {
            openArchive.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dismount(AppDomain.CurrentDomain.BaseDirectory + "output.vhd");
            Dismount(AppDomain.CurrentDomain.BaseDirectory + "output.iso");
        }

        private void openArchiveAsIso_FileOk(object sender, CancelEventArgs e)
        {
            MakeISO(openArchive.FileName, "output.iso");
            FileSystem.DeleteDirectory("extract/", UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
            Mount(AppDomain.CurrentDomain.BaseDirectory + "output.iso");
        }
    }
}
