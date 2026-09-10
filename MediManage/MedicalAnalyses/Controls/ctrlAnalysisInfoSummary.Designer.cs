namespace MediManage
{
    partial class ctrlAnalysisInfoSummary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.klblMoreInfo = new System.Windows.Forms.LinkLabel();
            this.lblOrderDate = new System.Windows.Forms.Label();
            this.lblAnalysisType = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.klblMoreInfo);
            this.panel1.Controls.Add(this.lblOrderDate);
            this.panel1.Controls.Add(this.lblAnalysisType);
            this.panel1.Controls.Add(this.lblPatientName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 178);
            this.panel1.TabIndex = 2;
            // 
            // klblMoreInfo
            // 
            this.klblMoreInfo.AutoSize = true;
            this.klblMoreInfo.Enabled = false;
            this.klblMoreInfo.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMoreInfo.Location = new System.Drawing.Point(1058, 141);
            this.klblMoreInfo.Name = "klblMoreInfo";
            this.klblMoreInfo.Size = new System.Drawing.Size(110, 28);
            this.klblMoreInfo.TabIndex = 149;
            this.klblMoreInfo.TabStop = true;
            this.klblMoreInfo.Text = "More Info";
            this.klblMoreInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.klblMoreInfo_LinkClicked);
            // 
            // lblOrderDate
            // 
            this.lblOrderDate.AutoSize = true;
            this.lblOrderDate.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderDate.Location = new System.Drawing.Point(244, 122);
            this.lblOrderDate.Name = "lblOrderDate";
            this.lblOrderDate.Size = new System.Drawing.Size(62, 34);
            this.lblOrderDate.TabIndex = 148;
            this.lblOrderDate.Text = "Null";
            // 
            // lblAnalysisType
            // 
            this.lblAnalysisType.AutoSize = true;
            this.lblAnalysisType.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalysisType.Location = new System.Drawing.Point(244, 72);
            this.lblAnalysisType.Name = "lblAnalysisType";
            this.lblAnalysisType.Size = new System.Drawing.Size(62, 34);
            this.lblAnalysisType.TabIndex = 147;
            this.lblAnalysisType.Text = "Null";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(244, 20);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(62, 34);
            this.lblPatientName.TabIndex = 146;
            this.lblPatientName.Text = "Null";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 34);
            this.label3.TabIndex = 145;
            this.label3.Text = "Order Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 34);
            this.label2.TabIndex = 144;
            this.label2.Text = "Analysis Type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(192, 34);
            this.label4.TabIndex = 143;
            this.label4.Text = "Patient Name:";
            // 
            // ctrlAnalysisInfoSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ctrlAnalysisInfoSummary";
            this.Size = new System.Drawing.Size(1191, 185);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel klblMoreInfo;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.Label lblAnalysisType;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}
