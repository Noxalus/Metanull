namespace Metanull
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nullItButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.destFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.waitTimer = new System.Windows.Forms.Timer(this.components);
            this.destFolderButton = new System.Windows.Forms.Button();
            this.destFolderTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.batchFolderBrowseButton = new System.Windows.Forms.Button();
            this.batchFolderTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "1";
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "2";
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label5.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(12, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 39);
            this.label5.TabIndex = 11;
            this.label5.Text = "3";
            //
            // nullItButton
            //
            this.nullItButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nullItButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.nullItButton.ForeColor = System.Drawing.Color.Black;
            this.nullItButton.Location = new System.Drawing.Point(324, 131);
            this.nullItButton.Name = "nullItButton";
            this.nullItButton.Size = new System.Drawing.Size(156, 23);
            this.nullItButton.TabIndex = 14;
            this.nullItButton.Text = "Exécuter";
            this.nullItButton.UseVisualStyleBackColor = true;
            this.nullItButton.Click += new System.EventHandler(this.nullItButton_Click);
            //
            // progressBar
            //
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(55, 131);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(263, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 16;
            //
            // openFileDialog
            //
            this.openFileDialog.Filter = "JPG, JPEG (*.jpg, *.jpeg)|*.jp*g";
            //
            // logTextBox
            //
            this.logTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logTextBox.BackColor = System.Drawing.Color.Black;
            this.logTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.logTextBox.Location = new System.Drawing.Point(55, 160);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTextBox.Size = new System.Drawing.Size(425, 128);
            this.logTextBox.TabIndex = 17;
            //
            // waitTimer
            //
            this.waitTimer.Interval = 300;
            this.waitTimer.Tick += new System.EventHandler(this.waitTimer_Tick);
            //
            // destFolderButton
            //
            this.destFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destFolderButton.Location = new System.Drawing.Point(309, 85);
            this.destFolderButton.Name = "destFolderButton";
            this.destFolderButton.Size = new System.Drawing.Size(75, 23);
            this.destFolderButton.TabIndex = 25;
            this.destFolderButton.Text = "Parcourir...";
            this.destFolderButton.UseVisualStyleBackColor = true;
            this.destFolderButton.Click += new System.EventHandler(this.destFolderButton_Click);
            //
            // destFolderTextBox
            //
            this.destFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destFolderTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.destFolderTextBox.Location = new System.Drawing.Point(55, 87);
            this.destFolderTextBox.Name = "destFolderTextBox";
            this.destFolderTextBox.ReadOnly = true;
            this.destFolderTextBox.Size = new System.Drawing.Size(248, 20);
            this.destFolderTextBox.TabIndex = 24;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(52, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Copier les images modifiées dans";
            //
            // batchFolderBrowseButton
            //
            this.batchFolderBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.batchFolderBrowseButton.Location = new System.Drawing.Point(309, 27);
            this.batchFolderBrowseButton.Name = "batchFolderBrowseButton";
            this.batchFolderBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.batchFolderBrowseButton.TabIndex = 33;
            this.batchFolderBrowseButton.Text = "Parcourir...";
            this.batchFolderBrowseButton.UseVisualStyleBackColor = true;
            this.batchFolderBrowseButton.Click += new System.EventHandler(this.batchFolderBrowseButton_Click);
            //
            // batchFolderTextBox
            //
            this.batchFolderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batchFolderTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.batchFolderTextBox.Location = new System.Drawing.Point(55, 29);
            this.batchFolderTextBox.Name = "batchFolderTextBox";
            this.batchFolderTextBox.ReadOnly = true;
            this.batchFolderTextBox.Size = new System.Drawing.Size(248, 20);
            this.batchFolderTextBox.TabIndex = 31;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(52, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Images source";
            //
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 300);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.batchFolderBrowseButton);
            this.Controls.Add(this.batchFolderTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.destFolderButton);
            this.Controls.Add(this.destFolderTextBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.nullItButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MinimumSize = new System.Drawing.Size(427, 339);
            this.Name = "MainForm";
            this.Text = "Metanull";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button nullItButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog sourceFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog destFolderDialog;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.Timer waitTimer;
        private System.Windows.Forms.Button destFolderButton;
        private System.Windows.Forms.TextBox destFolderTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button batchFolderBrowseButton;
        private System.Windows.Forms.TextBox batchFolderTextBox;
        private System.Windows.Forms.Label label4;
    }
}

