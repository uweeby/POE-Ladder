using System;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.progressCheck = new System.Windows.Forms.CheckBox();
            this.toastCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.launchWithWindows = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toTrayCheck = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
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
            this.timerLabel = new System.Windows.Forms.Label();
            this.upcomingRaces = new System.Windows.Forms.DataGridView();
            this.returnButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.maximizeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.seasonSelector = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.LadderTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathTable)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonPoints)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upcomingRaces)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.autoRefreshCheckBox.Checked = true;
            this.autoRefreshCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
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
            dataGridViewCellStyle50.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.LadderTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle50;
            this.LadderTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LadderTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LadderTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LadderTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle51.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LadderTable.DefaultCellStyle = dataGridViewCellStyle51;
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
            dataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.DeathTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle52;
            this.DeathTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeathTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DeathTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.DeathTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DeathTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DeathTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle53.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DeathTable.DefaultCellStyle = dataGridViewCellStyle53;
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
            this.tabPage1.Controls.Add(this.seasonSelector);
            this.tabPage1.Controls.Add(this.progressCheck);
            this.tabPage1.Controls.Add(this.toastCheckBox);
            this.tabPage1.Controls.Add(this.launchWithWindows);
            this.tabPage1.Controls.Add(this.toTrayCheck);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.checkedListBox1);
            this.tabPage1.Controls.Add(this.label12);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(536, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Settings:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(541, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Enable Progress Bar";
            // 
            // progressCheck
            // 
            this.progressCheck.AutoSize = true;
            this.progressCheck.Checked = true;
            this.progressCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.progressCheck.Location = new System.Drawing.Point(682, 99);
            this.progressCheck.Name = "progressCheck";
            this.progressCheck.Size = new System.Drawing.Size(15, 14);
            this.progressCheck.TabIndex = 24;
            this.progressCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.progressCheck.UseVisualStyleBackColor = true;
            // 
            // toastCheckBox
            // 
            this.toastCheckBox.AutoSize = true;
            this.toastCheckBox.Checked = true;
            this.toastCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toastCheckBox.Location = new System.Drawing.Point(682, 77);
            this.toastCheckBox.Name = "toastCheckBox";
            this.toastCheckBox.Size = new System.Drawing.Size(15, 14);
            this.toastCheckBox.TabIndex = 23;
            this.toastCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toastCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(541, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Enable Toast Notifications";
            // 
            // launchWithWindows
            // 
            this.launchWithWindows.AutoSize = true;
            this.launchWithWindows.Location = new System.Drawing.Point(682, 54);
            this.launchWithWindows.Name = "launchWithWindows";
            this.launchWithWindows.Size = new System.Drawing.Size(15, 14);
            this.launchWithWindows.TabIndex = 21;
            this.launchWithWindows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.launchWithWindows.UseVisualStyleBackColor = true;
            this.launchWithWindows.CheckedChanged += new System.EventHandler(this.launchWithWindows_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(541, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Launch with windows";
            // 
            // toTrayCheck
            // 
            this.toTrayCheck.AutoSize = true;
            this.toTrayCheck.Location = new System.Drawing.Point(682, 32);
            this.toTrayCheck.Name = "toTrayCheck";
            this.toTrayCheck.Size = new System.Drawing.Size(15, 14);
            this.toTrayCheck.TabIndex = 19;
            this.toTrayCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toTrayCheck.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(541, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Minimize to tray";
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
            this.currentURL.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.currentURL_LinkClicked);
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
            this.trackBox.Text = "Miinistry";
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
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle54.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle54.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.seasonPoints.DefaultCellStyle = dataGridViewCellStyle54;
            this.seasonPoints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.seasonPoints.Location = new System.Drawing.Point(883, 26);
            this.seasonPoints.MultiSelect = false;
            this.seasonPoints.Name = "seasonPoints";
            this.seasonPoints.ReadOnly = true;
            this.seasonPoints.RowHeadersVisible = false;
            this.seasonPoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.seasonPoints.Size = new System.Drawing.Size(174, 94);
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
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.upcomingRaces.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle55;
            this.upcomingRaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.upcomingRaces.BackgroundColor = System.Drawing.SystemColors.Control;
            this.upcomingRaces.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.upcomingRaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle56.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.upcomingRaces.DefaultCellStyle = dataGridViewCellStyle56;
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
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.maximizeItem,
            this.exitItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.Item_Click);
            this.contextMenuStrip1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_Click);
            this.contextMenuStrip1.MouseLeave += new System.EventHandler(this.contextMenuStrip1_MouseLeave);
            // 
            // maximizeItem
            // 
            this.maximizeItem.Name = "maximizeItem";
            this.maximizeItem.Size = new System.Drawing.Size(124, 22);
            this.maximizeItem.Text = "Maximize";
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(124, 22);
            this.exitItem.Text = "Exit";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(539, 26);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(168, 92);
            this.checkedListBox1.TabIndex = 172;
            // 
            // seasonSelector
            // 
            this.seasonSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seasonSelector.FormattingEnabled = true;
            this.seasonSelector.Items.AddRange(new object[] {
            "Season One",
            "Season Two",
            "Season Three",
            "Season Four",
            "Season Five",
            "Season Six",
            "Season Seven",
            "Season Eight",
            "Season Nine",
            "Season Ten"});
            this.seasonSelector.Location = new System.Drawing.Point(883, 3);
            this.seasonSelector.Name = "seasonSelector";
            this.seasonSelector.Size = new System.Drawing.Size(174, 21);
            this.seasonSelector.TabIndex = 173;
            this.seasonSelector.SelectedIndexChanged += new System.EventHandler(this.seasonSelector_SelectedIndexChanged);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.LadderTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeathTable)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seasonPoints)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upcomingRaces)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem maximizeItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox progressCheck;
        private System.Windows.Forms.CheckBox toastCheckBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox launchWithWindows;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox toTrayCheck;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.ComboBox seasonSelector;

    }
}

