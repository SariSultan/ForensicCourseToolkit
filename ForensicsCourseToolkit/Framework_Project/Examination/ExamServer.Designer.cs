namespace ForensicsCourseToolkit.Framework_Project.Examination
{
    partial class ExamServer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.instructorPassTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventLogChkBox = new System.Windows.Forms.CheckBox();
            this.reportBtn = new System.Windows.Forms.Button();
            this.stopServerBtn = new System.Windows.Forms.Button();
            this.showPasswordChkBox = new System.Windows.Forms.CheckBox();
            this.startServerBtn = new System.Windows.Forms.Button();
            this.studentPassTxtBox = new System.Windows.Forms.TextBox();
            this.studentPasswordLbl = new System.Windows.Forms.Label();
            this.openExamBtn = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.dgview = new System.Windows.Forms.DataGridView();
            this.serialCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rcvdCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.submittedCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gradeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.openFirewallRules = new System.Windows.Forms.Button();
            this.portTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.portTxtBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.openFirewallRules);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.instructorPassTxtBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.eventLogChkBox);
            this.panel1.Controls.Add(this.reportBtn);
            this.panel1.Controls.Add(this.stopServerBtn);
            this.panel1.Controls.Add(this.showPasswordChkBox);
            this.panel1.Controls.Add(this.startServerBtn);
            this.panel1.Controls.Add(this.studentPassTxtBox);
            this.panel1.Controls.Add(this.studentPasswordLbl);
            this.panel1.Controls.Add(this.openExamBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 125);
            this.panel1.TabIndex = 0;
            // 
            // instructorPassTxtBox
            // 
            this.instructorPassTxtBox.Location = new System.Drawing.Point(799, 14);
            this.instructorPassTxtBox.Name = "instructorPassTxtBox";
            this.instructorPassTxtBox.Size = new System.Drawing.Size(171, 22);
            this.instructorPassTxtBox.TabIndex = 94;
            this.instructorPassTxtBox.Text = "123456";
            this.instructorPassTxtBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(661, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 17);
            this.label1.TabIndex = 93;
            this.label1.Text = "Instructor Password";
            // 
            // eventLogChkBox
            // 
            this.eventLogChkBox.AutoSize = true;
            this.eventLogChkBox.Location = new System.Drawing.Point(773, 46);
            this.eventLogChkBox.Name = "eventLogChkBox";
            this.eventLogChkBox.Size = new System.Drawing.Size(136, 21);
            this.eventLogChkBox.TabIndex = 92;
            this.eventLogChkBox.Text = "Include Full Logs";
            this.eventLogChkBox.UseVisualStyleBackColor = true;
            // 
            // reportBtn
            // 
            this.reportBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.reportBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reportBtn.FlatAppearance.BorderSize = 0;
            this.reportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportBtn.ForeColor = System.Drawing.Color.White;
            this.reportBtn.Location = new System.Drawing.Point(773, 70);
            this.reportBtn.Margin = new System.Windows.Forms.Padding(4);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(205, 51);
            this.reportBtn.TabIndex = 91;
            this.reportBtn.Text = "Create Grades Report";
            this.reportBtn.UseVisualStyleBackColor = false;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // stopServerBtn
            // 
            this.stopServerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.stopServerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopServerBtn.FlatAppearance.BorderSize = 0;
            this.stopServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopServerBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopServerBtn.ForeColor = System.Drawing.Color.White;
            this.stopServerBtn.Location = new System.Drawing.Point(560, 70);
            this.stopServerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.stopServerBtn.Name = "stopServerBtn";
            this.stopServerBtn.Size = new System.Drawing.Size(205, 51);
            this.stopServerBtn.TabIndex = 90;
            this.stopServerBtn.Text = "Stop Server";
            this.stopServerBtn.UseVisualStyleBackColor = false;
            this.stopServerBtn.Click += new System.EventHandler(this.stopServerBtn_Click);
            // 
            // showPasswordChkBox
            // 
            this.showPasswordChkBox.AutoSize = true;
            this.showPasswordChkBox.Location = new System.Drawing.Point(208, 15);
            this.showPasswordChkBox.Name = "showPasswordChkBox";
            this.showPasswordChkBox.Size = new System.Drawing.Size(64, 21);
            this.showPasswordChkBox.TabIndex = 89;
            this.showPasswordChkBox.Text = "Show";
            this.showPasswordChkBox.UseVisualStyleBackColor = true;
            this.showPasswordChkBox.CheckedChanged += new System.EventHandler(this.showPasswordChkBox_CheckedChanged);
            // 
            // startServerBtn
            // 
            this.startServerBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.startServerBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startServerBtn.FlatAppearance.BorderSize = 0;
            this.startServerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startServerBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServerBtn.ForeColor = System.Drawing.Color.White;
            this.startServerBtn.Location = new System.Drawing.Point(347, 70);
            this.startServerBtn.Margin = new System.Windows.Forms.Padding(4);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(205, 51);
            this.startServerBtn.TabIndex = 88;
            this.startServerBtn.Text = "Start Server";
            this.startServerBtn.UseVisualStyleBackColor = false;
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // studentPassTxtBox
            // 
            this.studentPassTxtBox.Location = new System.Drawing.Point(88, 16);
            this.studentPassTxtBox.Name = "studentPassTxtBox";
            this.studentPassTxtBox.Size = new System.Drawing.Size(114, 22);
            this.studentPassTxtBox.TabIndex = 87;
            this.studentPassTxtBox.Text = "123456";
            this.studentPassTxtBox.UseSystemPasswordChar = true;
            // 
            // studentPasswordLbl
            // 
            this.studentPasswordLbl.AutoSize = true;
            this.studentPasswordLbl.Location = new System.Drawing.Point(12, 17);
            this.studentPasswordLbl.Name = "studentPasswordLbl";
            this.studentPasswordLbl.Size = new System.Drawing.Size(70, 17);
            this.studentPasswordLbl.TabIndex = 86;
            this.studentPasswordLbl.Text = "Exam Key";
            // 
            // openExamBtn
            // 
            this.openExamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(113)))), ((int)(((byte)(0)))));
            this.openExamBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openExamBtn.FlatAppearance.BorderSize = 0;
            this.openExamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openExamBtn.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openExamBtn.ForeColor = System.Drawing.Color.White;
            this.openExamBtn.Location = new System.Drawing.Point(13, 46);
            this.openExamBtn.Margin = new System.Windows.Forms.Padding(4);
            this.openExamBtn.Name = "openExamBtn";
            this.openExamBtn.Size = new System.Drawing.Size(227, 37);
            this.openExamBtn.TabIndex = 71;
            this.openExamBtn.Text = "Open Exam File";
            this.openExamBtn.UseVisualStyleBackColor = false;
            this.openExamBtn.Click += new System.EventHandler(this.openExamBtn_Click);
            // 
            // rtb
            // 
            this.rtb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb.Location = new System.Drawing.Point(0, 125);
            this.rtb.Name = "rtb";
            this.rtb.Size = new System.Drawing.Size(425, 522);
            this.rtb.TabIndex = 1;
            this.rtb.Text = "";
            // 
            // dgview
            // 
            this.dgview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialCol,
            this.idCol,
            this.nameCol,
            this.rcvdCol,
            this.submittedCol,
            this.gradeCol});
            this.dgview.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgview.Location = new System.Drawing.Point(425, 125);
            this.dgview.Name = "dgview";
            this.dgview.ReadOnly = true;
            this.dgview.RowTemplate.Height = 24;
            this.dgview.Size = new System.Drawing.Size(557, 522);
            this.dgview.TabIndex = 2;
            // 
            // serialCol
            // 
            this.serialCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.serialCol.Frozen = true;
            this.serialCol.HeaderText = "No.";
            this.serialCol.Name = "serialCol";
            this.serialCol.ReadOnly = true;
            this.serialCol.Width = 59;
            // 
            // idCol
            // 
            this.idCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.idCol.Frozen = true;
            this.idCol.HeaderText = "Std. ID";
            this.idCol.Name = "idCol";
            this.idCol.ReadOnly = true;
            this.idCol.Width = 79;
            // 
            // nameCol
            // 
            this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameCol.HeaderText = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // rcvdCol
            // 
            this.rcvdCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.rcvdCol.HeaderText = "Received";
            this.rcvdCol.Name = "rcvdCol";
            this.rcvdCol.ReadOnly = true;
            this.rcvdCol.Width = 96;
            // 
            // submittedCol
            // 
            this.submittedCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.submittedCol.HeaderText = "Submitted";
            this.submittedCol.Name = "submittedCol";
            this.submittedCol.ReadOnly = true;
            // 
            // gradeCol
            // 
            this.gradeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gradeCol.HeaderText = "Grade";
            this.gradeCol.Name = "gradeCol";
            this.gradeCol.ReadOnly = true;
            this.gradeCol.Width = 77;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 21);
            this.checkBox1.TabIndex = 95;
            this.checkBox1.Text = "Enable Firewall";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // openFirewallRules
            // 
            this.openFirewallRules.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.openFirewallRules.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFirewallRules.FlatAppearance.BorderSize = 0;
            this.openFirewallRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.openFirewallRules.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFirewallRules.ForeColor = System.Drawing.Color.White;
            this.openFirewallRules.Location = new System.Drawing.Point(144, 84);
            this.openFirewallRules.Margin = new System.Windows.Forms.Padding(4);
            this.openFirewallRules.Name = "openFirewallRules";
            this.openFirewallRules.Size = new System.Drawing.Size(128, 37);
            this.openFirewallRules.TabIndex = 96;
            this.openFirewallRules.Text = "Open Rules";
            this.openFirewallRules.UseVisualStyleBackColor = false;
            this.openFirewallRules.Visible = false;
            this.openFirewallRules.Click += new System.EventHandler(this.openFirewallRules_Click);
            // 
            // portTxtBox
            // 
            this.portTxtBox.Location = new System.Drawing.Point(425, 44);
            this.portTxtBox.Name = "portTxtBox";
            this.portTxtBox.Size = new System.Drawing.Size(114, 22);
            this.portTxtBox.TabIndex = 98;
            this.portTxtBox.Text = "10048";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 97;
            this.label2.Text = "Port";
            // 
            // ExamServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 647);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.dgview);
            this.Controls.Add(this.panel1);
            this.Name = "ExamServer";
            this.Text = "ExamServer";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button openExamBtn;
        private System.Windows.Forms.Button startServerBtn;
        private System.Windows.Forms.TextBox studentPassTxtBox;
        private System.Windows.Forms.Label studentPasswordLbl;
        private System.Windows.Forms.CheckBox showPasswordChkBox;
        private System.Windows.Forms.DataGridView dgview;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn rcvdCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn submittedCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn gradeCol;
        private System.Windows.Forms.Button stopServerBtn;
        private System.Windows.Forms.CheckBox eventLogChkBox;
        private System.Windows.Forms.Button reportBtn;
        private System.Windows.Forms.TextBox instructorPassTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openFirewallRules;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox portTxtBox;
        private System.Windows.Forms.Label label2;
    }
}