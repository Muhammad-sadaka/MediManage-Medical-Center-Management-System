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
            components = new System.ComponentModel.Container();
            btnSave = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            lblTitle = new System.Windows.Forms.Label();
            groupBox3 = new System.Windows.Forms.GroupBox();
            chkIsActive = new CustomCheckBox();
            tbConsultationFees = new System.Windows.Forms.TextBox();
            cbSpecialties = new System.Windows.Forms.ComboBox();
            numericEcperienceYears = new System.Windows.Forms.NumericUpDown();
            label11 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            tbQualification = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            tbLicenseNo = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            ctrlPersonInfoSummary1 = new ctrlPersonInfoSummary();
            gbSearch = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            tbNationalNo = new System.Windows.Forms.TextBox();
            btnSearch = new System.Windows.Forms.Button();
            errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericEcperienceYears).BeginInit();
            groupBox2.SuspendLayout();
            gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Green;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Location = new System.Drawing.Point(488, 1032);
            btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(217, 72);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = System.Drawing.Color.Silver;
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnClose.Location = new System.Drawing.Point(712, 1032);
            btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(217, 72);
            btnClose.TabIndex = 10;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.Location = new System.Drawing.Point(14, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(645, 51);
            lblTitle.TabIndex = 25;
            lblTitle.Text = "Add New Doctor                        ";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(chkIsActive);
            groupBox3.Controls.Add(tbConsultationFees);
            groupBox3.Controls.Add(cbSpecialties);
            groupBox3.Controls.Add(numericEcperienceYears);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(tbQualification);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(tbLicenseNo);
            groupBox3.Controls.Add(label5);
            groupBox3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox3.Location = new System.Drawing.Point(14, 539);
            groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox3.Size = new System.Drawing.Size(1382, 480);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "3 ";
            // 
            // chkIsActive
            // 
            chkIsActive.Checked = true;
            chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            chkIsActive.FlatAppearance.BorderSize = 0;
            chkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            chkIsActive.Location = new System.Drawing.Point(358, 408);
            chkIsActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new System.Drawing.Size(55, 48);
            chkIsActive.TabIndex = 178;
            chkIsActive.Text = "customCheckBox1";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // tbConsultationFees
            // 
            tbConsultationFees.Location = new System.Drawing.Point(355, 335);
            tbConsultationFees.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbConsultationFees.Name = "tbConsultationFees";
            tbConsultationFees.ReadOnly = true;
            tbConsultationFees.Size = new System.Drawing.Size(1013, 40);
            tbConsultationFees.TabIndex = 177;
            // 
            // cbSpecialties
            // 
            cbSpecialties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbSpecialties.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            cbSpecialties.FormattingEnabled = true;
            cbSpecialties.Location = new System.Drawing.Point(355, 45);
            cbSpecialties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            cbSpecialties.Name = "cbSpecialties";
            cbSpecialties.Size = new System.Drawing.Size(1015, 36);
            cbSpecialties.TabIndex = 4;
            cbSpecialties.SelectedIndexChanged += cbSpecialties_SelectedIndexChanged;
            // 
            // numericEcperienceYears
            // 
            numericEcperienceYears.Location = new System.Drawing.Point(355, 188);
            numericEcperienceYears.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            numericEcperienceYears.Name = "numericEcperienceYears";
            numericEcperienceYears.Size = new System.Drawing.Size(1016, 40);
            numericEcperienceYears.TabIndex = 6;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label11.Location = new System.Drawing.Point(39, 335);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(245, 34);
            label11.TabIndex = 170;
            label11.Text = "Consultation Fees:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label10.Location = new System.Drawing.Point(39, 262);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(177, 34);
            label10.TabIndex = 169;
            label10.Text = "Qualification:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label9.Location = new System.Drawing.Point(39, 190);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(271, 34);
            label9.TabIndex = 168;
            label9.Text = "Years of Experience:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label7.Location = new System.Drawing.Point(39, 408);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(131, 34);
            label7.TabIndex = 149;
            label7.Text = "Is Active:";
            // 
            // tbQualification
            // 
            tbQualification.Location = new System.Drawing.Point(358, 262);
            tbQualification.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbQualification.Name = "tbQualification";
            tbQualification.Size = new System.Drawing.Size(1013, 40);
            tbQualification.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label6.Location = new System.Drawing.Point(39, 118);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(160, 34);
            label6.TabIndex = 147;
            label6.Text = "License No:";
            // 
            // tbLicenseNo
            // 
            tbLicenseNo.Location = new System.Drawing.Point(358, 114);
            tbLicenseNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbLicenseNo.Name = "tbLicenseNo";
            tbLicenseNo.Size = new System.Drawing.Size(1013, 40);
            tbLicenseNo.TabIndex = 5;
            tbLicenseNo.Validating += tbLicenseNo_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label5.Location = new System.Drawing.Point(39, 45);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(134, 34);
            label5.TabIndex = 145;
            label5.Text = "Specialty:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ctrlPersonInfoSummary1);
            groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            groupBox2.Location = new System.Drawing.Point(14, 236);
            groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            groupBox2.Size = new System.Drawing.Size(1382, 295);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "2 Person Information";
            // 
            // ctrlPersonInfoSummary1
            // 
            ctrlPersonInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            ctrlPersonInfoSummary1.Location = new System.Drawing.Point(11, 52);
            ctrlPersonInfoSummary1.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            ctrlPersonInfoSummary1.Name = "ctrlPersonInfoSummary1";
            ctrlPersonInfoSummary1.Size = new System.Drawing.Size(1360, 231);
            ctrlPersonInfoSummary1.TabIndex = 0;
            // 
            // gbSearch
            // 
            gbSearch.Controls.Add(label8);
            gbSearch.Controls.Add(tbNationalNo);
            gbSearch.Controls.Add(btnSearch);
            gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            gbSearch.Location = new System.Drawing.Point(14, 104);
            gbSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gbSearch.Name = "gbSearch";
            gbSearch.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            gbSearch.Size = new System.Drawing.Size(1382, 125);
            gbSearch.TabIndex = 1;
            gbSearch.TabStop = false;
            gbSearch.Text = "1 Search";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            label8.Location = new System.Drawing.Point(39, 55);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(169, 34);
            label8.TabIndex = 144;
            label8.Text = "National No:";
            // 
            // tbNationalNo
            // 
            tbNationalNo.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            tbNationalNo.ForeColor = System.Drawing.Color.Silver;
            tbNationalNo.Location = new System.Drawing.Point(239, 52);
            tbNationalNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            tbNationalNo.Name = "tbNationalNo";
            tbNationalNo.Size = new System.Drawing.Size(940, 40);
            tbNationalNo.TabIndex = 1;
            tbNationalNo.Text = "National No";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = System.Drawing.Color.Blue;
            btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            btnSearch.ForeColor = System.Drawing.Color.White;
            btnSearch.Location = new System.Drawing.Point(1186, 49);
            btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(185, 59);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmAddUpdateDoctor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1409, 1102);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(gbSearch);
            Controls.Add(lblTitle);
            Controls.Add(btnSave);
            Controls.Add(btnClose);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "frmAddUpdateDoctor";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "frmAddUpdateDoctor";
            Load += frmAddUpdateDoctor_Load;
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericEcperienceYears).EndInit();
            groupBox2.ResumeLayout(false);
            gbSearch.ResumeLayout(false);
            gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private CustomCheckBox chkIsActive;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}