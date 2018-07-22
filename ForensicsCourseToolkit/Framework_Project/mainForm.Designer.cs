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
            this.fileSystemsTab = new System.Windows.Forms.RibbonTab();
            this.MBRTab = new System.Windows.Forms.RibbonPanel();
            this.fatRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.NTFSRibbonPanel = new System.Windows.Forms.RibbonPanel();
            this.ToolsTab = new System.Windows.Forms.RibbonTab();
            this.HexEditorPnl = new System.Windows.Forms.RibbonPanel();
            this.ConvertersPnl = new System.Windows.Forms.RibbonPanel();
            this.ConfigTabs = new System.Windows.Forms.RibbonTab();
            this.msgLvlPnl = new System.Windows.Forms.RibbonPanel();
            this.debugMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.verboseMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.ErrorMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.WarningMsgChkBox = new System.Windows.Forms.RibbonCheckBox();
            this.examinationTab = new System.Windows.Forms.RibbonTab();
            this.InstructorExaminationPanel = new System.Windows.Forms.RibbonPanel();
            this.examTakerPanel = new System.Windows.Forms.RibbonPanel();
            this.aTabControl = new FlatTabControl.FlatTabControl();
            this.MaximizeTPTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.RichTextBox();
            this.CollapseRibbonBtn = new System.Windows.Forms.Button();
            this.ExitSelectedTabBtn = new System.Windows.Forms.Button();
            this.aboutBtn = new System.Windows.Forms.RibbonOrbMenuItem();
            this.exitBtn = new System.Windows.Forms.RibbonOrbOptionButton();
            this.MbrFrmBtn = new System.Windows.Forms.RibbonButton();
            this.fatBootSectorBtn = new System.Windows.Forms.RibbonButton();
            this.fatBtn2 = new System.Windows.Forms.RibbonButton();
            this.fatExamMakerBtn = new System.Windows.Forms.RibbonButton();
            this.NTFSBootSecotrBtn = new System.Windows.Forms.RibbonButton();
            this.NTFSFirstImpBtn = new System.Windows.Forms.RibbonButton();
            this.NTFSLearningBtn = new System.Windows.Forms.RibbonButton();
            this.beHexEditorBtn = new System.Windows.Forms.RibbonButton();
            this.convertersBtn = new System.Windows.Forms.RibbonButton();
            this.examServerBtn = new System.Windows.Forms.RibbonButton();
            this.examGradingBtn = new System.Windows.Forms.RibbonButton();
            this.examTakingWindowBtn = new System.Windows.Forms.RibbonButton();
            this.examFromFileBtn = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Margin = new System.Windows.Forms.Padding(4);
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
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.OrbText = "FCT_KU";
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1006, 200);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.fileSystemsTab);
            this.ribbon1.Tabs.Add(this.ToolsTab);
            this.ribbon1.Tabs.Add(this.ConfigTabs);
            this.ribbon1.Tabs.Add(this.examinationTab);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(5, 26, 20, 0);
            this.ribbon1.TabSpacing = 4;
            this.ribbon1.Text = "sari";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // fileSystemsTab
            // 
            this.fileSystemsTab.Name = "fileSystemsTab";
            this.fileSystemsTab.Panels.Add(this.MBRTab);
            this.fileSystemsTab.Panels.Add(this.fatRibbonPanel);
            this.fileSystemsTab.Panels.Add(this.NTFSRibbonPanel);
            this.fileSystemsTab.Text = "File Systems";
            // 
            // MBRTab
            // 
            this.MBRTab.Items.Add(this.MbrFrmBtn);
            this.MBRTab.Name = "MBRTab";
            this.MBRTab.Text = "MBR Section";
            // 
            // fatRibbonPanel
            // 
            this.fatRibbonPanel.Items.Add(this.fatBootSectorBtn);
            this.fatRibbonPanel.Items.Add(this.fatBtn2);
            this.fatRibbonPanel.Items.Add(this.fatExamMakerBtn);
            this.fatRibbonPanel.Name = "fatRibbonPanel";
            this.fatRibbonPanel.Text = "FAT";
            // 
            // NTFSRibbonPanel
            // 
            this.NTFSRibbonPanel.Items.Add(this.NTFSBootSecotrBtn);
            this.NTFSRibbonPanel.Items.Add(this.NTFSFirstImpBtn);
            this.NTFSRibbonPanel.Items.Add(this.NTFSLearningBtn);
            this.NTFSRibbonPanel.Name = "NTFSRibbonPanel";
            this.NTFSRibbonPanel.Text = "NTFS";
            // 
            // ToolsTab
            // 
            this.ToolsTab.Name = "ToolsTab";
            this.ToolsTab.Panels.Add(this.HexEditorPnl);
            this.ToolsTab.Panels.Add(this.ConvertersPnl);
            this.ToolsTab.Text = "Tools";
            // 
            // HexEditorPnl
            // 
            this.HexEditorPnl.Items.Add(this.beHexEditorBtn);
            this.HexEditorPnl.Name = "HexEditorPnl";
            this.HexEditorPnl.Text = "Hex Editors";
            // 
            // ConvertersPnl
            // 
            this.ConvertersPnl.Items.Add(this.convertersBtn);
            this.ConvertersPnl.Name = "ConvertersPnl";
            this.ConvertersPnl.Text = "Converters";
            // 
            // ConfigTabs
            // 
            this.ConfigTabs.Name = "ConfigTabs";
            this.ConfigTabs.Panels.Add(this.msgLvlPnl);
            this.ConfigTabs.Text = "Configurations";
            // 
            // msgLvlPnl
            // 
            this.msgLvlPnl.Items.Add(this.debugMsgChkBox);
            this.msgLvlPnl.Items.Add(this.verboseMsgChkBox);
            this.msgLvlPnl.Items.Add(this.ErrorMsgChkBox);
            this.msgLvlPnl.Items.Add(this.WarningMsgChkBox);
            this.msgLvlPnl.Name = "msgLvlPnl";
            this.msgLvlPnl.Text = "Messages to show";
            // 
            // debugMsgChkBox
            // 
            this.debugMsgChkBox.Name = "debugMsgChkBox";
            this.debugMsgChkBox.Text = "Show Debug Messages";
            this.debugMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.debugMsgChkBox_CheckBoxCheckChanged);
            // 
            // verboseMsgChkBox
            // 
            this.verboseMsgChkBox.Name = "verboseMsgChkBox";
            this.verboseMsgChkBox.Text = "Show Verbose Messages";
            this.verboseMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.verboseMsgChkBox_CheckBoxCheckChanged);
            // 
            // ErrorMsgChkBox
            // 
            this.ErrorMsgChkBox.Name = "ErrorMsgChkBox";
            this.ErrorMsgChkBox.Text = "Show Error Messages";
            this.ErrorMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.ErrorMsgChkBox_CheckBoxCheckChanged);
            // 
            // WarningMsgChkBox
            // 
            this.WarningMsgChkBox.Name = "WarningMsgChkBox";
            this.WarningMsgChkBox.Text = "Show Warning Messages";
            this.WarningMsgChkBox.CheckBoxCheckChanged += new System.EventHandler(this.WarningMsgChkBox_CheckBoxCheckChanged);
            // 
            // examinationTab
            // 
            this.examinationTab.Name = "examinationTab";
            this.examinationTab.Panels.Add(this.InstructorExaminationPanel);
            this.examinationTab.Panels.Add(this.examTakerPanel);
            this.examinationTab.Text = "Examination Center";
            // 
            // InstructorExaminationPanel
            // 
            this.InstructorExaminationPanel.Items.Add(this.examServerBtn);
            this.InstructorExaminationPanel.Items.Add(this.examGradingBtn);
            this.InstructorExaminationPanel.Name = "InstructorExaminationPanel";
            this.InstructorExaminationPanel.Text = "Instructor Section";
            // 
            // examTakerPanel
            // 
            this.examTakerPanel.Items.Add(this.examTakingWindowBtn);
            this.examTakerPanel.Items.Add(this.examFromFileBtn);
            this.examTakerPanel.Name = "examTakerPanel";
            this.examTakerPanel.Text = "Student Panel ";
            // 
            // aTabControl
            // 
            this.aTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aTabControl.ItemSize = new System.Drawing.Size(0, 40);
            this.aTabControl.Location = new System.Drawing.Point(0, 200);
            this.aTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.aTabControl.myBackColor = System.Drawing.SystemColors.Control;
            this.aTabControl.Name = "aTabControl";
            this.aTabControl.SelectedIndex = 0;
            this.aTabControl.Size = new System.Drawing.Size(1006, 523);
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
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 200);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.ReadOnly = true;
            this.pictureBox1.Size = new System.Drawing.Size(1006, 523);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.Text = "";
            // 
            // CollapseRibbonBtn
            // 
            this.CollapseRibbonBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CollapseRibbonBtn.BackColor = System.Drawing.Color.Transparent;
            this.CollapseRibbonBtn.BackgroundImage = global::ForensicsCourseToolkit.Properties.Resources.Down_Arrow;
            this.CollapseRibbonBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CollapseRibbonBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CollapseRibbonBtn.FlatAppearance.BorderSize = 0;
            this.CollapseRibbonBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CollapseRibbonBtn.Location = new System.Drawing.Point(941, 31);
            this.CollapseRibbonBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CollapseRibbonBtn.Name = "CollapseRibbonBtn";
            this.CollapseRibbonBtn.Size = new System.Drawing.Size(27, 25);
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
            this.ExitSelectedTabBtn.Location = new System.Drawing.Point(976, 31);
            this.ExitSelectedTabBtn.Margin = new System.Windows.Forms.Padding(4);
            this.ExitSelectedTabBtn.Name = "ExitSelectedTabBtn";
            this.ExitSelectedTabBtn.Size = new System.Drawing.Size(27, 25);
            this.ExitSelectedTabBtn.TabIndex = 6;
            this.ExitSelectedTabBtn.UseVisualStyleBackColor = false;
            this.ExitSelectedTabBtn.Click += new System.EventHandler(this.ExitSelectedTabBtn_Click_1);
            // 
            // aboutBtn
            // 
            this.aboutBtn.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.aboutBtn.Image = ((System.Drawing.Image)(resources.GetObject("aboutBtn.Image")));
            this.aboutBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.LargeImage")));
            this.aboutBtn.Name = "aboutBtn";
            this.aboutBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("aboutBtn.SmallImage")));
            this.aboutBtn.Text = "About";
            this.aboutBtn.Click += new System.EventHandler(this.AboutBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.LargeImage")));
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("exitBtn.SmallImage")));
            this.exitBtn.Text = "Exit";
            // 
            // MbrFrmBtn
            // 
            this.MbrFrmBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.MbrIcon1;
            this.MbrFrmBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.MbrIcon1;
            this.MbrFrmBtn.Name = "MbrFrmBtn";
            this.MbrFrmBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("MbrFrmBtn.SmallImage")));
            this.MbrFrmBtn.Text = "";
            this.MbrFrmBtn.Click += new System.EventHandler(this.MbrFrmBtn_Click);
            // 
            // fatBootSectorBtn
            // 
            this.fatBootSectorBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.BootSectorIcon;
            this.fatBootSectorBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.BootSectorIcon;
            this.fatBootSectorBtn.Name = "fatBootSectorBtn";
            this.fatBootSectorBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("fatBootSectorBtn.SmallImage")));
            this.fatBootSectorBtn.Text = "";
            this.fatBootSectorBtn.Click += new System.EventHandler(this.BootSectorBtn_Click);
            // 
            // fatBtn2
            // 
            this.fatBtn2.Image = global::ForensicsCourseToolkit.Properties.Resources.FatIcon1;
            this.fatBtn2.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.FatIcon1;
            this.fatBtn2.Name = "fatBtn2";
            this.fatBtn2.SmallImage = ((System.Drawing.Image)(resources.GetObject("fatBtn2.SmallImage")));
            this.fatBtn2.Text = "";
            this.fatBtn2.Click += new System.EventHandler(this.FatBtn_Click);
            // 
            // fatExamMakerBtn
            // 
            this.fatExamMakerBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.QuizMakerIcon;
            this.fatExamMakerBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.QuizMakerIcon;
            this.fatExamMakerBtn.Name = "fatExamMakerBtn";
            this.fatExamMakerBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("fatExamMakerBtn.SmallImage")));
            this.fatExamMakerBtn.Click += new System.EventHandler(this.fatExamMakerBtn_Click);
            // 
            // NTFSBootSecotrBtn
            // 
            this.NTFSBootSecotrBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.BootSectorIcon;
            this.NTFSBootSecotrBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.BootSectorIcon;
            this.NTFSBootSecotrBtn.Name = "NTFSBootSecotrBtn";
            this.NTFSBootSecotrBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("NTFSBootSecotrBtn.SmallImage")));
            this.NTFSBootSecotrBtn.Text = "";
            this.NTFSBootSecotrBtn.Click += new System.EventHandler(this.NTFSBootSecotrBtn_Click);
            // 
            // NTFSFirstImpBtn
            // 
            this.NTFSFirstImpBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.NTFSIcon;
            this.NTFSFirstImpBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.NTFSIcon;
            this.NTFSFirstImpBtn.Name = "NTFSFirstImpBtn";
            this.NTFSFirstImpBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("NTFSFirstImpBtn.SmallImage")));
            this.NTFSFirstImpBtn.Text = "";
            this.NTFSFirstImpBtn.Click += new System.EventHandler(this.NTFSFirstImpBtn_Click);
            // 
            // NTFSLearningBtn
            // 
            this.NTFSLearningBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.ntfslearningIcon;
            this.NTFSLearningBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.ntfslearningIcon;
            this.NTFSLearningBtn.Name = "NTFSLearningBtn";
            this.NTFSLearningBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("NTFSLearningBtn.SmallImage")));
            this.NTFSLearningBtn.Text = "";
            this.NTFSLearningBtn.Click += new System.EventHandler(this.NTFSLearningBtn_Click);
            // 
            // beHexEditorBtn
            // 
            this.beHexEditorBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.BeHexEditorLogo;
            this.beHexEditorBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.BeHexEditorLogo;
            this.beHexEditorBtn.Name = "beHexEditorBtn";
            this.beHexEditorBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("beHexEditorBtn.SmallImage")));
            this.beHexEditorBtn.Text = "Be.HexEditor";
            this.beHexEditorBtn.Click += new System.EventHandler(this.beHexEditorBtn_Click);
            // 
            // convertersBtn
            // 
            this.convertersBtn.Image = global::ForensicsCourseToolkit.Properties.Resources.ConvertersIcon;
            this.convertersBtn.LargeImage = global::ForensicsCourseToolkit.Properties.Resources.ConvertersIcon;
            this.convertersBtn.Name = "convertersBtn";
            this.convertersBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("convertersBtn.SmallImage")));
            this.convertersBtn.Text = "Converters";
            this.convertersBtn.Click += new System.EventHandler(this.convertersBtn_Click);
            // 
            // examServerBtn
            // 
            this.examServerBtn.Image = ((System.Drawing.Image)(resources.GetObject("examServerBtn.Image")));
            this.examServerBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examServerBtn.LargeImage")));
            this.examServerBtn.Name = "examServerBtn";
            this.examServerBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examServerBtn.SmallImage")));
            this.examServerBtn.Text = "";
            this.examServerBtn.Click += new System.EventHandler(this.examServerBtn_Click);
            // 
            // examGradingBtn
            // 
            this.examGradingBtn.Image = ((System.Drawing.Image)(resources.GetObject("examGradingBtn.Image")));
            this.examGradingBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examGradingBtn.LargeImage")));
            this.examGradingBtn.Name = "examGradingBtn";
            this.examGradingBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examGradingBtn.SmallImage")));
            this.examGradingBtn.Text = "";
            this.examGradingBtn.Click += new System.EventHandler(this.examGradingBtn_Click);
            // 
            // examTakingWindowBtn
            // 
            this.examTakingWindowBtn.Image = ((System.Drawing.Image)(resources.GetObject("examTakingWindowBtn.Image")));
            this.examTakingWindowBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examTakingWindowBtn.LargeImage")));
            this.examTakingWindowBtn.Name = "examTakingWindowBtn";
            this.examTakingWindowBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examTakingWindowBtn.SmallImage")));
            this.examTakingWindowBtn.Text = "";
            this.examTakingWindowBtn.Click += new System.EventHandler(this.examTakingWindowBtn_Click);
            // 
            // examFromFileBtn
            // 
            this.examFromFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("examFromFileBtn.Image")));
            this.examFromFileBtn.LargeImage = ((System.Drawing.Image)(resources.GetObject("examFromFileBtn.LargeImage")));
            this.examFromFileBtn.Name = "examFromFileBtn";
            this.examFromFileBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("examFromFileBtn.SmallImage")));
            this.examFromFileBtn.Text = "";
            this.examFromFileBtn.Click += new System.EventHandler(this.examFromFileBtn_Click);
            // 
            // mainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1006, 723);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CollapseRibbonBtn);
            this.Controls.Add(this.ExitSelectedTabBtn);
            this.Controls.Add(this.aTabControl);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "mainFrm";
            this.Text = "Forensics Course Toolkit (FCT)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.RibbonButton NTFSLearningBtn;
        private System.Windows.Forms.RichTextBox pictureBox1;
        private System.Windows.Forms.RibbonTab examinationTab;
        private System.Windows.Forms.RibbonPanel InstructorExaminationPanel;
        private System.Windows.Forms.RibbonButton examServerBtn;
        private System.Windows.Forms.RibbonPanel examTakerPanel;
        private System.Windows.Forms.RibbonButton examTakingWindowBtn;
        private System.Windows.Forms.RibbonButton examFromFileBtn;
        private System.Windows.Forms.RibbonButton examGradingBtn;
        private System.Windows.Forms.RibbonButton fatExamMakerBtn;
        private System.Windows.Forms.RibbonButton NTFSFirstImpBtn;
    }
}