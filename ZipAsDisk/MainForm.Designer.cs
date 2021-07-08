
namespace ZipAsDisk
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openArchiveButton = new System.Windows.Forms.Button();
            this.openArchive = new System.Windows.Forms.OpenFileDialog();
            this.openArchiveAsIsoButton = new System.Windows.Forms.Button();
            this.openArchiveAsIso = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.openInExplorerCheckBox = new System.Windows.Forms.CheckBox();
            this.diskArchiveChangeWatcher = new System.IO.FileSystemWatcher();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diskArchiveChangeWatcher)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openArchiveButton
            // 
            this.openArchiveButton.Location = new System.Drawing.Point(12, 25);
            this.openArchiveButton.Name = "openArchiveButton";
            this.openArchiveButton.Size = new System.Drawing.Size(125, 23);
            this.openArchiveButton.TabIndex = 0;
            this.openArchiveButton.Text = "Открыть как VHD";
            this.openArchiveButton.UseVisualStyleBackColor = true;
            this.openArchiveButton.Click += new System.EventHandler(this.openArchiveButton_Click);
            // 
            // openArchive
            // 
            this.openArchive.FileName = "archive.zip";
            this.openArchive.Filter = "ZIP|*.zip";
            this.openArchive.FileOk += new System.ComponentModel.CancelEventHandler(this.openArchive_FileOk);
            // 
            // openArchiveAsIsoButton
            // 
            this.openArchiveAsIsoButton.Location = new System.Drawing.Point(12, 54);
            this.openArchiveAsIsoButton.Name = "openArchiveAsIsoButton";
            this.openArchiveAsIsoButton.Size = new System.Drawing.Size(125, 23);
            this.openArchiveAsIsoButton.TabIndex = 1;
            this.openArchiveAsIsoButton.Text = "Открыть как ISO";
            this.openArchiveAsIsoButton.UseVisualStyleBackColor = true;
            this.openArchiveAsIsoButton.Click += new System.EventHandler(this.openArchiveAsIsoButton_Click);
            // 
            // openArchiveAsIso
            // 
            this.openArchiveAsIso.FileName = "archive.zip";
            this.openArchiveAsIso.Filter = "ZIP|*.zip";
            this.openArchiveAsIso.FileOk += new System.ComponentModel.CancelEventHandler(this.openArchiveAsIso_FileOk);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 119);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(420, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(43, 17);
            this.statusLabel.Text = "Статус";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            // 
            // openInExplorerCheckBox
            // 
            this.openInExplorerCheckBox.AutoSize = true;
            this.openInExplorerCheckBox.Location = new System.Drawing.Point(12, 83);
            this.openInExplorerCheckBox.Name = "openInExplorerCheckBox";
            this.openInExplorerCheckBox.Size = new System.Drawing.Size(142, 17);
            this.openInExplorerCheckBox.TabIndex = 3;
            this.openInExplorerCheckBox.Text = "Открыть в проводнике";
            this.openInExplorerCheckBox.UseVisualStyleBackColor = true;
            // 
            // diskArchiveChangeWatcher
            // 
            this.diskArchiveChangeWatcher.EnableRaisingEvents = true;
            this.diskArchiveChangeWatcher.IncludeSubdirectories = true;
            this.diskArchiveChangeWatcher.SynchronizingObject = this;
            this.diskArchiveChangeWatcher.Created += new System.IO.FileSystemEventHandler(this.applyChanges);
            this.diskArchiveChangeWatcher.Deleted += new System.IO.FileSystemEventHandler(this.applyChanges);
            this.diskArchiveChangeWatcher.Renamed += new System.IO.RenamedEventHandler(this.diskArchiveChangeWatcher_Renamed);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(420, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripItem
            // 
            this.settingsToolStripItem.Name = "settingsToolStripItem";
            this.settingsToolStripItem.Size = new System.Drawing.Size(79, 20);
            this.settingsToolStripItem.Text = "Настройки";
            this.settingsToolStripItem.Click += new System.EventHandler(this.settingsToolStripItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 141);
            this.Controls.Add(this.openInExplorerCheckBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.openArchiveAsIsoButton);
            this.Controls.Add(this.openArchiveButton);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "ZipAsDisk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diskArchiveChangeWatcher)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openArchiveButton;
        private System.Windows.Forms.OpenFileDialog openArchive;
        private System.Windows.Forms.Button openArchiveAsIsoButton;
        private System.Windows.Forms.OpenFileDialog openArchiveAsIso;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.CheckBox openInExplorerCheckBox;
        private System.IO.FileSystemWatcher diskArchiveChangeWatcher;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripItem;
    }
}

