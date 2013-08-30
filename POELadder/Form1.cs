#region Usings
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Linq;
using Microsoft.Win32;
using PoELadder.JSON;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using POELadder.JSON;
using POELadder.Properties;

#endregion Usings

namespace POELadder
{
    public partial class Form1 : Form
    {
        #region Fields
        private SeasonTable[] seaLadder;
        private bool secondsSet = false;

        public string selectedLadderURL, trackAccount, TwitchURL;
        public List<PlayerDB> playerDB = new List<PlayerDB>();

        readonly List<string> URLs = new List<string>();
        readonly List<string> TwitchURLs = new List<string>();
        
        LeagueList[] POELadderAll, raceData;

        Form2 f2;

        DateTime LastUpdateCache = DateTime.UtcNow;

        int maxValue, ticks, seconds;

        #endregion Fields

        #region GUI Code
        //Form Driven Methods:
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            POELadderAll = JSONHandler.ParseJSON<LeagueList[]>(Properties.Settings.Default.SeasonEventListURL);

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
                DateTime StartTime = DateTime.MinValue, LocalTime = DateTime.UtcNow; ;
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
                    StartTime = new DateTime(StartTime.Ticks - (StartTime.Ticks % TimeSpan.TicksPerSecond), StartTime.Kind);
                    LocalTime = new DateTime(LocalTime.Ticks - (LocalTime.Ticks % TimeSpan.TicksPerSecond), StartTime.Kind);

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

        private void seasonSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateSeasonTable();
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

