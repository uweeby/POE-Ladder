namespace POELadder
{
    partial class Form1
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.selectladderLabel = new System.Windows.Forms.Label();
            this.ladderselectBox = new System.Windows.Forms.ComboBox();
            this.autoRefreshCheckBox = new System.Windows.Forms.CheckBox();
            this.LadderTable = new System.Windows.Forms.DataGridView();
            this.DeathTable = new System.Windows.Forms.DataGridView();
            this.fifteenSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.oneSecondTimer = new System.Windows.Forms.Timer(this.components);
            this.refreshButton = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.currentURL = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.lockButton = new System.Windows.Forms.Button();
            this.trackBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trackButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.displayAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.seasonPoints = new System.Windows.Forms.DataGridView();
            this.classBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clearBox = new System.Windows.Forms.RichTextBox();
            this.questBox = new System.Windows.Forms.RichTextBox();
            this.pointBox = new System.Windows.Forms.ComboBox();
            this.levelBracket = new System.Windows.Forms.RichTextBox();
            this.topPrizeBox = new System.Windows.Forms.RichTextBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.upcomingRaces = new System.Windows.Forms.DataGridView();
            this.returnButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.oneMinuteTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.toTrayCheck = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.launchWithWindows = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LadderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathTable)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonPoints)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upcomingRaces)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectladderLabel
            // 
            this.selectladderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectladderLabel.AutoSize = true;
            this.selectladderLabel.Location = new System.Drawing.Point(12, 15);
            this.selectladderLabel.Name = "selectladderLabel";
            this.selectladderLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.selectladderLabel.Size = new System.Drawing.Size(76, 13);
            this.selectladderLabel.TabIndex = 151;
            this.selectladderLabel.Text = "Select Ladder:";
            // 
            // ladderselectBox
            // 
            this.ladderselectBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ladderselectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ladderselectBox.FormattingEnabled = true;
            this.ladderselectBox.Location = new System.Drawing.Point(93, 12);
            this.ladderselectBox.Name = "ladderselectBox";
            this.ladderselectBox.Size = new System.Drawing.Size(388, 21);
            this.ladderselectBox.TabIndex = 151;
            this.toolTip1.SetToolTip(this.ladderselectBox, "Select the ladder or race you\'re interested in.");
            this.ladderselectBox.SelectedIndexChanged += new System.EventHandler(this.ladderselectBox_SelectedIndexChanged);
            // 
            // autoRefreshCheckBox
            // 
            this.autoRefreshCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoRefreshCheckBox.AutoSize = true;
            this.autoRefreshCheckBox.Location = new System.Drawing.Point(487, 14);
            this.autoRefreshCheckBox.Name = "autoRefreshCheckBox";
            this.autoRefreshCheckBox.Size = new System.Drawing.Size(48, 17);
            this.autoRefreshCheckBox.TabIndex = 156;
            this.autoRefreshCheckBox.Text = "Auto";
            this.toolTip1.SetToolTip(this.autoRefreshCheckBox, "Enable auto-refreshing of table every 15 seconds");
            this.autoRefreshCheckBox.UseVisualStyleBackColor = true;
            this.autoRefreshCheckBox.CheckedChanged += new System.EventHandler(this.autoRefreshCheckBox_CheckedChanged);
            // 
            // LadderTable
            // 
            this.LadderTable.AllowUserToAddRows = false;
            this.LadderTable.AllowUserToDeleteRows = false;
            this.LadderTable.AllowUserToResizeColumns = false;
            this.LadderTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LadderTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            this.LadderTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LadderTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LadderTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LadderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LadderTable.DefaultCellStyle = dataGridViewCellStyle23;
            this.LadderTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.LadderTable.Location = new System.Drawing.Point(10, 39);
            this.LadderTable.MultiSelect = false;
            this.LadderTable.Name = "LadderTable";
            this.LadderTable.RowHeadersVisible = false;
            this.LadderTable.Size = new System.Drawing.Size(1063, 443);
            this.LadderTable.TabIndex = 149;
            // 
            // DeathTable
            // 
            this.DeathTable.AllowUserToAddRows = false;
            this.DeathTable.AllowUserToDeleteRows = false;
            this.DeathTable.AllowUserToOrderColumns = true;
            this.DeathTable.AllowUserToResizeColumns = false;
            this.DeathTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DeathTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle24;
            this.DeathTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeathTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DeathTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.DeathTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DeathTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeathTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeathTable.DefaultCellStyle = dataGridViewCellStyle25;
            this.DeathTable.Location = new System.Drawing.Point(0, 3);
            this.DeathTable.Name = "DeathTable";
            this.DeathTable.Size = new System.Drawing.Size(1055, 115);
            this.DeathTable.TabIndex = 150;
            // 
            // fifteenSecondTimer
            // 
            this.fifteenSecondTimer.Interval = 15000;
            this.fifteenSecondTimer.Tick += new System.EventHandler(this.fifteenSecondTimer_Tick);
            // 
            // oneSecondTimer
            // 
            this.oneSecondTimer.Enabled = true;
            this.oneSecondTimer.Interval = 1000;
            this.oneSecondTimer.Tick += new System.EventHandler(this.oneSecondTimer_Tick);
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.AutoSize = true;
            this.refreshButton.Location = new System.Drawing.Point(529, 15);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(44, 13);
            this.refreshButton.TabIndex = 167;
            this.refreshButton.TabStop = true;
            this.refreshButton.Text = "Refresh";
            this.toolTip1.SetToolTip(this.refreshButton, "Manually refresh the table");
            this.refreshButton.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.refreshButton_LinkClicked_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.currentURL);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lockButton);
            this.tabPage1.Controls.Add(this.trackBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.trackButton);
            this.tabPage1.Controls.Add(this.resetButton);
            this.tabPage1.Controls.Add(this.displayAmount);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.seasonPoints);
            this.tabPage1.Controls.Add(this.classBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.searchBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1058, 120);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            this.toolTip1.SetToolTip(this.tabPage1, "Filter table results");
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // currentURL
            // 
            this.currentURL.AutoSize = true;
            this.currentURL.Enabled = false;
            this.currentURL.Location = new System.Drawing.Point(76, 89);
            this.currentURL.Name = "currentURL";
            this.currentURL.Size = new System.Drawing.Size(30, 13);
            this.currentURL.TabIndex = 13;
            this.currentURL.TabStop = true;
            this.currentURL.Text = "Here";
            this.currentURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Current Race:";
            // 
            // lockButton
            // 
            this.lockButton.Location = new System.Drawing.Point(444, 36);
            this.lockButton.Name = "lockButton";
            this.lockButton.Size = new System.Drawing.Size(19, 23);
            this.lockButton.TabIndex = 11;
            this.lockButton.Text = "L";
            this.lockButton.UseVisualStyleBackColor = true;
            // 
            // trackBox
            // 
            this.trackBox.Location = new System.Drawing.Point(363, 10);
            this.trackBox.Name = "trackBox";
            this.trackBox.Size = new System.Drawing.Size(100, 20);
            this.trackBox.TabIndex = 10;
            this.trackBox.TextChanged += new System.EventHandler(this.trackBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Track account:";
            // 
            // trackButton
            // 
            this.trackButton.Location = new System.Drawing.Point(363, 36);
            this.trackButton.Name = "trackButton";
            this.trackButton.Size = new System.Drawing.Size(75, 23);
            this.trackButton.TabIndex = 8;
            this.trackButton.Text = "Track";
            this.trackButton.UseVisualStyleBackColor = true;
            this.trackButton.Click += new System.EventHandler(this.trackButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(148, 89);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 7;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // displayAmount
            // 
            this.displayAmount.Location = new System.Drawing.Point(148, 63);
            this.displayAmount.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.displayAmount.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.displayAmount.Name = "displayAmount";
            this.displayAmount.Size = new System.Drawing.Size(58, 20);
            this.displayAmount.TabIndex = 5;
            this.toolTip1.SetToolTip(this.displayAmount, "Minium: 30 Maximum: 200");
            this.displayAmount.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Number of entries to display:";
            // 
            // seasonPoints
            // 
            this.seasonPoints.AllowUserToAddRows = false;
            this.seasonPoints.AllowUserToDeleteRows = false;
            this.seasonPoints.AllowUserToResizeColumns = false;
            this.seasonPoints.AllowUserToResizeRows = false;
            this.seasonPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seasonPoints.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.seasonPoints.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.seasonPoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seasonPoints.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.seasonPoints.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.seasonPoints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.seasonPoints.ColumnHeadersVisible = false;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.seasonPoints.DefaultCellStyle = dataGridViewCellStyle26;
            this.seasonPoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.seasonPoints.Location = new System.Drawing.Point(884, 0);
            this.seasonPoints.MultiSelect = false;
            this.seasonPoints.Name = "seasonPoints";
            this.seasonPoints.ReadOnly = true;
            this.seasonPoints.RowHeadersVisible = false;
            this.seasonPoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.seasonPoints.Size = new System.Drawing.Size(174, 198);
            this.seasonPoints.StandardTab = true;
            this.seasonPoints.TabIndex = 0;
            this.seasonPoints.TabStop = false;
            this.toolTip1.SetToolTip(this.seasonPoints, "Season race ladder");
            this.seasonPoints.Visible = false;
            // 
            // classBox
            // 
            this.classBox.Enabled = false;
            this.classBox.FormattingEnabled = true;
            this.classBox.Items.AddRange(new object[] {
            "All",
            "Duelist",
            "Marauder",
            "Ranger",
            "Shadow",
            "Templar",
            "Witch"});
            this.classBox.Location = new System.Drawing.Point(148, 36);
            this.classBox.Name = "classBox";
            this.classBox.Size = new System.Drawing.Size(123, 21);
            this.classBox.TabIndex = 3;
            this.classBox.Text = "All";
            this.classBox.SelectedIndexChanged += new System.EventHandler(this.classBox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Filter by class:";
            // 
            // searchBox
            // 
            this.searchBox.Enabled = false;
            this.searchBox.Location = new System.Drawing.Point(148, 10);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(123, 20);
            this.searchBox.TabIndex = 1;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search account:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(10, 488);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1066, 146);
            this.tabControl1.TabIndex = 168;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.DeathTable);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1058, 120);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Deaths";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 151;
            this.label3.Text = "Not functioning yet";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clearBox);
            this.tabPage2.Controls.Add(this.questBox);
            this.tabPage2.Controls.Add(this.pointBox);
            this.tabPage2.Controls.Add(this.levelBracket);
            this.tabPage2.Controls.Add(this.topPrizeBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1058, 120);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "Race Information";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clearBox
            // 
            this.clearBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.clearBox.Location = new System.Drawing.Point(827, 3);
            this.clearBox.MaxLength = 2147;
            this.clearBox.Name = "clearBox";
            this.clearBox.ReadOnly = true;
            this.clearBox.Size = new System.Drawing.Size(226, 114);
            this.clearBox.TabIndex = 4;
            this.clearBox.Text = "";
            // 
            // questBox
            // 
            this.questBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.questBox.Location = new System.Drawing.Point(593, 3);
            this.questBox.MaxLength = 2147;
            this.questBox.Name = "questBox";
            this.questBox.ReadOnly = true;
            this.questBox.Size = new System.Drawing.Size(228, 114);
            this.questBox.TabIndex = 3;
            this.questBox.Text = "";
            // 
            // pointBox
            // 
            this.pointBox.FormattingEnabled = true;
            this.pointBox.Items.AddRange(new object[] {
            "1 Hour",
            "2 Hour",
            "3 Hour",
            "4 Hour",
            "1 Week"});
            this.pointBox.Location = new System.Drawing.Point(358, 3);
            this.pointBox.Name = "pointBox";
            this.pointBox.Size = new System.Drawing.Size(229, 21);
            this.pointBox.TabIndex = 2;
            this.pointBox.Text = "Select race type";
            this.pointBox.SelectedIndexChanged += new System.EventHandler(this.pointBox_SelectedIndexChanged);
            // 
            // levelBracket
            // 
            this.levelBracket.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.levelBracket.Location = new System.Drawing.Point(358, 27);
            this.levelBracket.MaxLength = 2147;
            this.levelBracket.Name = "levelBracket";
            this.levelBracket.ReadOnly = true;
            this.levelBracket.Size = new System.Drawing.Size(229, 90);
            this.levelBracket.TabIndex = 1;
            this.levelBracket.Text = "";
            // 
            // topPrizeBox
            // 
            this.topPrizeBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.topPrizeBox.Location = new System.Drawing.Point(4, 3);
            this.topPrizeBox.MaxLength = 2147;
            this.topPrizeBox.Name = "topPrizeBox";
            this.topPrizeBox.ReadOnly = true;
            this.topPrizeBox.Size = new System.Drawing.Size(348, 114);
            this.topPrizeBox.TabIndex = 0;
            this.topPrizeBox.Text = "";
            // 
            // timerLabel
            // 
            this.timerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.Location = new System.Drawing.Point(808, 13);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(268, 18);
            this.timerLabel.TabIndex = 169;
            this.timerLabel.Text = "00:00:00";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // upcomingRaces
            // 
            this.upcomingRaces.AllowUserToAddRows = false;
            this.upcomingRaces.AllowUserToDeleteRows = false;
            this.upcomingRaces.AllowUserToResizeColumns = false;
            this.upcomingRaces.AllowUserToResizeRows = false;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.upcomingRaces.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
            this.upcomingRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingRaces.BackgroundColor = System.Drawing.SystemColors.Control;
            this.upcomingRaces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.upcomingRaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.upcomingRaces.DefaultCellStyle = dataGridViewCellStyle28;
            this.upcomingRaces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.upcomingRaces.GridColor = System.Drawing.SystemColors.Control;
            this.upcomingRaces.Location = new System.Drawing.Point(12, 39);
            this.upcomingRaces.MultiSelect = false;
            this.upcomingRaces.Name = "upcomingRaces";
            this.upcomingRaces.ReadOnly = true;
            this.upcomingRaces.RowHeadersVisible = false;
            this.upcomingRaces.Size = new System.Drawing.Size(1063, 443);
            this.upcomingRaces.TabIndex = 170;
            // 
            // returnButton
            // 
            this.returnButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnButton.Location = new System.Drawing.Point(579, 9);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(103, 25);
            this.returnButton.TabIndex = 171;
            this.returnButton.Text = "Back to overview";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Visible = false;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "POE L&L";
            this.notifyIcon1.Visible = true;
            // 
            // oneMinuteTimer
            // 
            this.oneMinuteTimer.Enabled = true;
            this.oneMinuteTimer.Interval = 60000;
            this.oneMinuteTimer.Tick += new System.EventHandler(this.oneMinuteTimer_Tick);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.checkBox1);
            this.tabPage4.Controls.Add(this.label9);
            this.tabPage4.Controls.Add(this.launchWithWindows);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.toTrayCheck);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1058, 120);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Minimize to tray";
            // 
            // toTrayCheck
            // 
            this.toTrayCheck.AutoSize = true;
            this.toTrayCheck.Location = new System.Drawing.Point(153, 14);
            this.toTrayCheck.Name = "toTrayCheck";
            this.toTrayCheck.Size = new System.Drawing.Size(15, 14);
            this.toTrayCheck.TabIndex = 1;
            this.toTrayCheck.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Launch with windows";
            // 
            // launchWithWindows
            // 
            this.launchWithWindows.AutoSize = true;
            this.launchWithWindows.Location = new System.Drawing.Point(153, 36);
            this.launchWithWindows.Name = "launchWithWindows";
            this.launchWithWindows.Size = new System.Drawing.Size(15, 14);
            this.launchWithWindows.TabIndex = 3;
            this.launchWithWindows.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Enable Toast Notifications";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(153, 59);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Enabled = false;
            this.label10.Location = new System.Drawing.Point(1027, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "v1.0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.refreshButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1092, 646);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.upcomingRaces);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.LadderTable);
            this.Controls.Add(this.autoRefreshCheckBox);
            this.Controls.Add(this.selectladderLabel);
            this.Controls.Add(this.ladderselectBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Path of Exile League and Race Ladder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LadderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathTable)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonPoints)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upcomingRaces)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label selectladderLabel;
        private System.Windows.Forms.CheckBox autoRefreshCheckBox;
        public System.Windows.Forms.DataGridView LadderTable;
        private System.Windows.Forms.DataGridView DeathTable;
        private System.Windows.Forms.Timer fifteenSecondTimer;
        private System.Windows.Forms.Timer oneSecondTimer;
        private System.Windows.Forms.LinkLabel refreshButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox classBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.TabPage tabPage3;
        public System.Windows.Forms.DataGridView seasonPoints;
        private System.Windows.Forms.NumericUpDown displayAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox topPrizeBox;
        private System.Windows.Forms.ComboBox pointBox;
        private System.Windows.Forms.RichTextBox levelBracket;
        private System.Windows.Forms.RichTextBox clearBox;
        private System.Windows.Forms.RichTextBox questBox;
        public System.Windows.Forms.DataGridView upcomingRaces;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button trackButton;
        public System.Windows.Forms.ComboBox ladderselectBox;
        private System.Windows.Forms.Button lockButton;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox trackBox;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.LinkLabel currentURL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer oneMinuteTimer;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox toTrayCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox launchWithWindows;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;

    }
}

