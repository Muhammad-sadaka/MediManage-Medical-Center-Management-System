namespace MediManage
{
    partial class frmAddAnalysis
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.cbAnalysisTypes = new System.Windows.Forms.ComboBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.numericExaminationID = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ctrlExaminationInfoSummary1 = new MediManage.ctrlExaminationInfoSummary();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericExaminationID)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPrice);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbNotes);
            this.groupBox1.Controls.Add(this.cbAnalysisTypes);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 385);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1212, 277);
            this.groupBox1.TabIndex = 183;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Section 2 - Analysis Details";
            // 
            // tbPrice
            // 
            this.tbPrice.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPrice.Location = new System.Drawing.Point(234, 109);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(293, 35);
            this.tbPrice.TabIndex = 182;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 34);
            this.label5.TabIndex = 181;
            this.label5.Text = "Notes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 34);
            this.label2.TabIndex = 179;
            this.label2.Text = "Price:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 34);
            this.label1.TabIndex = 144;
            this.label1.Text = "Analysis Type:";
            // 
            // tbNotes
            // 
            this.tbNotes.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNotes.Location = new System.Drawing.Point(234, 161);
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(968, 94);
            this.tbNotes.TabIndex = 176;
            // 
            // cbAnalysisTypes
            // 
            this.cbAnalysisTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnalysisTypes.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAnalysisTypes.FormattingEnabled = true;
            this.cbAnalysisTypes.Location = new System.Drawing.Point(234, 56);
            this.cbAnalysisTypes.Name = "cbAnalysisTypes";
            this.cbAnalysisTypes.Size = new System.Drawing.Size(293, 36);
            this.cbAnalysisTypes.TabIndex = 173;
            this.cbAnalysisTypes.SelectedIndexChanged += new System.EventHandler(this.cbAnalysisTypes_SelectedIndexChanged);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.numericExaminationID);
            this.gbSearch.Controls.Add(this.label4);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.ctrlExaminationInfoSummary1);
            this.gbSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSearch.Location = new System.Drawing.Point(21, 92);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1212, 287);
            this.gbSearch.TabIndex = 182;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Section 1 - Examination Search";
            // 
            // numericExaminationID
            // 
            this.numericExaminationID.Location = new System.Drawing.Point(217, 45);
            this.numericExaminationID.Name = "numericExaminationID";
            this.numericExaminationID.Size = new System.Drawing.Size(414, 40);
            this.numericExaminationID.TabIndex = 148;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 34);
            this.label4.TabIndex = 147;
            this.label4.Text = "Examination ID";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(639, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(162, 47);
            this.btnSearch.TabIndex = 146;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ctrlExaminationInfoSummary1
            // 
            this.ctrlExaminationInfoSummary1.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlExaminationInfoSummary1.Location = new System.Drawing.Point(10, 94);
            this.ctrlExaminationInfoSummary1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ctrlExaminationInfoSummary1.Name = "ctrlExaminationInfoSummary1";
            this.ctrlExaminationInfoSummary1.Size = new System.Drawing.Size(1190, 184);
            this.ctrlExaminationInfoSummary1.TabIndex = 145;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(670, 51);
            this.lblTitle.TabIndex = 181;
            this.lblTitle.Text = "Add New Analysis                       ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Green;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(436, 668);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(190, 58);
            this.btnSave.TabIndex = 180;
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
            this.btnClose.Location = new System.Drawing.Point(632, 668);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(190, 58);
            this.btnClose.TabIndex = 179;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmAddAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 735);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddAnalysis";
            this.Load += new System.EventHandler(this.frmAddAnalysis_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericExaminationID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.ComboBox cbAnalysisTypes;
        private System.Windows.Forms.GroupBox gbSearch;
        private ctrlExaminationInfoSummary ctrlExaminationInfoSummary1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.NumericUpDown numericExaminationID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
    }
}