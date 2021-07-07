
namespace ZipAsDisk
{
    partial class SettngsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsTabs = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.openInExplorerCheckBox = new System.Windows.Forms.CheckBox();
            this.vhdTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.extractInTempRadioButton = new System.Windows.Forms.RadioButton();
            this.customExtractPathRadioButton = new System.Windows.Forms.RadioButton();
            this.customPathTextBox = new System.Windows.Forms.TextBox();
            this.customPathSelectButton = new System.Windows.Forms.Button();
            this.settingsTabs.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsTabs
            // 
            this.settingsTabs.Controls.Add(this.generalTabPage);
            this.settingsTabs.Controls.Add(this.vhdTabPage);
            this.settingsTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsTabs.Location = new System.Drawing.Point(0, 0);
            this.settingsTabs.Name = "settingsTabs";
            this.settingsTabs.SelectedIndex = 0;
            this.settingsTabs.Size = new System.Drawing.Size(464, 356);
            this.settingsTabs.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.panel1);
            this.generalTabPage.Controls.Add(this.openInExplorerCheckBox);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(456, 330);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "Общее";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // openInExplorerCheckBox
            // 
            this.openInExplorerCheckBox.AutoSize = true;
            this.openInExplorerCheckBox.Location = new System.Drawing.Point(8, 11);
            this.openInExplorerCheckBox.Name = "openInExplorerCheckBox";
            this.openInExplorerCheckBox.Size = new System.Drawing.Size(290, 17);
            this.openInExplorerCheckBox.TabIndex = 1;
            this.openInExplorerCheckBox.Text = "Открывать диск в проводнике после монтирования";
            this.openInExplorerCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.openInExplorerCheckBox.UseVisualStyleBackColor = true;
            // 
            // vhdTabPage
            // 
            this.vhdTabPage.Location = new System.Drawing.Point(4, 22);
            this.vhdTabPage.Name = "vhdTabPage";
            this.vhdTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.vhdTabPage.Size = new System.Drawing.Size(456, 330);
            this.vhdTabPage.TabIndex = 1;
            this.vhdTabPage.Text = "VHD";
            this.vhdTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.customPathSelectButton);
            this.panel1.Controls.Add(this.customPathTextBox);
            this.panel1.Controls.Add(this.customExtractPathRadioButton);
            this.panel1.Controls.Add(this.extractInTempRadioButton);
            this.panel1.Location = new System.Drawing.Point(8, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 84);
            this.panel1.TabIndex = 2;
            // 
            // extractInTempRadioButton
            // 
            this.extractInTempRadioButton.AutoSize = true;
            this.extractInTempRadioButton.Checked = true;
            this.extractInTempRadioButton.Location = new System.Drawing.Point(8, 11);
            this.extractInTempRadioButton.Name = "extractInTempRadioButton";
            this.extractInTempRadioButton.Size = new System.Drawing.Size(208, 17);
            this.extractInTempRadioButton.TabIndex = 0;
            this.extractInTempRadioButton.TabStop = true;
            this.extractInTempRadioButton.Text = "Путь распаковки: Временная папка";
            this.extractInTempRadioButton.UseVisualStyleBackColor = true;
            this.extractInTempRadioButton.CheckedChanged += new System.EventHandler(this.extractInTempRadioButton_CheckedChanged);
            // 
            // customExtractPathRadioButton
            // 
            this.customExtractPathRadioButton.AutoSize = true;
            this.customExtractPathRadioButton.Location = new System.Drawing.Point(8, 34);
            this.customExtractPathRadioButton.Name = "customExtractPathRadioButton";
            this.customExtractPathRadioButton.Size = new System.Drawing.Size(115, 17);
            this.customExtractPathRadioButton.TabIndex = 1;
            this.customExtractPathRadioButton.Text = "Путь распаковки:";
            this.customExtractPathRadioButton.UseVisualStyleBackColor = true;
            this.customExtractPathRadioButton.CheckedChanged += new System.EventHandler(this.customExtractPathRadioButton_CheckedChanged);
            // 
            // customPathTextBox
            // 
            this.customPathTextBox.Enabled = false;
            this.customPathTextBox.Location = new System.Drawing.Point(8, 58);
            this.customPathTextBox.Name = "customPathTextBox";
            this.customPathTextBox.Size = new System.Drawing.Size(270, 20);
            this.customPathTextBox.TabIndex = 2;
            // 
            // customPathSelectButton
            // 
            this.customPathSelectButton.Enabled = false;
            this.customPathSelectButton.Location = new System.Drawing.Point(282, 57);
            this.customPathSelectButton.Name = "customPathSelectButton";
            this.customPathSelectButton.Size = new System.Drawing.Size(30, 23);
            this.customPathSelectButton.TabIndex = 3;
            this.customPathSelectButton.Text = "...";
            this.customPathSelectButton.UseVisualStyleBackColor = true;
            this.customPathSelectButton.Click += new System.EventHandler(this.customPathSelectButton_Click);
            // 
            // SettngsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 356);
            this.Controls.Add(this.settingsTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettngsForm";
            this.Text = "Настройки";
            this.settingsTabs.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl settingsTabs;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.CheckBox openInExplorerCheckBox;
        private System.Windows.Forms.TabPage vhdTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button customPathSelectButton;
        private System.Windows.Forms.TextBox customPathTextBox;
        private System.Windows.Forms.RadioButton customExtractPathRadioButton;
        private System.Windows.Forms.RadioButton extractInTempRadioButton;
    }
}