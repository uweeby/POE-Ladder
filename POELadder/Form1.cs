using System;
using System.Windows.Forms;
using System.Linq;
using PoELadder.JSON;
using PoELadder;
using System.Collections.Generic;
using System.Drawing;
using System.Data;

namespace POELadder
{
    public partial class Form1 : Form
    {
        // How to make this so we don't have to hardcode the Season number (one) each time a new season comes around? Another drop down maybe? IDK.
        public String SeasonLadderURL = "http://www.pathofexile.com/api/season-ladders?&limit=50&id=Race+Season+One";
        public String LadderAllURL = "http://api.pathofexile.com/leagues";

        PathOfExileJSONLadderAll[] POELadderAll;

        DataView classFilter = new DataView();

        public List<PlayerDB> playerDB = new List<PlayerDB>();

        public Form1()
        {
            InitializeComponent();
        }

        #region GUI Code
        //Form Driven Methods:

        private void Form1_Load(object sender, EventArgs e)
        {
            POELadderAll = DownloadJSON.ParseLadderAll(LadderAllURL);

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
//SelectedLadderIndex = ladderselectBox.SelectedIndex;
            DownloadSelectedLadder((int)displayAmount.Value);
        }

        private void DownloadSelectedLadder(int LimitResults)
        {
            //Sets the URL to populate the table
            String LadderSingleURL = "http://api.pathofexile.com/ladders/" + ladderselectBox.Text.Replace(" ", "%20") + "?limit=" + LimitResults;

            if (playerDB.Count > 2)
            {
                playerDB.Clear();
            }

            if (classBox.Enabled == false)
            {
                classBox.Enabled = true;
                searchBox.Enabled = true;
            }

            seasonPoints.Visible = true;
            UpdateAll(LadderSingleURL);
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

        //New Search Parameters have been selected in the UI
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < LadderTable.RowCount; i++)
            {
                if (LadderTable.Rows[i].Cells[3].Value.ToString().ToLower().Contains(searchBox.Text.ToLower()) ||
                    LadderTable.Rows[i].Cells[2].Value.ToString().ToLower().Contains(searchBox.Text))
                {
                    LadderTable.Rows[i].Visible = true;
                }
                else
                {
                    LadderTable.CurrentCell = null;
                    LadderTable.Rows[i].Visible = false;
                }
            }
        }
        #endregion

        //Custom Methods:
        private void UpdateAll(String RaceURL)
        {
            PopulatePlayerDB(RaceURL);
            UpdateLadderTable();
        }

