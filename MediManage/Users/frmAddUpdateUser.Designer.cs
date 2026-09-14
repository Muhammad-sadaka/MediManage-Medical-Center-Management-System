namespace MediManage
{
    partial class frmAddUpdateUser
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbNationalNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkManageUsers = new MediManage.CustomCheckBox();
            this.chkManagePatients = new MediManage.CustomCheckBox();
            this.chkManageInvoicesPayments = new MediManage.CustomCheckBox();
            this.chkManageAppointments = new MediManage.CustomCheckBox();
            this.chkManageAnalyses = new MediManage.CustomCheckBox();
            this.chkManageExaminations = new MediManage.CustomCheckBox();
            this.chkManagePrescriptions = new MediManage.CustomCheckBox();
            this.chkManagePeople = new MediManage.CustomCheckBox();
            this.chkManageDoctors = new MediManage.CustomCheckBox();
            this.chkIsActive = new MediManage.CustomCheckBox();
            this.ctrlPersonInfoSummary1 = new MediManage.ctrlPersonInfoSummary();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gbSearch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(591, 51);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Add New User                       ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(439, 890);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 58);
            this.btnSave.TabIndex = 19;
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
            this.btnClose.Location = new System.Drawing.Point(635, 890);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 58);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.tbNationalNo);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(12, 93);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1224, 100);
            this.gbSearch.TabIndex = 21;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "1 Search";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 34);
            this.label4.TabIndex = 144;
            this.label4.Text = "National No:";
            // 
            // tbNationalNo
            // 
            this.tbNationalNo.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalNo.ForeColor = System.Drawing.Color.Silver;
            this.tbNationalNo.Location = new System.Drawing.Point(209, 42);
            this.tbNationalNo.Name = "tbNationalNo";
            this.tbNationalNo.Size = new System.Drawing.Size(828, 40);
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
            this.btnSearch.Location = new System.Drawing.Point(1043, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(162, 47);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ctrlPersonInfoSummary1);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1224, 236);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2 Person Information";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbConfirmPassword);
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.tbUsername);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 441);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1224, 236);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Credentials";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(78, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 34);
            this.label7.TabIndex = 172;
            this.label7.Text = "Is Active";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(73, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 34);
            this.label2.TabIndex = 172;
            this.label2.Text = "Confirm Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 34);
            this.label1.TabIndex = 171;
            this.label1.Text = "Password";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(367, 139);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(670, 35);
            this.tbConfirmPassword.TabIndex = 170;
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(367, 93);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(670, 35);
            this.tbPassword.TabIndex = 169;
            // 
            // tbUsername
            // 
            this.tbUsername.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsername.Location = new System.Drawing.Point(367, 46);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(670, 35);
            this.tbUsername.TabIndex = 168;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(73, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 34);
            this.label15.TabIndex = 167;
            this.label15.Text = "Username";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chkManageUsers);
            this.groupBox3.Controls.Add(this.chkManagePatients);
            this.groupBox3.Controls.Add(this.chkManageInvoicesPayments);
            this.groupBox3.Controls.Add(this.chkManageAppointments);
            this.groupBox3.Controls.Add(this.chkManageAnalyses);
            this.groupBox3.Controls.Add(this.chkManageExaminations);
            this.groupBox3.Controls.Add(this.chkManagePrescriptions);
            this.groupBox3.Controls.Add(this.chkManagePeople);
            this.groupBox3.Controls.Add(this.chkManageDoctors);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 683);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1224, 201);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Permissions";
            // 
            // chkManageUsers
            // 
            this.chkManageUsers.Checked = true;
            this.chkManageUsers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManageUsers.FlatAppearance.BorderSize = 0;
            this.chkManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManageUsers.Location = new System.Drawing.Point(768, 146);
            this.chkManageUsers.Name = "chkManageUsers";
            this.chkManageUsers.Size = new System.Drawing.Size(45, 36);
            this.chkManageUsers.TabIndex = 210;
            this.chkManageUsers.Text = "customCheckBox10";
            this.chkManageUsers.UseVisualStyleBackColor = true;
            // 
            // chkManagePatients
            // 
            this.chkManagePatients.Checked = true;
            this.chkManagePatients.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManagePatients.FlatAppearance.BorderSize = 0;
            this.chkManagePatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManagePatients.Location = new System.Drawing.Point(40, 104);
            this.chkManagePatients.Name = "chkManagePatients";
            this.chkManagePatients.Size = new System.Drawing.Size(45, 36);
            this.chkManagePatients.TabIndex = 211;
            this.chkManagePatients.Text = "customCheckBox1";
            this.chkManagePatients.UseVisualStyleBackColor = true;
            // 
            // chkManageInvoicesPayments
            // 
            this.chkManageInvoicesPayments.Checked = true;
            this.chkManageInvoicesPayments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManageInvoicesPayments.FlatAppearance.BorderSize = 0;
            this.chkManageInvoicesPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManageInvoicesPayments.Location = new System.Drawing.Point(768, 104);
            this.chkManageInvoicesPayments.Name = "chkManageInvoicesPayments";
            this.chkManageInvoicesPayments.Size = new System.Drawing.Size(45, 36);
            this.chkManageInvoicesPayments.TabIndex = 209;
            this.chkManageInvoicesPayments.Text = "customCheckBox9";
            this.chkManageInvoicesPayments.UseVisualStyleBackColor = true;
            // 
            // chkManageAppointments
            // 
            this.chkManageAppointments.Checked = true;
            this.chkManageAppointments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManageAppointments.FlatAppearance.BorderSize = 0;
            this.chkManageAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManageAppointments.Location = new System.Drawing.Point(367, 62);
            this.chkManageAppointments.Name = "chkManageAppointments";
            this.chkManageAppointments.Size = new System.Drawing.Size(45, 36);
            this.chkManageAppointments.TabIndex = 205;
            this.chkManageAppointments.Text = "customCheckBox5";
            this.chkManageAppointments.UseVisualStyleBackColor = true;
            // 
            // chkManageAnalyses
            // 
            this.chkManageAnalyses.Checked = true;
            this.chkManageAnalyses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManageAnalyses.FlatAppearance.BorderSize = 0;
            this.chkManageAnalyses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManageAnalyses.Location = new System.Drawing.Point(768, 62);
            this.chkManageAnalyses.Name = "chkManageAnalyses";
            this.chkManageAnalyses.Size = new System.Drawing.Size(45, 36);
            this.chkManageAnalyses.TabIndex = 208;
            this.chkManageAnalyses.Text = "customCheckBox8";
            this.chkManageAnalyses.UseVisualStyleBackColor = true;
            // 
            // chkManageExaminations
            // 
            this.chkManageExaminations.Checked = true;
            this.chkManageExaminations.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManageExaminations.FlatAppearance.BorderSize = 0;
            this.chkManageExaminations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManageExaminations.Location = new System.Drawing.Point(367, 104);
            this.chkManageExaminations.Name = "chkManageExaminations";
            this.chkManageExaminations.Size = new System.Drawing.Size(45, 36);
            this.chkManageExaminations.TabIndex = 206;
            this.chkManageExaminations.Text = "customCheckBox6";
            this.chkManageExaminations.UseVisualStyleBackColor = true;
            // 
            // chkManagePrescriptions
            // 
            this.chkManagePrescriptions.Checked = true;
            this.chkManagePrescriptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManagePrescriptions.FlatAppearance.BorderSize = 0;
            this.chkManagePrescriptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManagePrescriptions.Location = new System.Drawing.Point(367, 146);
            this.chkManagePrescriptions.Name = "chkManagePrescriptions";
            this.chkManagePrescriptions.Size = new System.Drawing.Size(45, 36);
            this.chkManagePrescriptions.TabIndex = 207;
            this.chkManagePrescriptions.Text = "customCheckBox7";
            this.chkManagePrescriptions.UseVisualStyleBackColor = true;
            // 
            // chkManagePeople
            // 
            this.chkManagePeople.Checked = true;
            this.chkManagePeople.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManagePeople.FlatAppearance.BorderSize = 0;
            this.chkManagePeople.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManagePeople.Location = new System.Drawing.Point(40, 62);
            this.chkManagePeople.Name = "chkManagePeople";
            this.chkManagePeople.Size = new System.Drawing.Size(45, 36);
            this.chkManagePeople.TabIndex = 202;
            this.chkManagePeople.Text = "customCheckBox2";
            this.chkManagePeople.UseVisualStyleBackColor = true;
            // 
            // chkManageDoctors
            // 
            this.chkManageDoctors.Checked = true;
            this.chkManageDoctors.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkManageDoctors.FlatAppearance.BorderSize = 0;
            this.chkManageDoctors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkManageDoctors.Location = new System.Drawing.Point(40, 146);
            this.chkManageDoctors.Name = "chkManageDoctors";
            this.chkManageDoctors.Size = new System.Drawing.Size(45, 36);
            this.chkManageDoctors.TabIndex = 204;
            this.chkManageDoctors.Text = "customCheckBox4";
            this.chkManageDoctors.UseVisualStyleBackColor = true;
            // 
            // chkIsActive
            // 
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.FlatAppearance.BorderSize = 0;
            this.chkIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsActive.Location = new System.Drawing.Point(367, 186);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(45, 36);
            this.chkIsActive.TabIndex = 201;
            this.chkIsActive.Text = "customCheckBox1";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // ctrlPersonInfoSummary1
            // 
            this.ctrlPersonInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlPersonInfoSummary1.Location = new System.Drawing.Point(10, 42);
            this.ctrlPersonInfoSummary1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlPersonInfoSummary1.Name = "ctrlPersonInfoSummary1";
            this.ctrlPersonInfoSummary1.Size = new System.Drawing.Size(1195, 172);
            this.ctrlPersonInfoSummary1.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(203, 34);
            this.label3.TabIndex = 212;
            this.label3.Text = "Manage People";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(91, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 34);
            this.label5.TabIndex = 213;
            this.label5.Text = "Manage Patients";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(91, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 34);
            this.label6.TabIndex = 214;
            this.label6.Text = "Manage Doctors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(418, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(263, 34);
            this.label8.TabIndex = 217;
            this.label8.Text = "Mange Prescriptions";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(418, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(287, 34);
            this.label9.TabIndex = 216;
            this.label9.Text = "Manage Examinations";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(418, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(292, 34);
            this.label10.TabIndex = 215;
            this.label10.Text = "Manage Appointments";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(819, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(191, 34);
            this.label11.TabIndex = 220;
            this.label11.Text = "Manage Users";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(819, 104);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(373, 34);
            this.label12.TabIndex = 219;
            this.label12.Text = "Manage Invoices - Payments";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(819, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(231, 34);
            this.label13.TabIndex = 218;
            this.label13.Text = "Manage Analyses";
            // 
            // frmAddUpdateUser
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1264, 956);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddUpdateUser";
            this.Load += new System.EventHandler(this.frmAddUpdateUser_Load);
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbNationalNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private ctrlPersonInfoSummary ctrlPersonInfoSummary1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUsername;
        private CustomCheckBox chkManageUsers;
        private CustomCheckBox chkManageInvoicesPayments;
        private CustomCheckBox chkManageAnalyses;
        private CustomCheckBox chkManagePrescriptions;
        private CustomCheckBox chkManageExaminations;
        private CustomCheckBox chkManageAppointments;
        private CustomCheckBox chkManageDoctors;
        private CustomCheckBox chkManagePeople;
        private CustomCheckBox chkIsActive;
        private CustomCheckBox chkManagePatients;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
    }
}