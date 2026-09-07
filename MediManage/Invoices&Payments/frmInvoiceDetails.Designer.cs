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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.cbMedicineName = new System.Windows.Forms.ComboBox();
            this.tbDosage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DGVPeopleList = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeopleList)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSearch
            // 
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 84);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1230, 224);
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
            this.lblTitle.Size = new System.Drawing.Size(642, 51);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Add New Invoice                       ";
            // 
            // groupBox1
            // 
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1230, 244);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Section 2: Bill Items";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGVPeopleList);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 573);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1230, 116);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Section 3: Payment History";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbDosage);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cbMedicineName);
            this.groupBox3.Controls.Add(this.btnAddItem);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 695);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1230, 109);
            this.groupBox3.TabIndex = 33;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Section 4: Add New Payment";
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackColor = System.Drawing.Color.Green;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddItem.ForeColor = System.Drawing.Color.White;
            this.btnAddItem.Location = new System.Drawing.Point(980, 52);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(233, 41);
            this.btnAddItem.TabIndex = 30;
            this.btnAddItem.Text = "Add Payment";
            this.btnAddItem.UseVisualStyleBackColor = false;
            // 
            // cbMedicineName
            // 
            this.cbMedicineName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMedicineName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbMedicineName.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMedicineName.FormattingEnabled = true;
            this.cbMedicineName.Location = new System.Drawing.Point(699, 54);
            this.cbMedicineName.Name = "cbMedicineName";
            this.cbMedicineName.Size = new System.Drawing.Size(275, 41);
            this.cbMedicineName.TabIndex = 169;
            // 
            // tbDosage
            // 
            this.tbDosage.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDosage.Location = new System.Drawing.Point(170, 55);
            this.tbDosage.Name = "tbDosage";
            this.tbDosage.Size = new System.Drawing.Size(275, 40);
            this.tbDosage.TabIndex = 168;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(469, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 34);
            this.label1.TabIndex = 170;
            this.label1.Text = "Payment Method";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 34);
            this.label2.TabIndex = 171;
            this.label2.Text = "Amount ($)";
            // 
            // DGVPeopleList
            // 
            this.DGVPeopleList.AllowUserToAddRows = false;
            this.DGVPeopleList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGVPeopleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVPeopleList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGVPeopleList.BackgroundColor = System.Drawing.Color.White;
            this.DGVPeopleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPeopleList.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVPeopleList.Location = new System.Drawing.Point(12, 39);
            this.DGVPeopleList.Name = "DGVPeopleList";
            this.DGVPeopleList.ReadOnly = true;
            this.DGVPeopleList.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.DGVPeopleList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DGVPeopleList.RowTemplate.Height = 26;
            this.DGVPeopleList.Size = new System.Drawing.Size(1201, 60);
            this.DGVPeopleList.TabIndex = 23;
            // 
            // frmInvoiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 816);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gbSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInvoiceDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmInvoiceDetails";
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPeopleList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.ComboBox cbMedicineName;
        private System.Windows.Forms.TextBox tbDosage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView DGVPeopleList;
    }
}