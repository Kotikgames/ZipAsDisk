using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ZipAsDisk
{
    public partial class SettngsForm : Form
    {
        public SettngsForm()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customExtractPathRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(customExtractPathRadioButton.Checked)
            {

            }
        }

        private void extractInTempRadioButton_CheckedChanged(object sender, EventArgs e)
        {

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
    }
}
