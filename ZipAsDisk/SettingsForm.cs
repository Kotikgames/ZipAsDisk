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
using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;

namespace ZipAsDisk
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            Settings s = Settings.settings;
            openInExplorerCheckBox.Checked = s.OpenInExplorer;
            if(s.ExtractPath == "Temp")
                extractInTempRadioButton.Checked = true;
            else
            {
                customPathTextBox.Text = s.ExtractPath;
                customExtractPathRadioButton.Checked = true;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customExtractPathRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(customExtractPathRadioButton.Checked)
            {
                customPathTextBox.Enabled = true;
                customPathSelectButton.Enabled = true;
            }
        }

        private void extractInTempRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(extractInTempRadioButton.Checked)
            {
                customPathTextBox.Enabled = false;
                customPathSelectButton.Enabled = false;
            }
        }

        private void customPathSelectButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog
            {
                InitialDirectory = customPathTextBox.Text,
                IsFolderPicker = true
            };
            if(dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                customPathTextBox.Text = dialog.FileName;
            }

        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings s = Settings.settings;
            s.OpenInExplorer = openInExplorerCheckBox.Checked;
            s.ExtractPath = extractInTempRadioButton.Checked ? "Temp" : customPathTextBox.Text;
            Settings.SaveSettings();
        }
    }
    public class Settings
    {
        [JsonProperty]
        public bool OpenInExplorer { get; set; } = true;
        [JsonProperty]
        public string ExtractPath { get; set; } = "Temp";

        public static Settings settings = new Settings();

        public static void SaveSettings()
        {
            using(StreamWriter fs = File.CreateText("settings.json"))
                fs.Write(JsonConvert.SerializeObject(settings));
        }
        public static void LoadSettings()
        {
            if(!File.Exists("settings.json"))
                SaveSettings();
            else
                using(StreamReader fs = File.OpenText("settings.json"))
                    settings = JsonConvert.DeserializeObject<Settings>(fs.ReadToEnd());
        }
    }
}
