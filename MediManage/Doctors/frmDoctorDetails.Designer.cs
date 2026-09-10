namespace MediManage
{
    partial class frmDoctorDetails
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
            this.ctrlDoctorInfo1 = new MediManage.ctrlDoctorInfo();
            this.SuspendLayout();
            // 
            // ctrlDoctorInfo1
            // 
            this.ctrlDoctorInfo1.Location = new System.Drawing.Point(2, 2);
            this.ctrlDoctorInfo1.Name = "ctrlDoctorInfo1";
            this.ctrlDoctorInfo1.Size = new System.Drawing.Size(677, 390);
            this.ctrlDoctorInfo1.TabIndex = 0;
            // 
            // frmDoctorDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 391);
            this.Controls.Add(this.ctrlDoctorInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDoctorDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Doctor Details";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDoctorInfo ctrlDoctorInfo1;
    }
}