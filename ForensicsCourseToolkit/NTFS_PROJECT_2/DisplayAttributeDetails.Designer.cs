namespace NTFSLearning
{
    partial class DisplayAttributeDetails
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
            this.dataView = new System.Windows.Forms.DataGridView();
            this.Offsetaddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData00 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData01 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData02 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData03 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData04 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData06 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData07 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData08 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData09 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData0A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData0B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData0C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData0D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData0E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HexData0F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.byterange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAttr_name = new System.Windows.Forms.Label();
            this.RunlistGridView = new System.Windows.Forms.DataGridView();
            this.I = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartCluster = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadNonResident = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RunlistGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Offsetaddress,
            this.HexData00,
            this.HexData01,
            this.HexData02,
            this.HexData03,
            this.HexData04,
            this.HexData05,
            this.HexData06,
            this.HexData07,
            this.HexData08,
            this.HexData09,
            this.HexData0A,
            this.HexData0B,
            this.HexData0C,
            this.HexData0D,
            this.HexData0E,
            this.HexData0F,
            this.SelectedValue});
            this.dataView.Location = new System.Drawing.Point(12, 278);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            this.dataView.Size = new System.Drawing.Size(840, 410);
            this.dataView.TabIndex = 53;
            // 
            // Offsetaddress
            // 
            this.Offsetaddress.HeaderText = "Offset address";
            this.Offsetaddress.MaxInputLength = 4;
            this.Offsetaddress.Name = "Offsetaddress";
            this.Offsetaddress.ReadOnly = true;
            this.Offsetaddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Offsetaddress.Width = 90;
            // 
            // HexData00
            // 
            this.HexData00.HeaderText = "00";
            this.HexData00.Name = "HexData00";
            this.HexData00.ReadOnly = true;
            this.HexData00.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData00.Width = 40;
            // 
            // HexData01
            // 
            this.HexData01.HeaderText = "01";
            this.HexData01.Name = "HexData01";
            this.HexData01.ReadOnly = true;
            this.HexData01.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData01.Width = 40;
            // 
            // HexData02
            // 
            this.HexData02.HeaderText = "02";
            this.HexData02.Name = "HexData02";
            this.HexData02.ReadOnly = true;
            this.HexData02.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData02.Width = 40;
            // 
            // HexData03
            // 
            this.HexData03.HeaderText = "03";
            this.HexData03.Name = "HexData03";
            this.HexData03.ReadOnly = true;
            this.HexData03.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData03.Width = 40;
            // 
            // HexData04
            // 
            this.HexData04.HeaderText = "04";
            this.HexData04.Name = "HexData04";
            this.HexData04.ReadOnly = true;
            this.HexData04.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData04.Width = 40;
            // 
            // HexData05
            // 
            this.HexData05.HeaderText = "05";
            this.HexData05.Name = "HexData05";
            this.HexData05.ReadOnly = true;
            this.HexData05.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData05.Width = 40;
            // 
            // HexData06
            // 
            this.HexData06.HeaderText = "06";
            this.HexData06.Name = "HexData06";
            this.HexData06.ReadOnly = true;
            this.HexData06.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData06.Width = 40;
            // 
            // HexData07
            // 
            this.HexData07.HeaderText = "07";
            this.HexData07.Name = "HexData07";
            this.HexData07.ReadOnly = true;
            this.HexData07.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData07.Width = 40;
            // 
            // HexData08
            // 
            this.HexData08.HeaderText = "08";
            this.HexData08.Name = "HexData08";
            this.HexData08.ReadOnly = true;
            this.HexData08.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData08.Width = 40;
            // 
            // HexData09
            // 
            this.HexData09.HeaderText = "09";
            this.HexData09.Name = "HexData09";
            this.HexData09.ReadOnly = true;
            this.HexData09.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData09.Width = 40;
            // 
            // HexData0A
            // 
            this.HexData0A.HeaderText = "0A";
            this.HexData0A.Name = "HexData0A";
            this.HexData0A.ReadOnly = true;
            this.HexData0A.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData0A.Width = 40;
            // 
            // HexData0B
            // 
            this.HexData0B.HeaderText = "0B";
            this.HexData0B.Name = "HexData0B";
            this.HexData0B.ReadOnly = true;
            this.HexData0B.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData0B.Width = 40;
            // 
            // HexData0C
            // 
            this.HexData0C.HeaderText = "0C";
            this.HexData0C.Name = "HexData0C";
            this.HexData0C.ReadOnly = true;
            this.HexData0C.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData0C.Width = 40;
            // 
            // HexData0D
            // 
            this.HexData0D.HeaderText = "0D";
            this.HexData0D.Name = "HexData0D";
            this.HexData0D.ReadOnly = true;
            this.HexData0D.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData0D.Width = 40;
            // 
            // HexData0E
            // 
            this.HexData0E.HeaderText = "0E";
            this.HexData0E.Name = "HexData0E";
            this.HexData0E.ReadOnly = true;
            this.HexData0E.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData0E.Width = 40;
            // 
            // HexData0F
            // 
            this.HexData0F.HeaderText = "0F";
            this.HexData0F.Name = "HexData0F";
            this.HexData0F.ReadOnly = true;
            this.HexData0F.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HexData0F.Width = 40;
            // 
            // SelectedValue
            // 
            this.SelectedValue.HeaderText = "Value";
            this.SelectedValue.Name = "SelectedValue";
            this.SelectedValue.ReadOnly = true;
            this.SelectedValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.LightBlue;
            this.txtOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(24, 34);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(613, 238);
            this.txtOutput.TabIndex = 52;
            this.txtOutput.Text = "";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Khaki;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Khaki;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.byterange,
            this.description,
            this.value,
            this.Result});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(858, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(467, 349);
            this.dataGridView1.TabIndex = 56;
            // 
            // byterange
            // 
            this.byterange.HeaderText = "Byte Range";
            this.byterange.Name = "byterange";
            this.byterange.Width = 50;
            // 
            // description
            // 
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.Width = 150;
            // 
            // value
            // 
            this.value.HeaderText = "Value";
            this.value.Name = "value";
            // 
            // Result
            // 
            this.Result.HeaderText = "result";
            this.Result.Name = "Result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(648, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 19);
            this.label1.TabIndex = 57;
            this.label1.Text = "Attribute Contents ";
            // 
            // lblAttr_name
            // 
            this.lblAttr_name.AutoSize = true;
            this.lblAttr_name.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAttr_name.Location = new System.Drawing.Point(20, 9);
            this.lblAttr_name.Name = "lblAttr_name";
            this.lblAttr_name.Size = new System.Drawing.Size(0, 23);
            this.lblAttr_name.TabIndex = 58;
            // 
            // RunlistGridView
            // 
            this.RunlistGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RunlistGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.I,
            this.StartCluster,
            this.Length});
            this.RunlistGridView.Location = new System.Drawing.Point(652, 34);
            this.RunlistGridView.Name = "RunlistGridView";
            this.RunlistGridView.Size = new System.Drawing.Size(396, 96);
            this.RunlistGridView.TabIndex = 59;
            this.RunlistGridView.Visible = false;
            // 
            // I
            // 
            this.I.HeaderText = " ";
            this.I.Name = "I";
            this.I.Width = 20;
            // 
            // StartCluster
            // 
            this.StartCluster.HeaderText = "Start Cluster No";
            this.StartCluster.Name = "StartCluster";
            // 
            // Length
            // 
            this.Length.HeaderText = "Length of clusters";
            this.Length.Name = "Length";
            // 
            // btnLoadNonResident
            // 
            this.btnLoadNonResident.Location = new System.Drawing.Point(652, 136);
            this.btnLoadNonResident.Name = "btnLoadNonResident";
            this.btnLoadNonResident.Size = new System.Drawing.Size(256, 23);
            this.btnLoadNonResident.TabIndex = 60;
            this.btnLoadNonResident.Text = "Go to Non Resident Contents at RunList 0";
            this.btnLoadNonResident.UseVisualStyleBackColor = true;
            this.btnLoadNonResident.Visible = false;
            this.btnLoadNonResident.Click += new System.EventHandler(this.btnLoadNonResident_Click);
            // 
            // DisplayAttributeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1335, 720);
            this.Controls.Add(this.btnLoadNonResident);
            this.Controls.Add(this.RunlistGridView);
            this.Controls.Add(this.lblAttr_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.txtOutput);
            this.Name = "DisplayAttributeDetails";
            this.Text = "DisplayAttributeDetails";
            this.Load += new System.EventHandler(this.DisplayAttributeDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RunlistGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offsetaddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData00;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData01;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData02;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData03;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData04;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData05;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData06;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData07;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData08;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData09;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData0A;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData0B;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData0C;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData0D;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData0E;
        private System.Windows.Forms.DataGridViewTextBoxColumn HexData0F;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectedValue;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAttr_name;
        private System.Windows.Forms.DataGridView RunlistGridView;
        private System.Windows.Forms.Button btnLoadNonResident;
        private System.Windows.Forms.DataGridViewTextBoxColumn byterange;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn I;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartCluster;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
    }
}