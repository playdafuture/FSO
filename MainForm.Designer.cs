namespace FileSearcher
{
    partial class MainForm
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
            if (disposing && (components != null))
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
            this.BTN_SelectSource = new System.Windows.Forms.Button();
            this.BTN_SelectTarget = new System.Windows.Forms.Button();
            this.TB_Source = new System.Windows.Forms.TextBox();
            this.TB_Target = new System.Windows.Forms.TextBox();
            this.TB_NameList = new System.Windows.Forms.TextBox();
            this.BTN_Run = new System.Windows.Forms.Button();
            this.Label_PasteHere = new System.Windows.Forms.Label();
            this.openSourceFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openTargetFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.CB_PDF = new System.Windows.Forms.CheckBox();
            this.CB_Case = new System.Windows.Forms.CheckBox();
            this.BTN_Clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTN_SelectSource
            // 
            this.BTN_SelectSource.Location = new System.Drawing.Point(12, 30);
            this.BTN_SelectSource.Name = "BTN_SelectSource";
            this.BTN_SelectSource.Size = new System.Drawing.Size(158, 30);
            this.BTN_SelectSource.TabIndex = 0;
            this.BTN_SelectSource.Text = "Select Source Folder";
            this.BTN_SelectSource.UseVisualStyleBackColor = true;
            this.BTN_SelectSource.Click += new System.EventHandler(this.BTN_SelectSource_Click);
            // 
            // BTN_SelectTarget
            // 
            this.BTN_SelectTarget.Location = new System.Drawing.Point(12, 88);
            this.BTN_SelectTarget.Name = "BTN_SelectTarget";
            this.BTN_SelectTarget.Size = new System.Drawing.Size(158, 30);
            this.BTN_SelectTarget.TabIndex = 1;
            this.BTN_SelectTarget.Text = "Select Target Folder";
            this.BTN_SelectTarget.UseVisualStyleBackColor = true;
            this.BTN_SelectTarget.Click += new System.EventHandler(this.BTN_SelectTarget_Click);
            // 
            // TB_Source
            // 
            this.TB_Source.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Source.Location = new System.Drawing.Point(176, 30);
            this.TB_Source.Name = "TB_Source";
            this.TB_Source.Size = new System.Drawing.Size(612, 30);
            this.TB_Source.TabIndex = 2;
            // 
            // TB_Target
            // 
            this.TB_Target.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Target.Location = new System.Drawing.Point(176, 88);
            this.TB_Target.Name = "TB_Target";
            this.TB_Target.Size = new System.Drawing.Size(612, 30);
            this.TB_Target.TabIndex = 3;
            // 
            // TB_NameList
            // 
            this.TB_NameList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_NameList.Location = new System.Drawing.Point(176, 168);
            this.TB_NameList.Multiline = true;
            this.TB_NameList.Name = "TB_NameList";
            this.TB_NameList.Size = new System.Drawing.Size(612, 270);
            this.TB_NameList.TabIndex = 4;
            // 
            // BTN_Run
            // 
            this.BTN_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Run.Location = new System.Drawing.Point(12, 379);
            this.BTN_Run.Name = "BTN_Run";
            this.BTN_Run.Size = new System.Drawing.Size(158, 59);
            this.BTN_Run.TabIndex = 5;
            this.BTN_Run.Text = "Run";
            this.BTN_Run.UseVisualStyleBackColor = true;
            this.BTN_Run.Click += new System.EventHandler(this.BTN_Run_Click);
            // 
            // Label_PasteHere
            // 
            this.Label_PasteHere.AutoSize = true;
            this.Label_PasteHere.Location = new System.Drawing.Point(677, 148);
            this.Label_PasteHere.Name = "Label_PasteHere";
            this.Label_PasteHere.Size = new System.Drawing.Size(111, 17);
            this.Label_PasteHere.TabIndex = 6;
            this.Label_PasteHere.Text = "Paste Name List";
            // 
            // CB_PDF
            // 
            this.CB_PDF.AutoSize = true;
            this.CB_PDF.Enabled = false;
            this.CB_PDF.Location = new System.Drawing.Point(12, 352);
            this.CB_PDF.Name = "CB_PDF";
            this.CB_PDF.Size = new System.Drawing.Size(117, 21);
            this.CB_PDF.TabIndex = 7;
            this.CB_PDF.Text = "Save As .PDF";
            this.CB_PDF.UseVisualStyleBackColor = true;
            // 
            // CB_Case
            // 
            this.CB_Case.AutoSize = true;
            this.CB_Case.Location = new System.Drawing.Point(12, 325);
            this.CB_Case.Name = "CB_Case";
            this.CB_Case.Size = new System.Drawing.Size(123, 21);
            this.CB_Case.TabIndex = 8;
            this.CB_Case.Text = "Case Sensitive";
            this.CB_Case.UseVisualStyleBackColor = true;
            // 
            // BTN_Clear
            // 
            this.BTN_Clear.Location = new System.Drawing.Point(12, 168);
            this.BTN_Clear.Name = "BTN_Clear";
            this.BTN_Clear.Size = new System.Drawing.Size(158, 30);
            this.BTN_Clear.TabIndex = 9;
            this.BTN_Clear.Text = "Clear";
            this.BTN_Clear.UseVisualStyleBackColor = true;
            this.BTN_Clear.Click += new System.EventHandler(this.BTN_Clear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_Clear);
            this.Controls.Add(this.CB_Case);
            this.Controls.Add(this.CB_PDF);
            this.Controls.Add(this.Label_PasteHere);
            this.Controls.Add(this.BTN_Run);
            this.Controls.Add(this.TB_NameList);
            this.Controls.Add(this.TB_Target);
            this.Controls.Add(this.TB_Source);
            this.Controls.Add(this.BTN_SelectTarget);
            this.Controls.Add(this.BTN_SelectSource);
            this.Name = "MainForm";
            this.Text = "File Searcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTN_SelectSource;
        private System.Windows.Forms.Button BTN_SelectTarget;
        private System.Windows.Forms.TextBox TB_Source;
        private System.Windows.Forms.TextBox TB_Target;
        private System.Windows.Forms.TextBox TB_NameList;
        private System.Windows.Forms.Button BTN_Run;
        private System.Windows.Forms.Label Label_PasteHere;
        private System.Windows.Forms.FolderBrowserDialog openSourceFolderDialog;
        private System.Windows.Forms.FolderBrowserDialog openTargetFolderDialog;
        private System.Windows.Forms.CheckBox CB_PDF;
        private System.Windows.Forms.CheckBox CB_Case;
        private System.Windows.Forms.Button BTN_Clear;
    }
}

