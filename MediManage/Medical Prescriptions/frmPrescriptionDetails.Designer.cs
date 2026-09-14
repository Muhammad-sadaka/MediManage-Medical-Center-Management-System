namespace MediManage
{
    partial class frmPrescriptionDetails
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
            this.ctrlPrescriptionInfo1 = new MediManage.ctrlPrescriptionInfo();
            this.SuspendLayout();
            // 
            // ctrlPrescriptionInfo1
            // 
            this.ctrlPrescriptionInfo1.BackColor = System.Drawing.Color.Silver;
            this.ctrlPrescriptionInfo1.Location = new System.Drawing.Point(3, 3);
            this.ctrlPrescriptionInfo1.Name = "ctrlPrescriptionInfo1";
            this.ctrlPrescriptionInfo1.Size = new System.Drawing.Size(1293, 658);
            this.ctrlPrescriptionInfo1.TabIndex = 0;
            // 
            // frmPrescriptionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 664);
            this.Controls.Add(this.ctrlPrescriptionInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPrescriptionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prescription Details";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlPrescriptionInfo ctrlPrescriptionInfo1;
    }
}