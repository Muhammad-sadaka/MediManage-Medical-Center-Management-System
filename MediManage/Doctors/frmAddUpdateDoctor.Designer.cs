namespace MediManage
{
    partial class frmAddUpdateDoctor
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkIsActive = new MediManage.MyCustomCheckBox();
            this.tbConsultationFees = new System.Windows.Forms.TextBox();
            this.cbSpecialties = new System.Windows.Forms.ComboBox();
            this.numericEcperienceYears = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbQualification = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLicenseNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ctrlPersonInfoSummary1 = new MediManage.ctrlPersonInfoSummary();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEcperienceYears)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(427, 826);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 58);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Silver;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(623, 826);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 58);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(645, 51);
            this.lblTitle.TabIndex = 25;
            this.lblTitle.Text = "Add New Doctor                        ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkIsActive);
            this.groupBox3.Controls.Add(this.tbConsultationFees);
            this.groupBox3.Controls.Add(this.cbSpecialties);
            this.groupBox3.Controls.Add(this.numericEcperienceYears);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbQualification);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbLicenseNo);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 431);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1209, 384);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3 ";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.BackColor = System.Drawing.Color.Transparent;
            this.chkIsActive.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsActive.Location = new System.Drawing.Point(313, 324);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(45, 38);
            this.chkIsActive.TabIndex = 178;
            this.chkIsActive.Text = " ";
            this.chkIsActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkIsActive.UseVisualStyleBackColor = false;
            // 
            // tbConsultationFees
            // 
            this.tbConsultationFees.Location = new System.Drawing.Point(311, 268);
            this.tbConsultationFees.Name = "tbConsultationFees";
            this.tbConsultationFees.ReadOnly = true;
            this.tbConsultationFees.Size = new System.Drawing.Size(887, 40);
            this.tbConsultationFees.TabIndex = 177;
            // 
            // cbSpecialties
            // 
            this.cbSpecialties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSpecialties.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSpecialties.FormattingEnabled = true;
            this.cbSpecialties.Location = new System.Drawing.Point(311, 36);
            this.cbSpecialties.Name = "cbSpecialties";
            this.cbSpecialties.Size = new System.Drawing.Size(889, 36);
            this.cbSpecialties.TabIndex = 176;
            this.cbSpecialties.SelectedIndexChanged += new System.EventHandler(this.cbSpecialties_SelectedIndexChanged);
            // 
            // numericEcperienceYears
            // 
            this.numericEcperienceYears.Location = new System.Drawing.Point(311, 150);
            this.numericEcperienceYears.Name = "numericEcperienceYears";
            this.numericEcperienceYears.Size = new System.Drawing.Size(889, 40);
            this.numericEcperienceYears.TabIndex = 175;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 268);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 34);
            this.label11.TabIndex = 170;
            this.label11.Text = "Consultation Fees:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(34, 210);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 34);
            this.label10.TabIndex = 169;
            this.label10.Text = "Qualification:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(271, 34);
            this.label9.TabIndex = 168;
            this.label9.Text = "Years of Experience:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 326);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 34);
            this.label7.TabIndex = 149;
            this.label7.Text = "Is Active:";
            // 
            // tbQualification
            // 
            this.tbQualification.Location = new System.Drawing.Point(313, 210);
            this.tbQualification.Name = "tbQualification";
            this.tbQualification.Size = new System.Drawing.Size(887, 40);
            this.tbQualification.TabIndex = 148;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 34);
            this.label6.TabIndex = 147;
            this.label6.Text = "License No:";
            // 
            // tbLicenseNo
            // 
            this.tbLicenseNo.Location = new System.Drawing.Point(313, 91);
            this.tbLicenseNo.Name = "tbLicenseNo";
            this.tbLicenseNo.Size = new System.Drawing.Size(887, 40);
            this.tbLicenseNo.TabIndex = 146;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 34);
            this.label5.TabIndex = 145;
            this.label5.Text = "Specialty:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlPersonInfoSummary1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1209, 236);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2 Person Information";
            // 
            // ctrlPersonInfoSummary1
            // 
            this.ctrlPersonInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfoSummary1.Location = new System.Drawing.Point(10, 42);
            this.ctrlPersonInfoSummary1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlPersonInfoSummary1.Name = "ctrlPersonInfoSummary1";
            this.ctrlPersonInfoSummary1.Size = new System.Drawing.Size(1190, 185);
            this.ctrlPersonInfoSummary1.TabIndex = 0;
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.label8);
            this.gbSearch.Controls.Add(this.tbNationalNo);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 83);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1209, 100);
            this.gbSearch.TabIndex = 26;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "1 Search";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(34, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(169, 34);
            this.label8.TabIndex = 144;
            this.label8.Text = "National No:";
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalNo.ForeColor = System.Drawing.Color.Silver;
            this.tbNationalNo.Location = new System.Drawing.Point(209, 42);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(823, 40);
            this.tbNationalNo.TabIndex = 22;
            this.tbNationalNo.Text = "National No";
            this.tbNationalNo.Enter += new System.EventHandler(this.tbNationalNo_Enter);
            this.tbNationalNo.Leave += new System.EventHandler(this.tbNationalNo_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(1038, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(162, 47);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // frmAddUpdateDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 896);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateDoctor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddUpdateDoctor";
            this.Load += new System.EventHandler(this.frmAddUpdateDoctor_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericEcperienceYears)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbQualification;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbLicenseNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericEcperienceYears;
        private System.Windows.Forms.ComboBox cbSpecialties;
        private ctrlPersonInfoSummary ctrlPersonInfoSummary1;
        private System.Windows.Forms.TextBox tbConsultationFees;
        private MyCustomCheckBox chkIsActive;
    }
}