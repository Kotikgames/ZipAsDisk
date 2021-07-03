
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
            this.SuspendLayout();
            // 
            // openArchiveButton
            // 
            this.openArchiveButton.Location = new System.Drawing.Point(12, 12);
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
            this.openArchiveAsIsoButton.Location = new System.Drawing.Point(12, 41);
            this.openArchiveAsIsoButton.Name = "openArchiveAsIsoButton";
            this.openArchiveAsIsoButton.Size = new System.Drawing.Size(125, 23);
            this.openArchiveAsIsoButton.TabIndex = 1;
            this.openArchiveAsIsoButton.Text = "Открыть как ISO";
            this.openArchiveAsIsoButton.UseVisualStyleBackColor = true;
            // 
            // openArchiveAsIso
            // 
            this.openArchiveAsIso.FileName = "archive.zip";
            this.openArchiveAsIso.Filter = "ZIP|*.zip";
            this.openArchiveAsIso.FileOk += new System.ComponentModel.CancelEventHandler(this.openArchiveAsIso_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 130);
            this.Controls.Add(this.openArchiveAsIsoButton);
            this.Controls.Add(this.openArchiveButton);
            this.Name = "MainForm";
            this.Text = "ZipAsDisk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openArchiveButton;
        private System.Windows.Forms.OpenFileDialog openArchive;
        private System.Windows.Forms.Button openArchiveAsIsoButton;
        private System.Windows.Forms.OpenFileDialog openArchiveAsIso;
    }
}

