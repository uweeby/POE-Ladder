using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;
using PoELadder.JSON;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Notifications;

namespace POELadder
{
    public partial class Form1 : Form
    {
        LeagueList[] POELadderAll, raceData;
        private SeasonTable[] seaLadder;

        public List<PlayerDB> playerDB = new List<PlayerDB>();
        List<ScheduledToastNotification> raceNotificationList;
        readonly List<string> URLs = new List<string>();

        public string selectedLadderURL, trackAccount;

        private bool secondsSet = false;

        Form2 f2; 

        DateTime LastUpdateCache = DateTime.UtcNow;

        int maxValue, ticks, seconds;

        public Form1()
        {
            InitializeComponent();
        }

        #region GUI Code
        //Form Driven Methods:

        private void Form1_Load(object sender, EventArgs e)
        {
            POELadderAll = JSONHandler.ParsePOELadderJSON<LeagueList[]>(Properties.Settings.Default.SeasonEventListURL);

            //Populate the Ladder Drop Down
            ladderselectBox.Items.Add("Upcoming Races");
            foreach (var t in POELadderAll)
            {
                ladderselectBox.Items.Add(t.id);
            }
            oneSecondTimer.Enabled = true;

            PopulateRaces();
            ladderselectBox.Text = "Upcoming Races";

            seasonSelector.Text = "Season One";

            //Populate Notification List
            raceNotificationList = CreateNotificationSchedule(POELadderAll);
           
            toTrayCheck.Checked = Properties.Settings.Default.MinimizeToTray;
            launchWithWindows.Checked = Properties.Settings.Default.LaunchWithWindows;
            toastCheckBox.Checked = Properties.Settings.Default.EnableToasts;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.MinimizeToTray = toTrayCheck.Checked;
            Properties.Settings.Default.LaunchWithWindows = launchWithWindows.Checked;
            Properties.Settings.Default.EnableToasts = toastCheckBox.Checked;
        }


        //A new Ladder has been Selected from the dropdown box
        private void ladderselectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ladderselectBox.Text.Equals("Upcoming Races"))
            {
                upcomingRaces.Visible = false;             
                currentURL.Enabled = true;
                returnButton.Visible = true;
                playerDB.Clear();
                DownloadSelectedLadder((int)displayAmount.Value);
            }
            
