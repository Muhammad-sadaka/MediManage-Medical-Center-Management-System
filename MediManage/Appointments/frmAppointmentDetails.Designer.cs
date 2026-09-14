namespace MediManage
{
    partial class frmAppointmentDetails
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
            this.ctrlappointmentInfo1 = new MediManage.ctrlappointmentInfo();
            this.SuspendLayout();
            // 
            // ctrlappointmentInfo1
            // 
            this.ctrlappointmentInfo1.BackColor = System.Drawing.Color.Silver;
            this.ctrlappointmentInfo1.Location = new System.Drawing.Point(2, 1);
            this.ctrlappointmentInfo1.Name = "ctrlappointmentInfo1";
            this.ctrlappointmentInfo1.Size = new System.Drawing.Size(779, 412);
            this.ctrlappointmentInfo1.TabIndex = 0;
            // 
            // frmAppointmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 415);
            this.Controls.Add(this.ctrlappointmentInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmAppointmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAppointmentDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlappointmentInfo ctrlappointmentInfo1;
    }
}