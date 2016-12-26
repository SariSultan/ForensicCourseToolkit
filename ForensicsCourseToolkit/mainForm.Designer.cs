namespace ForensicsCourseToolkit
{
    partial class mainFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainFrm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.aboutBtn = new System.Windows.Forms.RibbonOrbMenuItem();
            this.exitBtn = new System.Windows.Forms.RibbonOrbOptionButton();
            this.fileSystemsTab = new System.Windows.Forms.RibbonTab();
            this.MBRTab = new System.Windows.Forms.RibbonPanel();
            this.MbrFrmBtn = new System.Windows.Forms.RibbonButton();
            this.ToolsTab = new System.Windows.Forms.RibbonTab();
            this.HexEditorPnl = new System.Windows.Forms.RibbonPanel();
            this.beHexEditorBtn = new System.Windows.Forms.RibbonButton();
            this.ConvertersPnl = new System.Windows.Forms.RibbonPanel();
            this.convertersBtn = new System.Windows.Forms.RibbonButton();
            this.ConfigTabs = new System.Windows.Forms.RibbonTab();
            this.msgLvlPnl = new System.Windows.Forms.RibbonPanel();
            this.debugMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.verboseMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.ErrorMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.WarningMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.aTabControl = new FlatTabControl.FlatTabControl();
            this.MaximizeTPTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CollapseRibbonBtn = new System.Windows.Forms.Button();
            this.ExitSelectedTabBtn = new System.Windows.Forms.Button();
            this.fatRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.fatBootSectorBtn = new System.Windows.Forms.RibbonButton();
            this.fatBtn2 = new System.Windows.Forms.RibbonButton();
            this.NTFSRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.NTFSBootSecotrBtn = new System.Windows.Forms.RibbonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.aboutBtn);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.OptionItems.Add(this.exitBtn);
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 116);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "FCT_KU";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1056, 194);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.fileSystemsTab);
            this.ribbon1.Tabs.Add(this.ToolsTab);
            this.ribbon1.Tabs.Add(this.ConfigTabs);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "sari";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // aboutBtn
            // 
            this.aboutBtn.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.aboutBtn.Image = ((System.Drawing.Image)(resources.GetObject("aboutBtn.Image")));
            this.aboutBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.SmallImage")));
            this.aboutBtn.Text = "About";
            this.aboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.SmallImage")));
            this.exitBtn.Text = "Exit";
            // 
            // fileSystemsTab
            // 
            this.fileSystemsTab.Panels.Add(this.MBRTab);
            this.fileSystemsTab.Panels.Add(this.fatRibbonPanel);
            this.fileSystemsTab.Panels.Add(this.NTFSRibbonPanel);
            this.fileSystemsTab.Text = "File Systems";
            // 
            // MBRTab
            // 
            this.MBRTab.Items.Add(this.MbrFrmBtn);
            this.MBRTab.Text = "MBR Section";
            // 
            // MbrFrmBtn
            // 
            this.MbrFrmBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.MbrIcon1;
            this.MbrFrmBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("MbrFrmBtn.SmallImage")));
            this.MbrFrmBtn.Text = "MBR";
            this.MbrFrmBtn.Click += new System.EventHandler(this.MbrFrmBtn_Click);
            // 
            // ToolsTab
            // 
            this.ToolsTab.Panels.Add(this.HexEditorPnl);
            this.ToolsTab.Panels.Add(this.ConvertersPnl);
            this.ToolsTab.Text = "Tools";
            // 
            // HexEditorPnl
            // 
            this.HexEditorPnl.Items.Add(this.beHexEditorBtn);
            this.HexEditorPnl.Text = "Hex Editors";
            // 
            // beHexEditorBtn
            // 
            this.beHexEditorBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.BeHexEditorLogo;
            this.beHexEditorBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("beHexEditorBtn.SmallImage")));
            this.beHexEditorBtn.Text = "Be.HexEditor";
            this.beHexEditorBtn.Click += new System.EventHandler(this.beHexEditorBtn_Click);
            // 
            // ConvertersPnl
            // 
            this.ConvertersPnl.Items.Add(this.convertersBtn);
            this.ConvertersPnl.Text = "Converters";
            // 
            // convertersBtn
            // 
            this.convertersBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.ConvertersIcon;
            this.convertersBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("convertersBtn.SmallImage")));
            this.convertersBtn.Text = "Converters";
            this.convertersBtn.Click += new System.EventHandler(this.convertersBtn_Click);
            // 
            // ConfigTabs
            // 
            this.ConfigTabs.Panels.Add(this.msgLvlPnl);
            this.ConfigTabs.Text = "Configurations";
            // 
            // msgLvlPnl
            // 
            this.msgLvlPnl.Items.Add(this.debugMsgChkBox);
            this.msgLvlPnl.Items.Add(this.verboseMsgChkBox);
            this.msgLvlPnl.Items.Add(this.ErrorMsgChkBox);
            this.msgLvlPnl.Items.Add(this.WarningMsgChkBox);
            this.msgLvlPnl.Text = "Messages to show";
            // 
            // debugMsgChkBox
            // 
            this.debugMsgChkBox.Text = "Show Debug Messages";
            this.debugMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.debugMsgChkBox_CheckBoxCheckChanged);
            // 
            // verboseMsgChkBox
            // 
            this.verboseMsgChkBox.Text = "Show Verbose Messages";
            this.verboseMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.verboseMsgChkBox_CheckBoxCheckChanged);
            // 
            // ErrorMsgChkBox
            // 
            this.ErrorMsgChkBox.Text = "Show Error Messages";
            this.ErrorMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.ErrorMsgChkBox_CheckBoxCheckChanged);
            // 
            // WarningMsgChkBox
            // 
            this.WarningMsgChkBox.Text = "Show Warning Messages";
            this.WarningMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.WarningMsgChkBox_CheckBoxCheckChanged);
            // 
            // aTabControl
            // 
            this.aTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aTabControl.ItemSize = new System.Drawing.Size(0, 40);
            this.aTabControl.Location = new System.Drawing.Point(0, 194);
            this.aTabControl.myBackColor = System.Drawing.SystemColors.Control;
            this.aTabControl.Name = "aTabControl";
            this.aTabControl.SelectedIndex = 0;
            this.aTabControl.Size = new System.Drawing.Size(1056, 408);
            this.aTabControl.TabIndex = 2;
            this.aTabControl.SelectedIndexChanged += new System.EventHandler(this.aTabControl_SelectedIndexChanged);
            // 
            // MaximizeTPTimer
            // 
            this.MaximizeTPTimer.Interval = 50;
            this.MaximizeTPTimer.Tick += new System.EventHandler(this.MaximizeTPTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::ForensicsCourseToolkit.Properties.Resources.FCTBackground;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 194);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1056, 408);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // CollapseRibbonBtn
            // 
            this.CollapseRibbonBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollapseRibbonBtn.BackColor = System.Drawing.Color.Transparent;
            this.CollapseRibbonBtn.BackgroundImage = global::ForensicsCourseToolkit.Properties.Resources.Down_Arrow;
            this.CollapseRibbonBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CollapseRibbonBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CollapseRibbonBtn.FlatAppearance.BorderSize = 0;
            this.CollapseRibbonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollapseRibbonBtn.Location = new System.Drawing.Point(999, 29);
            this.CollapseRibbonBtn.Name = "CollapseRibbonBtn";
            this.CollapseRibbonBtn.Size = new System.Drawing.Size(20, 20);
            this.CollapseRibbonBtn.TabIndex = 7;
            this.CollapseRibbonBtn.UseVisualStyleBackColor = false;
            this.CollapseRibbonBtn.Click += new System.EventHandler(this.CollapseRibbonBtn_Click);
            // 
            // ExitSelectedTabBtn
            // 
            this.ExitSelectedTabBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitSelectedTabBtn.BackColor = System.Drawing.Color.White;
            this.ExitSelectedTabBtn.BackgroundImage = global::ForensicsCourseToolkit.Properties.Resources.x_ribbon;
            this.ExitSelectedTabBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitSelectedTabBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitSelectedTabBtn.FlatAppearance.BorderSize = 0;
            this.ExitSelectedTabBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitSelectedTabBtn.Location = new System.Drawing.Point(1024, 29);
            this.ExitSelectedTabBtn.Name = "ExitSelectedTabBtn";
            this.ExitSelectedTabBtn.Size = new System.Drawing.Size(20, 20);
            this.ExitSelectedTabBtn.TabIndex = 6;
            this.ExitSelectedTabBtn.UseVisualStyleBackColor = false;
            this.ExitSelectedTabBtn.Click += new System.EventHandler(this.ExitSelectedTabBtn_Click_1);
            // 
            // fatRibbonPanel
            // 
            this.fatRibbonPanel.Items.Add(this.fatBootSectorBtn);
            this.fatRibbonPanel.Items.Add(this.fatBtn2);
            this.fatRibbonPanel.Text = "FAT";
            // 
            // fatBootSectorBtn
            // 
            this.fatBootSectorBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.BootSectorIcon;
            this.fatBootSectorBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("fatBootSectorBtn.SmallImage")));
            this.fatBootSectorBtn.Text = "Boo Sector";
            this.fatBootSectorBtn.Click += new System.EventHandler(this.BootSectorBtn_Click);
            // 
            // fatBtn2
            // 
            this.fatBtn2.Image = global::ForensicsCourseToolkit.Properties.Resources.FatIcon1;
            this.fatBtn2.SmallImage = ((System.Drawing.Image)(resources.GetObject("fatBtn2.SmallImage")));
            this.fatBtn2.Text = "FAT";
            this.fatBtn2.Click += new System.EventHandler(this.FatBtn_Click);
            // 
            // NTFSRibbonPanel
            // 
            this.NTFSRibbonPanel.Items.Add(this.NTFSBootSecotrBtn);
            this.NTFSRibbonPanel.Text = "NTFS";
            // 
            // NTFSBootSecotrBtn
            // 
            this.NTFSBootSecotrBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.BootSectorIcon;
            this.NTFSBootSecotrBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("NTFSBootSecotrBtn.SmallImage")));
            this.NTFSBootSecotrBtn.Text = "Boot Sector";
            this.NTFSBootSecotrBtn.Click += new System.EventHandler(this.NTFSBootSecotrBtn_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1056, 602);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CollapseRibbonBtn);
            this.Controls.Add(this.ExitSelectedTabBtn);
            this.Controls.Add(this.aTabControl);
            this.Controls.Add(this.ribbon1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainFrm";
            this.Text = "Forensics Course Toolkit - Kuwait University";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab fileSystemsTab;
        private System.Windows.Forms.RibbonPanel MBRTab;
        private System.Windows.Forms.RibbonTab ConfigTabs;
        private System.Windows.Forms.RibbonOrbOptionButton infoBtn;
        private System.Windows.Forms.RibbonOrbOptionButton exitBtn;

        private FlatTabControl.FlatTabControl aTabControl;
        private System.Windows.Forms.Button CollapseRibbonBtn;
        private System.Windows.Forms.Button ExitSelectedTabBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RibbonButton MbrFrmBtn;
        private System.Windows.Forms.Timer MaximizeTPTimer;
        private System.Windows.Forms.RibbonPanel msgLvlPnl;
        private System.Windows.Forms.RibbonCheckBox debugMsgChkBox;
        private System.Windows.Forms.RibbonCheckBox verboseMsgChkBox;
        private System.Windows.Forms.RibbonCheckBox ErrorMsgChkBox;
        private System.Windows.Forms.RibbonCheckBox WarningMsgChkBox;
        private System.Windows.Forms.RibbonTab ToolsTab;
        private System.Windows.Forms.RibbonPanel HexEditorPnl;
        private System.Windows.Forms.RibbonButton beHexEditorBtn;
        private System.Windows.Forms.RibbonOrbMenuItem aboutBtn;
        private System.Windows.Forms.RibbonPanel ConvertersPnl;
        private System.Windows.Forms.RibbonButton convertersBtn;
        private System.Windows.Forms.RibbonPanel fatRibbonPanel;
        private System.Windows.Forms.RibbonButton fatBootSectorBtn;
        private System.Windows.Forms.RibbonButton fatBtn2;
        private System.Windows.Forms.RibbonPanel NTFSRibbonPanel;
        private System.Windows.Forms.RibbonButton NTFSBootSecotrBtn;
    }
}