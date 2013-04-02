﻿using System;
using System.Windows.Forms;
using System.Linq;
using PoELadder.JSON;
using PoELadder;
using System.Collections.Generic;
using System.Drawing;

namespace POELadder
{
    public partial class Form1 : Form
    {
        PathOfExileJSONLadderAll[] POELadderAll;

        public List<PlayerDB> playerDB = new List<PlayerDB>();

        DateTime LastUpdateCache = DateTime.UtcNow;

        public Form1()
        {
            InitializeComponent();
        }

        #region GUI Code
        //Form Driven Methods:

        private void Form1_Load(object sender, EventArgs e)
        {
            POELadderAll = DownloadJSON.ParseLadderAll(Properties.Settings.Default.SeasonEventListURL);

            //Populate the Ladder Drop Down
            for (int i = 0; i < POELadderAll.Length; i++)
            {
                ladderselectBox.Items.Add(POELadderAll[i].id);
            }

            timer2.Enabled = true;
            UpdateSeasonTable();
        }

        //A new Ladder has been Selected from the Select Box.
        private void ladderselectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            playerDB.Clear();
            DownloadSelectedLadder((int)displayAmount.Value);
        }

        //Ladder-auto Refresh - 15 seconds
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (autoRefreshCheckBox.Checked == true)
            {
                DownloadSelectedLadder((int)displayAmount.Value);
            }
        }

        //Counter timer - 1 second intervals
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (ladderselectBox.SelectedItem != null)
            {
                UpdateTimer(ladderselectBox.SelectedIndex);
            }
        }

        //Hyperlink manual refresh
        private void refreshButton_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ladderselectBox.SelectedItem != null)
            {
                DownloadSelectedLadder((int)displayAmount.Value);
            }
        }

        //Enable or disable the auto refresh timer on checkbox change
        private void autoRefreshCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (autoRefreshCheckBox.Checked == true)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
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
        #endregion

        //Custom Methods:
        private void UpdateAll(String RaceURL)
        {
            PopulatePlayerDB(RaceURL);
            UpdateLadderTable();
        }

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

        //Update Table
        private void UpdateLadderTable()
        {
            //Add the Ladder JSON Data to the Player Objects to be displayed in the Ladder Table
            List<RaceTable> PlayerList = new List<RaceTable>();

            for (int i = 0; i < playerDB.Count; i++)
            {
                RaceTable Entry = new RaceTable();
                Entry.Online = playerDB[i].GetOnlineStatus();
                Entry.Rank = playerDB[i].GetRank();
                Entry.Account = playerDB[i].GetAccount();
                Entry.Chracter = playerDB[i].GetCharacter();
                Entry.CharacterClass = playerDB[i].GetClass();
                Entry.Level = playerDB[i].GetLevel();
                Entry.EXP = playerDB[i].GetExperience();
                Entry.EXPToNextLevel = playerDB[i].GetEXPToNextLevel();
                Entry.EXPBehindLeader = playerDB[i].GetEXPBehindLeader();
                Entry.EXPThisUpdate = playerDB[i].GetEXPThisUpdate();
                Entry.EST_EXP_Minute = playerDB[i].GetEST_EXP_Minute();
                Entry.RankChange = playerDB[i].GetRankChange();

                PlayerList.Add(Entry);
            }

            //Class Sorting
            if (!classBox.Text.Equals("All"))
            {
                for (int i = 0; i < PlayerList.Count; i++)
                {
                    if (!PlayerList[i].CharacterClass.Equals(classBox.Text))
                    {
                        PlayerList.RemoveAt(i);
                        i--;
                    }
                }
            }

            //Account Name Sorting
            if (!searchBox.Text.Equals(""))
            {
                for (int i = 0; i < PlayerList.Count; i++)
                {
                    if (!PlayerList[i].Account.Contains(searchBox.Text))
                    {
                        PlayerList.RemoveAt(i);
                        i--;
                    }
                }
            }

            //Apply the ladder data to the Data Grid View
            LadderTable.DataSource = PlayerList;

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
                    LadderTable.Rows[i].Cells[4].Style.BackColor = Color.Orange;
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

            //Auto Size Columns
            for (int i = 0; i < 11; i++)
            {
                LadderTable.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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
            PathOfExileJSONLadderSeason SeasonData = DownloadJSON.ParseLadderSeason(Properties.Settings.Default.SeasonOneStandingsURL);
            var seaLadder = new SeasonTable[SeasonData.entries.Count];

            for (int i = 0; i < SeasonData.entries.Count; i++)
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

        //Update DB with current JSON data
        private void PopulatePlayerDB(String RaceURL)
        {
            PathOfExileJSONLadderSingle LadderData = DownloadJSON.ParseLadderSingle(RaceURL);

            List<int> AccountUpdated = new List<int>();

            int deletedadd = 0;
            int acccreated = 0;
            int accupdated = 0;

            #region Add
            if (LadderData.entries.Count > 1)
            {
                uint LeaderEXP = LadderData.entries[0].character.experience;

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
                        //add here?
                        PlayerDB NewPlayer = new PlayerDB(
                            LadderData.entries[i].account.name,
                            LadderData.entries[i].character.name,
                            LadderData.entries[i].character.@class);

                        playerDB.Add(NewPlayer);

                        acccreated++;

                        System.Console.WriteLine("Added Account: " + LadderData.entries[i].account);
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
                uint LeaderEXP = LadderData.entries[0].character.experience;

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
                                DateTime.UtcNow,
                                LeaderEXP);

                            accupdated++;
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
                    System.Console.WriteLine("Deleted Account: " + playerDB[i].GetAccount());

                    playerDB.RemoveAt(i);
                    i--;
                    deletedadd++;
                }
            }
            #endregion

            System.Console.WriteLine("Summary:");
            System.Console.WriteLine("playerDB count: " + playerDB.Count);
            System.Console.WriteLine("acccreated: " + acccreated);
            System.Console.WriteLine("updated: " + accupdated);
            System.Console.WriteLine("deleted accounts: " + deletedadd);
            System.Console.WriteLine("============================");

            //Sort the list:
            playerDB = playerDB.OrderBy(q => q.GetRank()).ToList();
        }

        //Update the Race Timer with the Time Left before the End of the Race
        private void UpdateTimer(int LadderSelectIndex)
        {

            DateTime StartTime = Clock.FormatPOEDate(POELadderAll[LadderSelectIndex].startAt);
            DateTime EndTime = Clock.FormatPOEDate(POELadderAll[LadderSelectIndex].endAt);

            DateTime localTime = DateTime.UtcNow;
            DateTime localDate = DateTime.Today;
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
                        if (EndTime == DateTime.MinValue)
                        {
                            timerLabel.Text = "00:00:00";
                        }
                    }
                }
            }
        }

        private void UpdateByDB(String RaceURL)
        {
            //Initial setup. Download JSON
            PathOfExileJSONLadderSingle LadderData = DownloadJSON.ParseLadderSingle(RaceURL);

            List<String> NewAccountList = new List<String>();
            List<int> AccountUpdated = new List<int>();

            uint LeaderEXP = 0;

            //JSON has valid Ladder Data
            if (LadderData.entries.Count > 1)
            {
                LeaderEXP = LadderData.entries[0].character.experience;

                //First setup. Not all players added
                if (playerDB.Count < 2)
                {
                    for (int i = 0; i < LadderData.entries.Count; i++)
                    {
                        PlayerDB NewPlayer = new PlayerDB(
                            LadderData.entries[i].account.name,
                            LadderData.entries[i].character.name,
                            LadderData.entries[i].character.@class);

                        playerDB.Add(NewPlayer);

                        System.Console.WriteLine("Player not found in DB. Adding: " + i);
                    }
                }

                //Update all accounts
                for (int i = 0; i < playerDB.Count; i++)
                {
                    for (int j = 0; j < LadderData.entries.Count; j++)
                    {
                        if(!AccountUpdated.Contains(j))
                        {
                            //Player not found in DB. Flag to add
                            if (!LadderData.entries[j].account.name.Equals(playerDB[i].GetAccount()) &&
                                !LadderData.entries[j].character.name.Equals(playerDB[i].GetCharacter()))
                            {
                                NewAccountList.Add(LadderData.entries[j].character.name);

                                //System.Console.WriteLine("Player not found in DB. Flag to add: " + j);
                            }

                            //Player found in DB. Update data
                            if (LadderData.entries[j].account.name.Equals(playerDB[i].GetAccount()) &&
                                LadderData.entries[j].character.name.Equals(playerDB[i].GetCharacter()))
                            {
                                playerDB[j].Update(
                                    LadderData.entries[i].online,
                                    LadderData.entries[i].rank,
                                    LadderData.entries[i].character.level,
                                    LadderData.entries[i].character.experience,
                                    DateTime.UtcNow,
                                    LeaderEXP);

                                AccountUpdated.Add(j);
                            }
                        }
                    }

                    //DB account was not listed in update. Remove from ladder.
                    //if (!AccountUpdated)
                    //{
                    //    playerDB[i].SetFlagForRemoval(true);
                    //}

                    //AccountUpdated = false;
                }

                //Remove unlisted accounts
                //Account is listed in the DB but not on the JSON
                //for (int i = playerDB.Count; i > 0; i--)
                //{
                //    if (playerDB[i].GetFlagForRemoval())
                //    {
                //        playerDB.RemoveAt(i);
                //    }
                //}

                //Resort list by rank
                playerDB = playerDB.OrderBy(q => q.GetRank()).ToList();
            }
        }
    }
}