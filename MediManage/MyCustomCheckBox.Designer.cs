namespace MediManage
{
    partial class MyCustomCheckBox
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(0, 0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(38, 34);
            this.checkBox1.TabIndex = 172;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.checkBox1_Paint_1);
            // 
            // MyCustomCheckBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Checked = true;
            this.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Controls.Add(this.checkBox1);
            this.Size = new System.Drawing.Size(43, 41);
            this.UseVisualStyleBackColor = false;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
    }
}