            if (ladderselectBox.Text.Equals("Upcoming Races"))
            {
                currentURL.Enabled = false;
                returnButton.Visible = false;
                upcomingRaces.Visible = true;
                UpdateRaces();
            }
        }
        
        //Click functions for upcoming races - URL/Timer/Event
        private void upcomingRaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                if (e.RowIndex > -1 && e.ColumnIndex == 1)
                {
                    ladderselectBox.Text = upcomingRaces.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();  
                    
                }
                if (e.RowIndex > -1 && e.ColumnIndex == 3)
                {
                    UpdateTimer(e.RowIndex);
                }

                if (e.RowIndex > -1 && e.ColumnIndex == 0)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(URLs[e.RowIndex]);
                        Console.WriteLine(currentURL);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("There is no forum page for this event yet.");
                    }
                }
        }

        private void currentURL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(URLs[ladderselectBox.SelectedIndex - 1]);
                Console.WriteLine(currentURL);
            }
            catch (Exception)
            {
                MessageBox.Show("There is no forum page for this event yet.");
            }
        }
        
        //Set tooltips for upcoming races table
        private static void upcoming_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 1)
            {
                e.ToolTipText = string.Format("Click to jump to this race");
            }
            if (e.RowIndex > -1 && e.ColumnIndex == 3)
            {
                e.ToolTipText = string.Format("Starts in: ");
            }
            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {
                e.ToolTipText = string.Format("Click to view official forum event page.");
            }

        }

        private static void Alert()
        {
            var helper = new FlashWindowHelper();
            helper.FlashApplicationWindow();        
        }


        //Counter timer - 1 second intervals - Updates the appropriate timers
        private void oneSecondTimer_Tick(object sender, EventArgs e)
        {

            if (ladderselectBox.SelectedItem != null && !ladderselectBox.SelectedItem.Equals("Upcoming Races"))
            {
                UpdateTimer((ladderselectBox.SelectedIndex - 1));
            }
            else if (ladderselectBox.SelectedItem.Equals("Upcoming Races") && toastCheckBox.Checked)
            {
                DateTime StartTime = DateTime.MinValue, LocalTime = DateTime.UtcNow;;
                for (int i = 0; i < POELadderAll.Count(); i++)
                {
                    if (!string.IsNullOrEmpty(POELadderAll[i].startAt))
                    {
                        if (DateTime.ParseExact(POELadderAll[i].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'",
                            CultureInfo.CurrentCulture) > LocalTime)
                        {                         
                            StartTime = DateTime.ParseExact(POELadderAll[i].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'",
                                CultureInfo.CurrentCulture);
                            break;
                        }
                    }
                    else
                    {
                        StartTime = DateTime.MinValue;
                    }
                }

                if (DateTime.UtcNow < StartTime)
                {
                    String beforeRace = (StartTime - LocalTime).ToString();
                    StartTime = new DateTime(StartTime.Ticks - (StartTime.Ticks%TimeSpan.TicksPerSecond), StartTime.Kind);
                    LocalTime = new DateTime(LocalTime.Ticks - (LocalTime.Ticks%TimeSpan.TicksPerSecond), StartTime.Kind);

                    timerLabel.Text = "Next Race In " +
                                         String.Format(beforeRace, "{0:hh:mm:ss}")
                                             .Substring(0, beforeRace.LastIndexOf("."));

                    seconds = ((((DateTime.UtcNow - StartTime).Days * 24) * 3600) + ((DateTime.UtcNow - StartTime).Hours * 3600) + ((DateTime.UtcNow - StartTime).Minutes * 60) + ((DateTime.UtcNow - StartTime).Seconds)) * -1;                   

                    if ((StartTime - LocalTime).ToString().Equals("01:00:00") ||
                        (StartTime - LocalTime).ToString().Equals("00:15:00"))
                    {
                        Alert();
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
                        notifyIcon1.BalloonTipTitle = "Upcoming Race:";
                        notifyIcon1.BalloonTipText = "At the upcoming hour.";

                        notifyIcon1.ShowBalloonTip(10);
                    }

                }
            }
            var prog = Microsoft.WindowsAPICodePack.Taskbar.TaskbarManager.Instance;
            prog.SetProgressState(Microsoft.WindowsAPICodePack.Taskbar.TaskbarProgressBarState.Normal);
            if (seconds > 0 && progressCheck.Checked)
            {
                if (!secondsSet)
                {
                    maxValue = seconds;
                    ticks = 0;
                    secondsSet = true;
                }
                ticks++;
                prog.SetProgressValue(ticks, maxValue);
            }
            else
            {
                secondsSet = false;
            }    
        }

        //Ladder-auto Refresh - 15 seconds
        private void fifteenSecondTimer_Tick(object sender, EventArgs e)
        {
            if (autoRefreshCheckBox.Checked && !ladderselectBox.SelectedItem.Equals("Upcoming Races"))
            {
                DownloadSelectedLadder((int)displayAmount.Value);
            }

            //Check for upcoming Race Notifications
            raceNotificationList = NotificationManager(raceNotificationList);
        }

        //Hyperlink manual refresh
        private void refreshButton_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ladderselectBox.SelectedItem != null && !ladderselectBox.SelectedItem.Equals("Upcoming Races"))
            {
                DownloadSelectedLadder((int)displayAmount.Value);
            }
        }

        private void returnButton_Click(object sender, EventArgs e)
        {
            ladderselectBox.Text = "Upcoming Races";
        }
        
        //Enable or disable the auto refresh timer on checkbox change
        private void autoRefreshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            fifteenSecondTimer.Enabled = autoRefreshCheckBox.Checked;
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            UpdateLadderTable();
        }

        private void classBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateLadderTable();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            classBox.SelectedItem = "All";
            searchBox.Text = "";
            displayAmount.Value = 50;
        }

        private void trackButton_Click(object sender, EventArgs e)
        {
            f2 = new Form2();
            f2.Show();
            f2.rURL(ladderselectBox.Text.Replace(" ", "%20"));
        }

        private void trackBox_TextChanged(object sender, EventArgs e)
        {
            trackAccount = trackBox.Text;
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            if (toTrayCheck.Checked)
            {
                if (FormWindowState.Minimized == WindowState)
                {
                    ShowInTaskbar = false;
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                    notifyIcon1.BalloonTipText = "Click here to maximize.";
                    notifyIcon1.BalloonTipTitle = "Minimized to tray";
                    notifyIcon1.Text = "Path of Exile Ladder";
                    notifyIcon1.ShowBalloonTip(500);
                }
            }
        }

        private void notifyIcon1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(MousePosition);
            }
            else
                if (e.Button == MouseButtons.Left)
                {
                    WindowState = FormWindowState.Normal;
                    ShowInTaskbar = true;
                    Show();
                }
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
                contextMenuStrip1.Hide();            
        }


        private void Item_Click(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == maximizeItem)
            {
                WindowState = FormWindowState.Normal;
                ShowInTaskbar = true;
                Show();
            }

            if (e.ClickedItem == exitItem)
            {
                Dispose();
            }
        }


        private void launchWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (registryKey != null)
            {
                if (launchWithWindows.Checked)
                {
                    registryKey.SetValue("POELadder", Application.ExecutablePath);
                }
                else
                {
                    registryKey.DeleteValue("POELadder");
                }
            }
        }

       
        #endregion

        //Custom Methods:
        private void UpdateAll(String raceUrl)
        {
            PopulatePlayerDB(raceUrl);
            UpdateLadderTable();
        }

        //Update Races table
        private void UpdateRaces()
        {
            raceData = JSONHandler.ParsePOELadderJSON<LeagueList[]>(Properties.Settings.Default.SeasonEventListURL);
            var leagueData = new UpcomingRaces[raceData.Length];

            for (int i = 0; i < raceData.Length; i++)
            {
                DateTime startTime = DateTime.ParseExact(raceData[i].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CurrentCulture);
                string startAt = startTime.ToLocalTime().ToString("hh:mm:ss tt - dd/MM/yy");
                leagueData[i] = new UpcomingRaces
                {
                    ID = raceData[i].id,
                    Description = raceData[i].description,
                    StartAt = startAt,
                };

                upcomingRaces.DataSource = leagueData;
                URLs.Insert(i, raceData[i].url);
            }
            timerLabel.Text = "00:00:00";
        }

        //Upcoming Races table
        private void PopulateRaces()
        {
            raceData = JSONHandler.ParsePOELadderJSON<LeagueList[]>(Properties.Settings.Default.SeasonEventListURL);
            var links = new DataGridViewLinkColumn();
            var leagueData = new UpcomingRaces[raceData.Length];

            for (int i = 0; i < raceData.Length; i++)
            {
                DateTime startTime = DateTime.ParseExact(raceData[i].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'",
                    CultureInfo.CurrentCulture);
                string startAt = startTime.ToLocalTime().ToString("hh:mm:ss tt - dd/MM/yy");

                leagueData[i] = new UpcomingRaces
                {
                    ID = raceData[i].id,
                    Description = raceData[i].description,
                    StartAt = startAt,
                };

                upcomingRaces.DataSource = leagueData;
                URLs.Insert(i, raceData[i].url);
            }

            upcomingRaces.Columns.Insert(3, links);

            links.Text = "Forum Page";
            links.UseColumnTextForLinkValue = true;
            links.ActiveLinkColor = Color.White;
            links.VisitedLinkColor = Color.Blue;
            links.LinkBehavior = LinkBehavior.SystemDefault;
            upcomingRaces.CellContentClick += upcomingRaces_CellContentClick;
            upcomingRaces.CellToolTipTextNeeded += upcoming_CellToolTipTextNeeded;                                                  

            #region Table Formatting
            upcomingRaces.Columns[0].Width = 230;
            upcomingRaces.Columns[1].Width = 475;
            upcomingRaces.Columns[2].Width = 188;
            upcomingRaces.Columns[3].Width = 150;

            upcomingRaces.Columns[0].DisplayIndex = 0;
            upcomingRaces.Columns[1].DisplayIndex = 1;
            upcomingRaces.Columns[2].DisplayIndex = 2;
            upcomingRaces.Columns[3].DisplayIndex = 3;

            upcomingRaces.Columns[0].HeaderText = "Race Title";
            upcomingRaces.Columns[1].HeaderText = "Description";
            upcomingRaces.Columns[2].HeaderText = "Start time/date";
            upcomingRaces.Columns[3].HeaderText = "Forum event page";

            upcomingRaces.Rows[0].Cells[2].Value = "";
            upcomingRaces.Rows[1].Cells[2].Value = "";


            #endregion
        }

        //Download the ladder selected in the drop down according to the max results numerical
        private void DownloadSelectedLadder(int LimitResults)
        {
            //Sets the URL to populate the table
            String LadderSingleURL = "http://api.pathofexile.com/ladders/" + ladderselectBox.Text.Replace(" ", "%20") + "?limit=" + LimitResults;

            if (classBox.Enabled == false)
            {
                classBox.Enabled = true;
                searchBox.Enabled = true;
            }

            seasonPoints.Visible = true;
            UpdateAll(LadderSingleURL);
        }      

        //Update Table - Filting and visual formating
        private void UpdateLadderTable()
        {
            //Add the Ladder JSON Data to the Player Objects to be displayed in the Ladder Table
            var PlayerList = new List<RaceTable>();

            foreach (var t in playerDB)
            {
                var Entry = new RaceTable();
                Entry.Online = t.GetOnlineStatus();
                Entry.Rank = t.GetRank();
                Entry.Account = t.GetAccount();
                Entry.Chracter = t.GetCharacter();
                Entry.CharacterClass = t.GetClass();
                Entry.Level = t.GetLevel();
                Entry.EXP = t.GetExperience();
                Entry.EXPToNextLevel = t.GetEXPToNextLevel();
                Entry.EXPThisUpdate = t.GetEXPThisUpdate();
                Entry.EXPBehindLeader = 0;
                Entry.EST_EXP_Minute = t.GetEST_EXP_Minute();
                Entry.RankChange = t.GetRankChange();

                PlayerList.Add(Entry);
            }
            
            //Class Sorting
            if (!classBox.Text.Equals("All"))
            {
                for (var i = 0; i < PlayerList.Count; i++)
                {
                    if (PlayerList[i].CharacterClass.Equals(classBox.Text)) continue;
                    PlayerList.RemoveAt(i);
                    i--;
                }
            }
                   
            //Account Name Sorting
            if (!searchBox.Text.Equals(""))
            {
                //Index at 1 to include the race leader
                for (var i = 0; i < PlayerList.Count; i++)
                {
                    if (PlayerList[i].Account.Contains(searchBox.Text)) continue;
                    PlayerList.RemoveAt(i);
                    i--;
                }
            }

            //Calculate Leader/Behind EXP
            if (!PlayerList.Count.Equals(0))
            {
                uint LeaderEXP = PlayerList[0].EXP;

                for (var i = 1; i < PlayerList.Count; i++)
                {
                    PlayerList[i].EXPBehindLeader = LeaderEXP - PlayerList[i].EXP;
                }
            }

            //Save the cell position
            int saveRow = 0;
            if (LadderTable.Rows.Count > 0)
                saveRow = LadderTable.FirstDisplayedCell.RowIndex;

            //Apply the ladder data to the Data Grid View
            LadderTable.DataSource = PlayerList;

            //Reapply the cell position
            if (saveRow != 0 && saveRow < LadderTable.Rows.Count)
                LadderTable.FirstDisplayedScrollingRowIndex = saveRow;



            #region ClassColoring
            //Color cells by Class
            for (int i = 0; i < PlayerList.Count; i++)
            {
                if (LadderTable.Rows[i].Cells[4].Value.Equals("Marauder") && !LadderTable.Rows[i].Cells[4].Value.Equals(""))
                {
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.IndianRed;
                }

                if (LadderTable.Rows[i].Cells[4].Value.Equals("Ranger"))
                {
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.LightGreen;
                }

                if (LadderTable.Rows[i].Cells[4].Value.Equals("Witch"))
                {
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.RoyalBlue;
                }

                if (LadderTable.Rows[i].Cells[4].Value.Equals("Shadow"))
                {
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.BlueViolet;
                }

                if (LadderTable.Rows[i].Cells[4].Value.Equals("Templar"))
                {
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.Gold;
                }

                if (LadderTable.Rows[i].Cells[4].Value.Equals("Duelist"))
                {
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.Violet;
                }

                if (!LadderTable.Rows[i].Cells[11].Value.Equals("0")) 
                {
                    if (playerDB[0].GetRankChange() > 0)
                    {
                        LadderTable.Rows[i].Cells[11].Style.ForeColor = Color.Green;
                    }
                    else
                    if (playerDB[0].GetRankChange() < 0)
                    {
                        LadderTable.Rows[i].Cells[11].Style.ForeColor = Color.Red;
                    }
                }

                if (LadderTable.Rows[i].Cells[2].Value.Equals(trackBox.Text))
                {
                    LadderTable.Rows[i].Cells[0].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[1].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[2].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[3].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[5].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[6].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[7].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[8].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[9].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[10].Style.BackColor = Color.SlateBlue;
                    LadderTable.Rows[i].Cells[11].Style.BackColor = Color.SlateBlue;


                }
            }
            #endregion

            #region LadderTable Formatting
            //Change formatting to display commas: 1,000
            LadderTable.Columns[6].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[7].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[8].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[9].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[10].DefaultCellStyle.Format = "N0";

            //Relabel Columns
            LadderTable.Columns[0].HeaderText = "Online:";
            LadderTable.Columns[1].HeaderText = "Rank:";
            LadderTable.Columns[2].HeaderText = "Account:";
            LadderTable.Columns[3].HeaderText = "Character:";
            LadderTable.Columns[4].HeaderText = "Class:";
            LadderTable.Columns[5].HeaderText = "Level:";
            LadderTable.Columns[6].HeaderText = "Experience:";
            LadderTable.Columns[7].HeaderText = "EXP/Level:";
            LadderTable.Columns[8].HeaderText = "EXP/behind:";
            LadderTable.Columns[9].HeaderText = "EXP/update:";
            LadderTable.Columns[10].HeaderText = "EXP/Minute:";
            LadderTable.Columns[11].HeaderText = "Change:";

            //Tooltips
            LadderTable.Columns[7].ToolTipText = "Experience required to level";
            LadderTable.Columns[8].ToolTipText = "Experience behind the leader";
            LadderTable.Columns[9].ToolTipText = "Experience gained this update";
            LadderTable.Columns[10].ToolTipText = "Estimation of experience gained per minute";
            LadderTable.Columns[11].ToolTipText = "Change in rank since the last update";

            LadderTable.Columns[0].ReadOnly = true;

            //Auto Size Columns
            for (int i = 0; i < 11; i++)
            {
                //LadderTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                LadderTable.Columns[0].Width = 45;
                LadderTable.Columns[1].Width = 45;
                LadderTable.Columns[2].Width = 105;
                LadderTable.Columns[3].Width = 125;
                LadderTable.Columns[4].Width = 90;
                LadderTable.Columns[5].Width = 90;
                LadderTable.Columns[6].Width = 90;
                LadderTable.Columns[11].Width = 55;
                //LadderTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            if (playerDB.Count < 2)
            {
                LadderTable.DataSource = null;
            }

            #endregion
        }

        //Season Ladder Table
        private void UpdateSeasonTable()
        {        
            Properties.Settings.Default.SeasonStandingsURL = "http://www.pathofexile.com/api/season-ladders?&limit=50&id=Race+" + seasonSelector.Text.Replace(" ", "+");           
            var SeasonData = JSONHandler.ParsePOELadderJSON<SeasonRank>(Properties.Settings.Default.SeasonStandingsURL);
            bool fetch = true;

            try
            {                   
                seaLadder = new SeasonTable[SeasonData.entries.Count];
            }
            catch
            {
                MessageBox.Show("This seasons ladder doesn't exist yet!");
                seasonSelector.Text = "Season One";
                fetch = false;
            }
                
            if (fetch)
            {
                for (var i = 0; i < SeasonData.entries.Count; i++)
                {
                    seaLadder[i] = new SeasonTable
                    {
                        Rank = SeasonData.entries[i].rank,
                        Name = SeasonData.entries[i].account.name,
                        Points = SeasonData.entries[i].points
                    };

                    seasonPoints.DataSource = seaLadder;
                    seasonPoints.Columns[0].Width = 30;
                    seasonPoints.Columns[1].Width = 80;
                }
            }
        }

        //Update DB with current JSON data
        private void PopulatePlayerDB(String raceUrl)
        {
            var LadderData = JSONHandler.ParsePOELadderJSON<LadderEvent>(raceUrl);

            #region Add
            if (LadderData.entries.Count > 1 && !LadderData.entries.Count.Equals(null))
            {
                bool matchfound = false;

                for (int i = 0; i < LadderData.entries.Count; i++)
                {
                    for (int j = 0; j < playerDB.Count; j++)
                    {
                        //This account from the JSON was not found in the DB. Add to pending list.
                        if (LadderData.entries[i].account.name.Equals(playerDB[j].GetAccount()) &&
                            LadderData.entries[i].character.name.Equals(playerDB[j].GetCharacter()))
                        {
                            matchfound = true;
                            break;
                        }
                    }
                    
                    if (!matchfound)
                    {
                        PlayerDB NewPlayer = new PlayerDB(
                            LadderData.entries[i].account.name,
                            LadderData.entries[i].character.name,
                            LadderData.entries[i].character.@class);

                        playerDB.Add(NewPlayer);
                    }

                    if (matchfound)
                    {
                        matchfound = false;
                    }
                }
            }

            #endregion

            #region Update
            //Update all accounts in the DB.
            if (LadderData.entries.Count > 1)
            {                
                //Add the Ladder JSON Data to the PlayerDB
                for (int i = 0; i < LadderData.entries.Count; i++)
                {
                    for (int j = 0; j < playerDB.Count; j++)
                    {
                        //Player already exist. Update with current information.
                        if (LadderData.entries[i].account.name.Equals(playerDB[j].GetAccount()) &&
                            LadderData.entries[i].character.name.Equals(playerDB[j].GetCharacter()))
                        {
                            playerDB[j].Update(
                                LadderData.entries[i].online,
                                LadderData.entries[i].rank,
                                LadderData.entries[i].character.level,
                                LadderData.entries[i].character.experience,
                                DateTime.UtcNow);
                        }
                    }
                }

                LastUpdateCache = DateTime.UtcNow;
            }
            #endregion

            #region Delete
            //Remove accounts from the DB that are no longer in the JSON
            for (int i = 0; i < playerDB.Count; i++)
            {
                //Account was not updated in the last 15 seconds.
                if (playerDB[i].GetLastUpdateTime() < LastUpdateCache.AddSeconds(-0.9))
                {
                    playerDB.RemoveAt(i);
                    i--;
                }
            }
            #endregion

            //Sort the list:
            playerDB = playerDB.OrderBy(q => q.GetRank()).ToList();
        }

        //Update the Race Timer with the Time Left before the End of the Race
        private void UpdateTimer(int LadderSelectIndex)
        {
            DateTime StartTime, EndTime;

            //Convert time from string to DateTime
            if (!string.IsNullOrEmpty(POELadderAll[LadderSelectIndex].startAt))
            {
                StartTime = DateTime.ParseExact(POELadderAll[LadderSelectIndex].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CurrentCulture);
            }

            else
            {
                StartTime = DateTime.MinValue;
            }

            //Convert time from string to DateTime
            if (!string.IsNullOrEmpty(POELadderAll[LadderSelectIndex].endAt))
            {
                EndTime = DateTime.ParseExact(POELadderAll[LadderSelectIndex].endAt, "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CurrentCulture);
            }

            else
            {
                EndTime = DateTime.MinValue;
            }

            DateTime localTime = DateTime.UtcNow;
            String beforeRace = (StartTime - localTime).ToString();
            String duringRace = (EndTime - localTime).ToString();           

            //If the race has started but has not ended. Currently running.
            if (localTime > StartTime && localTime < EndTime)
            {
                timerLabel.Text = String.Format(duringRace, "hh:mm:ss").Substring(0, duringRace.LastIndexOf("."));
            }

            else
            {
                //The race has not started
                if (localTime < StartTime)
                {
                    DateTime raceDate = StartTime.ToLocalTime();
                    toolTip1.SetToolTip(timerLabel, raceDate.ToString());
                    timerLabel.Text = "Starts in " + String.Format(beforeRace, "{0:hh:mm:ss}").Substring(0, beforeRace.LastIndexOf("."));
                }

                else
                {
                    if (localTime == StartTime)
                    {
                        playerDB.Clear();
                        UpdateLadderTable();
                    }

                    //The current ladder has no ending (Perminate leagues)
                    else
                    {
                        if (EndTime == DateTime.MinValue || ladderselectBox.Text.Equals("Upcoming Races"))
                        {
                            timerLabel.Text = "00:00:00";
                        }
                    }
                }
            }
        }



        private List<ScheduledToastNotification> CreateNotificationSchedule(LeagueList[] ladderList)
        {
            List<ScheduledToastNotification> toastList = new List<ScheduledToastNotification>();

            //Iterate over the list of races
            for (int i = 1; i < ladderList.Length - 1; i++)
            {
                string RaceName = ladderList[i].id;
                DateTime StartTime = DateTime.ParseExact(ladderList[i].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CurrentCulture).ToLocalTime();
                
                toastList.Add(new ScheduledToastNotification(RaceName, StartTime));
            }


            //Test
            notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
            notifyIcon1.BalloonTipTitle = "Upcoming Race:";
            notifyIcon1.BalloonTipText = "TEST";

            return toastList;
        }

        private List<ScheduledToastNotification> NotificationManager(List<ScheduledToastNotification> notificationList)
        {
            System.Console.WriteLine("NotificationManager()");
            if (toastCheckBox.Checked.Equals(true))
            {
                //Iterate over items
                for (int i = 0; i < notificationList.Count; i++)
                {
                    bool notify = false;

                    //Race has already started
                    if (notificationList[i].GetDeliveryTime() <= DateTime.Now.ToLocalTime())
                    {
                        //No notificiation needs to be sent. Remove
                        notificationList.RemoveAt(i);
                        i--;
                        continue;
                    }

                    //Race is within an hour/15 minutes
                    if (notificationList[i].GetDeliveryTime().AddHours(-1) <= DateTime.Now.ToLocalTime() &&
                        notificationList[i].GetDeliveryTime() <= DateTime.Now.ToLocalTime())
                    {
                        if (!notificationList[i].GetHourNotification())
                        {
                            notify = true;
                            notificationList[i].SetHourNotification(false);
                        }
                    }

                    if (notificationList[i].GetDeliveryTime().AddMinutes(-15) <= DateTime.Now.ToLocalTime() &&
                        notificationList[i].GetDeliveryTime() <= DateTime.Now.ToLocalTime())
                    {
                        if (!notificationList[i].GetFifteenMinuteNotification())
                        {
                            notify = true;
                            notificationList[i].SetHourNotification(false);
                            notificationList[i].SetFifteenMinuteNotification(false);
                        }
                    }

                    //Create Notification
                    if (notify)
                    {
                        notifyIcon1.BalloonTipIcon = ToolTipIcon.None;
                        notifyIcon1.BalloonTipTitle = "Upcoming Race:";
                        notifyIcon1.BalloonTipText =
                            notificationList[i].GetContent() +
                            Environment.NewLine +
                            notificationList[i].GetDeliveryTime();

                        notifyIcon1.ShowBalloonTip(5000);

                        notify = false;
                    }

                    //All notification have been sent
                    if (notificationList[i].GetFifteenMinuteNotification())
                    {
                        notificationList.RemoveAt(i);
                        i--;
                    }
                }
            }
            return notificationList;
            
        }

        private void seasonSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeasonTable();
        }
    }
}
