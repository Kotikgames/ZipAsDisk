
namespace ZipAsDisk
{
    partial class SettingsForm
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.customDiskImagesPathSelect = new System.Windows.Forms.Button();
            this.customDiskImagesPath = new System.Windows.Forms.TextBox();
            this.customDiskImagesPathRadioButton = new System.Windows.Forms.RadioButton();
            this.diskImagesPathTempRadioButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.customPathSelectButton = new System.Windows.Forms.Button();
            this.customPathTextBox = new System.Windows.Forms.TextBox();
            this.customExtractPathRadioButton = new System.Windows.Forms.RadioButton();
            this.extractInTempRadioButton = new System.Windows.Forms.RadioButton();
            this.openInExplorerCheckBox = new System.Windows.Forms.CheckBox();
            this.vhdTabPage = new System.Windows.Forms.TabPage();
            this.archiveEditInRealTimeCheckBox = new System.Windows.Forms.CheckBox();
            this.settingsTabs.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.vhdTabPage.SuspendLayout();
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
            this.generalTabPage.Controls.Add(this.panel2);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.customDiskImagesPathSelect);
            this.panel2.Controls.Add(this.customDiskImagesPath);
            this.panel2.Controls.Add(this.customDiskImagesPathRadioButton);
            this.panel2.Controls.Add(this.diskImagesPathTempRadioButton);
            this.panel2.Location = new System.Drawing.Point(6, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 84);
            this.panel2.TabIndex = 4;
            // 
            // customDiskImagesPathSelect
            // 
            this.customDiskImagesPathSelect.Enabled = false;
            this.customDiskImagesPathSelect.Location = new System.Drawing.Point(282, 57);
            this.customDiskImagesPathSelect.Name = "customDiskImagesPathSelect";
            this.customDiskImagesPathSelect.Size = new System.Drawing.Size(30, 23);
            this.customDiskImagesPathSelect.TabIndex = 3;
            this.customDiskImagesPathSelect.Text = "...";
            this.customDiskImagesPathSelect.UseVisualStyleBackColor = true;
            this.customDiskImagesPathSelect.Click += new System.EventHandler(this.diskPathSelect_Click);
            // 
            // customDiskImagesPath
            // 
            this.customDiskImagesPath.Enabled = false;
            this.customDiskImagesPath.Location = new System.Drawing.Point(8, 58);
            this.customDiskImagesPath.Name = "customDiskImagesPath";
            this.customDiskImagesPath.Size = new System.Drawing.Size(270, 20);
            this.customDiskImagesPath.TabIndex = 2;
            // 
            // customDiskImagesPathRadioButton
            // 
            this.customDiskImagesPathRadioButton.AutoSize = true;
            this.customDiskImagesPathRadioButton.Location = new System.Drawing.Point(8, 34);
            this.customDiskImagesPathRadioButton.Name = "customDiskImagesPathRadioButton";
            this.customDiskImagesPathRadioButton.Size = new System.Drawing.Size(122, 17);
            this.customDiskImagesPathRadioButton.TabIndex = 1;
            this.customDiskImagesPathRadioButton.Text = "Путь для VHD/ISO:";
            this.customDiskImagesPathRadioButton.UseVisualStyleBackColor = true;
            this.customDiskImagesPathRadioButton.CheckedChanged += new System.EventHandler(this.customDiskImagesPathRadioButton_CheckedChanged);
            // 
            // diskImagesPathTempRadioButton
            // 
            this.diskImagesPathTempRadioButton.AutoSize = true;
            this.diskImagesPathTempRadioButton.Checked = true;
            this.diskImagesPathTempRadioButton.Location = new System.Drawing.Point(8, 11);
            this.diskImagesPathTempRadioButton.Name = "diskImagesPathTempRadioButton";
            this.diskImagesPathTempRadioButton.Size = new System.Drawing.Size(215, 17);
            this.diskImagesPathTempRadioButton.TabIndex = 0;
            this.diskImagesPathTempRadioButton.TabStop = true;
            this.diskImagesPathTempRadioButton.Text = "Путь для VHD/ISO: Временная папка";
            this.diskImagesPathTempRadioButton.UseVisualStyleBackColor = true;
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
            // customPathTextBox
            // 
            this.customPathTextBox.Enabled = false;
            this.customPathTextBox.Location = new System.Drawing.Point(8, 58);
            this.customPathTextBox.Name = "customPathTextBox";
            this.customPathTextBox.Size = new System.Drawing.Size(270, 20);
            this.customPathTextBox.TabIndex = 2;
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
            // openInExplorerCheckBox
            // 
            this.openInExplorerCheckBox.AutoSize = true;
            this.openInExplorerCheckBox.Checked = true;
            this.openInExplorerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.vhdTabPage.Controls.Add(this.archiveEditInRealTimeCheckBox);
            this.vhdTabPage.Location = new System.Drawing.Point(4, 22);
            this.vhdTabPage.Name = "vhdTabPage";
            this.vhdTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.vhdTabPage.Size = new System.Drawing.Size(456, 330);
            this.vhdTabPage.TabIndex = 1;
            this.vhdTabPage.Text = "VHD";
            this.vhdTabPage.UseVisualStyleBackColor = true;
            // 
            // archiveEditInRealTimeCheckBox
            // 
            this.archiveEditInRealTimeCheckBox.AutoSize = true;
            this.archiveEditInRealTimeCheckBox.Checked = true;
            this.archiveEditInRealTimeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.archiveEditInRealTimeCheckBox.Location = new System.Drawing.Point(8, 11);
            this.archiveEditInRealTimeCheckBox.Name = "archiveEditInRealTimeCheckBox";
            this.archiveEditInRealTimeCheckBox.Size = new System.Drawing.Size(231, 17);
            this.archiveEditInRealTimeCheckBox.TabIndex = 0;
            this.archiveEditInRealTimeCheckBox.Text = "Изменение архива в реальном времени";
            this.archiveEditInRealTimeCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 356);
            this.Controls.Add(this.settingsTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsForm_FormClosing);
            this.settingsTabs.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.vhdTabPage.ResumeLayout(false);
            this.vhdTabPage.PerformLayout();
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
        private System.Windows.Forms.CheckBox archiveEditInRealTimeCheckBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button customDiskImagesPathSelect;
        private System.Windows.Forms.TextBox customDiskImagesPath;
        private System.Windows.Forms.RadioButton customDiskImagesPathRadioButton;
        private System.Windows.Forms.RadioButton diskImagesPathTempRadioButton;
    }
}