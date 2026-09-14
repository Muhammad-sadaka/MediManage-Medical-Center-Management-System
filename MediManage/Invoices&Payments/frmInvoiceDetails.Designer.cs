namespace MediManage
{
    partial class frmInvoiceDetails
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
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPaymentStatus = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.lblBillDate = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.ctrlBillItemHistory1 = new MediManage.ctrlBillItemHistory();
            this.ctrlPaymentHistory1 = new MediManage.ctrlPaymentHistory();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lblCreatedBy);
            this.gbSearch.Controls.Add(this.lblPaymentStatus);
            this.gbSearch.Controls.Add(this.label2);
            this.gbSearch.Controls.Add(this.lblBillDate);
            this.gbSearch.Controls.Add(this.lblPatientName);
            this.gbSearch.Controls.Add(this.label1);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.label5);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 84);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1230, 147);
            this.gbSearch.TabIndex = 30;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Section 1: Invoice Info";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(598, 51);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Invoice Details                       ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 34);
            this.label1.TabIndex = 143;
            this.label1.Text = "Patient Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 34);
            this.label2.TabIndex = 144;
            this.label2.Text = "Bill Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(682, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 34);
            this.label4.TabIndex = 146;
            this.label4.Text = "Created By";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(682, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(239, 34);
            this.label5.TabIndex = 147;
            this.label5.Text = "Payment Status";
            // 
            // lblPaymentStatus
            // 
            this.lblPaymentStatus.AutoSize = true;
            this.lblPaymentStatus.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentStatus.Location = new System.Drawing.Point(927, 95);
            this.lblPaymentStatus.Name = "lblPaymentStatus";
            this.lblPaymentStatus.Size = new System.Drawing.Size(62, 34);
            this.lblPaymentStatus.TabIndex = 149;
            this.lblPaymentStatus.Text = "Null";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(927, 51);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(62, 34);
            this.lblCreatedBy.TabIndex = 148;
            this.lblCreatedBy.Text = "Null";
            // 
            // lblBillDate
            // 
            this.lblBillDate.AutoSize = true;
            this.lblBillDate.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillDate.Location = new System.Drawing.Point(240, 95);
            this.lblBillDate.Name = "lblBillDate";
            this.lblBillDate.Size = new System.Drawing.Size(62, 34);
            this.lblBillDate.TabIndex = 151;
            this.lblBillDate.Text = "Null";
            // 
            // lblPatientName
            // 
            this.lblPatientName.AutoSize = true;
            this.lblPatientName.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientName.Location = new System.Drawing.Point(240, 51);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(62, 34);
            this.lblPatientName.TabIndex = 150;
            this.lblPatientName.Text = "Null";
            // 
            // ctrlBillItemHistory1
            // 
            this.ctrlBillItemHistory1.Location = new System.Drawing.Point(11, 620);
            this.ctrlBillItemHistory1.Name = "ctrlBillItemHistory1";
            this.ctrlBillItemHistory1.Size = new System.Drawing.Size(1231, 294);
            this.ctrlBillItemHistory1.TabIndex = 33;
            // 
            // ctrlPaymentHistory1
            // 
            this.ctrlPaymentHistory1.Location = new System.Drawing.Point(11, 237);
            this.ctrlPaymentHistory1.Name = "ctrlPaymentHistory1";
            this.ctrlPaymentHistory1.Size = new System.Drawing.Size(1230, 377);
            this.ctrlPaymentHistory1.TabIndex = 32;
            // 
            // frmInvoiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1254, 919);
            this.Controls.Add(this.ctrlBillItemHistory1);
            this.Controls.Add(this.ctrlPaymentHistory1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInvoiceDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Details";
            this.Load += new System.EventHandler(this.frmInvoiceDetails_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label lblTitle;
        private ctrlPaymentHistory ctrlPaymentHistory1;
        private ctrlBillItemHistory ctrlBillItemHistory1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBillDate;
        private System.Windows.Forms.Label lblPatientName;
        private System.Windows.Forms.Label lblPaymentStatus;
        private System.Windows.Forms.Label lblCreatedBy;
    }
}