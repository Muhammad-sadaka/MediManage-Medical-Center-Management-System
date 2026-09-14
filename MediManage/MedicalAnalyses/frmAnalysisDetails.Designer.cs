namespace MediManage
{
    partial class frmAnalysisDetails
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
            this.ctrlAnalysisInfo1 = new MediManage.ctrlAnalysisInfo();
            this.SuspendLayout();
            // 
            // ctrlAnalysisInfo1
            // 
            this.ctrlAnalysisInfo1.BackColor = System.Drawing.Color.Silver;
            this.ctrlAnalysisInfo1.Location = new System.Drawing.Point(6, 3);
            this.ctrlAnalysisInfo1.Name = "ctrlAnalysisInfo1";
            this.ctrlAnalysisInfo1.Size = new System.Drawing.Size(1171, 306);
            this.ctrlAnalysisInfo1.TabIndex = 0;
            // 
            // frmAnalysisDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 313);
            this.Controls.Add(this.ctrlAnalysisInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAnalysisDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Analysis Details";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlAnalysisInfo ctrlAnalysisInfo1;
    }
}