        //Update Table
        private void UpdateLadderTable()
        {
            //Add the Ladder JSON Data to the Player Objects to be displayed in the Ladder Table
            var arrPlayers = new PlayerTable[playerDB.Count];
            for (int i = 0; i < playerDB.Count; i++)
            {
                arrPlayers[i] = new PlayerTable
                {
                    Online = playerDB[i].GetOnlineStatus(),
                    Rank = playerDB[i].GetRank(),
                    Account = playerDB[i].GetAccount(),
                    Chracter = playerDB[i].GetCharacter(),
                    CharacterClass = playerDB[i].GetClass(),
                    Level = playerDB[i].GetLevel(),
                    EXP = playerDB[i].GetExperience(),
                    EXPToNextLevel = playerDB[i].GetEXPToNextLevel(),
                    EXPBehindLeader = playerDB[i].GetEXPBehindLeader(),
                    EXPThisUpdate = playerDB[i].GetEXPThisUpdate(),
                    EST_EXP_Minute = playerDB[i].GetEST_EXP_Minute(),
                    RankChange = playerDB[i].GetRankChange()
                };
            };

            //Apply the ladder data to the Data Grid View
            LadderTable.DataSource = arrPlayers;

            //Class filtering, needs to be redone at a later date
            //for (int i = 0; i < playerDB.Count; i++)
            //{
            //Limit to only the selected class or All
            //if (!LadderTable.Rows[i].Cells[4].Value.Equals(classBox.Text) && !classBox.Text.Equals("All"))
            //{
            //    LadderTable.CurrentCell = null;
            //    LadderTable.Rows[i].Visible = false;
            //}
            //else
            //{
            //    LadderTable.Rows[i].Visible = true;
            //}
            //}

            #region ClassColoring
            for (int i = 0; i < playerDB.Count; i++)
            {
                if (LadderTable.Rows[i].Cells[4].Value.Equals("Marauder"))
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

            //Sizes
            LadderTable.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (playerDB.Count < 2)
            {
                LadderTable.DataSource = null;
            }

            #endregion
        }

        //Season ladder Table
        private void UpdateSeasonTable()
        {
            PathOfExileJSONLadderSeason SeasonData = DownloadJSON.ParseLadderSeason(SeasonLadderURL);
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

        //Update Ladder Table with the current DB data
        private void PopulatePlayerDB(String RaceURL)
        {
            PathOfExileJSONLadderSingle LadderData = DownloadJSON.ParseLadderSingle(RaceURL);

            if (LadderData.entries.Count > 1)
            {
                uint LeaderEXP = LadderData.entries[0].character.experience;

                //Add the Ladder JSON Data to the PlayerDB
                for (int i = 0; i < LadderData.entries.Count; i++)
                {
                    //First setup. Not all players added
                    if (playerDB.Count < LadderData.entries.Count)
                    {
                        PlayerDB NewPlayer = new PlayerDB(
                            LadderData.entries[i].account.name,
                            LadderData.entries[i].character.name,
                            LadderData.entries[i].character.@class);

                        playerDB.Add(NewPlayer);
                    }

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
                        }
                    }
                }

                LadderTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

            if (LadderData.entries.Count < 2)
            {
                playerDB.Clear();
            }

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
                    LadderTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }

                //The current ladder has no ending (Perminate leagues)
                else if (EndTime == DateTime.MinValue)
                {
                    timerLabel.Text = "00:00:00";
                }
            }
        }

        private void UpdateByDB(String RaceURL)
        {
            //Initial setup. Download JSON
            PathOfExileJSONLadderSingle LadderData = DownloadJSON.ParseLadderSingle(RaceURL);
            uint LeaderEXP = 0;

            List<PathOfExileJSONLadderSingle> LadderDataList = new List<PathOfExileJSONLadderSingle>();
            List<String> NewAccountList = new List<String>();

            //JSON has valid Ladder Data
            if (LadderData.entries.Count > 1)
            {
                LeaderEXP = LadderData.entries[0].character.experience;

                for (int i = 0; i < LadderData.entries.Count; i++)
                {
                    LadderDataList.Add(LadderData);
                }

                //Update all accounts
                for (int i = 0; i < playerDB.Count; i++)
                {
                    for (int j = 0; j < LadderDataList.Count; j++)
                    {
                        //Player not found in DB. Flag to add
                        if (!LadderData.entries[j].account.name.Equals(playerDB[i].GetAccount()) &&
                                !LadderData.entries[j].character.name.Equals(playerDB[i].GetCharacter()))
                        {

                            NewAccountList.Add(LadderData.entries[j].character.name);
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
                        }
                    }

                    //DB account was not listed in update. Remove from ladder.
                    playerDB[i].SetFlagForRemoval(true);
                }

                //Remove unlisted accounts
                //Account is listed in the DB but not on the JSON
                for (int i = playerDB.Count; i > 0; i--)
                {
                    if (playerDB[i].GetFlagForRemoval())
                    {
                        playerDB.RemoveAt(i);
                    }
                }

                //Resort list by rank
                playerDB = playerDB.OrderBy(q => q.GetRank()).ToList();
            }

            //JSON data is empty
            if (LadderData.entries.Count < 2)
            {

            }
        }
    }
}
