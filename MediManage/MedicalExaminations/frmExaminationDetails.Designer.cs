namespace MediManage
{
    partial class frmExaminationDetails
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
            this.ctrlExaminationInfo1 = new MediManage.ctrlExaminationInfo();
            this.SuspendLayout();
            // 
            // ctrlExaminationInfo1
            // 
            this.ctrlExaminationInfo1.BackColor = System.Drawing.Color.Silver;
            this.ctrlExaminationInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlExaminationInfo1.Name = "ctrlExaminationInfo1";
            this.ctrlExaminationInfo1.Size = new System.Drawing.Size(596, 469);
            this.ctrlExaminationInfo1.TabIndex = 0;
            // 
            // frmExaminationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 476);
            this.Controls.Add(this.ctrlExaminationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmExaminationDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Examination Details";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlExaminationInfo ctrlExaminationInfo1;
    }
}