        //Open the selected players twitch stream when the icon is clicked on
        private void LadderTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(4))
            {
                try
                {
                    System.Diagnostics.Process.Start("http://twitch.tv/" + TwitchURLs[e.RowIndex]);
                    Console.WriteLine("http://twitch.tv/" + TwitchURLs[e.RowIndex]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Twitch stream not found.");
                } 
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

        #region Display Methods
        private void UpdateAll(String raceUrl)
        {
            PopulatePlayerDB(raceUrl);
            UpdateLadderTable();
        }

        //Update Races table
        private void UpdateRaces()
        {
            raceData = JSONHandler.ParseJSON<LeagueList[]>(Properties.Settings.Default.SeasonEventListURL);
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
            raceData = JSONHandler.ParseJSON<LeagueList[]>(Properties.Settings.Default.SeasonEventListURL);

            var links = new DataGridViewLinkColumn();
            var leagueData = new UpcomingRaces[raceData.Length];

            for (int i = 0; i < raceData.Length; i++)
            {
                DateTime startTime = DateTime.ParseExact(
                    raceData[i].startAt, 
                    "yyyy-MM-dd'T'HH:mm:ss'Z'",
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

        private void TwitchOnline()
        {
            for (var i = 0; i < LadderTable.RowCount; i++)
            {
                var twitchJson = JSONHandler.ParseJSON<TwitchAPI>("https://api.twitch.tv/kraken/streams/" + TwitchURLs[i]);
                if(twitchJson.stream.Equals(null))
                {
                    //Stream offline

                    continue;
                }

                //Stream online

                continue;
            }
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

            foreach (PlayerDB t in playerDB)
            {
                var Entry = new RaceTable();

                Entry.Online = t.GetOnlineStatus();
                Entry.Rank = t.GetRank();
                Entry.ChallengeCount = new Bitmap(1, 1);
                Entry.TwitchURL = Resources._twitchOffline;
                Entry.Account = t.GetAccount();
                Entry.Character = t.GetCharacter();
                Entry.CharacterClass = t.GetClass();
                Entry.Level = t.GetLevel();
                Entry.EXP = t.GetExperience();
                Entry.EXPToNextLevel = t.GetEXPToNextLevel();
                Entry.EXPThisUpdate = t.GetEXPThisUpdate();
                Entry.EXPBehindLeader = 0;
                Entry.EST_EXP_Minute = t.GetEST_EXP_Minute();
                Entry.RankChange = t.GetRankChange();

                PlayerList.Add(Entry);

                //Apply Death Status
                if (t.GetDeathStatus())
                {
                    Entry.Character = "(dead) " + t.GetCharacter();
                }

                if (t.GetTwitchURL() != "NULL")
                {
                    Entry.TwitchURL = Resources._twitchOnline;
                    TwitchURLs.Add(t.GetTwitchURL());
                }
                else
                {
                    Entry.TwitchURL = new Bitmap(1, 1);
                    TwitchURLs.Add(t.GetTwitchURL());
                }

                #region ChallengeSwitch
                switch (t.GetChallengeCount())
                {
                    case 1:
                        Entry.ChallengeCount = Resources._1;
                        break;
                    case 2:
                        Entry.ChallengeCount = Resources._2;
                        break;
                    case 3:
                        Entry.ChallengeCount = Resources._3;
                        break;
                    case 4:
                        Entry.ChallengeCount = Resources._4;
                        break;
                    case 5:
                        Entry.ChallengeCount = Resources._5;
                        break;
                    case 6:
                        Entry.ChallengeCount = Resources._6;
                        break;
                    case 7:
                        Entry.ChallengeCount = Resources._7;
                        break;
                    case 8:
                        Entry.ChallengeCount = Resources._8;
                        break;
                }
                #endregion
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

            //Save the cell position during Scroll up/down
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
            string[] classArray = { "Marauder", "Ranger", "Witch", "Shadow", "Templar", "Duelist" };
            Color[] classColors = { Color.IndianRed, Color.LightGreen, Color.RoyalBlue, Color.BlueViolet, Color.Gold, Color.Violet };

            for (int i = 0; i < PlayerList.Count; i++)
            {
                for (int j = 0; j < classArray.Length; j++)
                {
                    if (LadderTable.Rows[i].Cells[6].Value.Equals(classArray[j]))
                    {
                        LadderTable.Rows[i].Cells[6].Style.BackColor = classColors[j];
                    }
                }

                if (!LadderTable.Rows[i].Cells[13].Value.Equals("0"))
                {
                    if (playerDB[0].GetRankChange() > 0)
                    {
                        LadderTable.Rows[i].Cells[13].Style.ForeColor = Color.Green;
                    }
                    else
                        if (playerDB[0].GetRankChange() < 0)
                        {
                            LadderTable.Rows[i].Cells[13].Style.ForeColor = Color.Red;
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
            LadderTable.Columns[8].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[9].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[10].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[11].DefaultCellStyle.Format = "N0";
            LadderTable.Columns[12].DefaultCellStyle.Format = "N0";

            //Relabel Columns
            LadderTable.Columns[0].HeaderText = "Online:";
            LadderTable.Columns[1].HeaderText = "Rank:";
            LadderTable.Columns[2].HeaderText = "Challenge:";
            LadderTable.Columns[3].HeaderText = "Account:";
            LadderTable.Columns[4].HeaderText = "";
            LadderTable.Columns[5].HeaderText = "Character:";
            LadderTable.Columns[6].HeaderText = "Class:";
            LadderTable.Columns[7].HeaderText = "Level:";
            LadderTable.Columns[8].HeaderText = "Experience:";
            LadderTable.Columns[9].HeaderText = "EXP/Level:";
            LadderTable.Columns[10].HeaderText = "EXP/behind:";
            LadderTable.Columns[11].HeaderText = "EXP/update:";
            LadderTable.Columns[12].HeaderText = "EXP/Minute:";
            LadderTable.Columns[13].HeaderText = "Change:";

            //Tooltips
            LadderTable.Columns[9].ToolTipText = "Experience required to level";
            LadderTable.Columns[10].ToolTipText = "Experience behind the leader";
            LadderTable.Columns[11].ToolTipText = "Experience gained this update";
            LadderTable.Columns[12].ToolTipText = "Estimation of experience gained per minute";
            LadderTable.Columns[13].ToolTipText = "Change in rank since the last update";

            LadderTable.Columns[0].ReadOnly = true;
            LadderTable.Columns[4].ReadOnly = true;

            //Auto Size Columns
            for (int i = 0; i < 11; i++)
            {
                LadderTable.Columns[0].Width = 45;
                LadderTable.Columns[1].Width = 45;
                LadderTable.Columns[2].Width = 65;
                LadderTable.Columns[4].Width = 20;
                LadderTable.Columns[5].Width = 125;
                LadderTable.Columns[6].Width = 90;
                LadderTable.Columns[7].Width = 90;
                LadderTable.Columns[8].Width = 90;
                LadderTable.Columns[13].Width = 55;
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
            var SeasonData = JSONHandler.ParseJSON<SeasonRank>(Properties.Settings.Default.SeasonStandingsURL);
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
            var LadderData = JSONHandler.ParseJSON<LadderEvent>(raceUrl);

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

                            if (LadderData.entries[i].account.twitch != null)
                            {
                                playerDB[j].SetTwitchURL(LadderData.entries[i].account.twitch.name);
                            }
                            else
                            {
                                playerDB[j].SetTwitchURL("NULL");
                            }

                            playerDB[j].Update(
                                LadderData.entries[i].online,
                                LadderData.entries[i].rank,
                                LadderData.entries[i].character.level,
                                LadderData.entries[i].character.experience,
                                LadderData.entries[i].account.challenges.total,
                                playerDB[j].GetTwitchURL(),
                                LadderData.entries[i].dead,
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
            //Convert time from string to DateTime
            DateTime StartTime;
            if (!string.IsNullOrEmpty(POELadderAll[LadderSelectIndex].startAt))
            {
                StartTime = DateTime.ParseExact(POELadderAll[LadderSelectIndex].startAt, "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CurrentCulture);
            }

            else
            {
                StartTime = DateTime.MinValue;
            }

            //Convert time from string to DateTime
            DateTime EndTime;
            if (!string.IsNullOrEmpty(POELadderAll[LadderSelectIndex].endAt))
            {
                EndTime = DateTime.ParseExact(POELadderAll[LadderSelectIndex].endAt, "yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.CurrentCulture);
            }

            else
            {
                EndTime = DateTime.MinValue;
            }

            DateTime localTime = DateTime.UtcNow;
            String timeBeforeRace = (StartTime - localTime).ToString();
            String timeRemainingRace = (EndTime - localTime).ToString();

            //If the race has started but has not ended. Currently running.
            if (localTime > StartTime && localTime < EndTime)
            {
                timerLabel.Text = String.Format(timeRemainingRace, "hh:mm:ss").Substring(0, timeRemainingRace.LastIndexOf("."));
            }

            else
            {
                //The race has not started
                if (localTime < StartTime)
                {
                    DateTime raceDate = StartTime.ToLocalTime();
                    toolTip1.SetToolTip(timerLabel, raceDate.ToString());
                    timerLabel.Text = "Starts in " + String.Format(timeBeforeRace, "{0:hh:mm:ss}").Substring(0, timeBeforeRace.LastIndexOf("."));
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
        #endregion Table Methods
       

    }
}
