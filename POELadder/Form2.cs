using System;
using System.Windows.Forms;
using PoELadder.JSON;

namespace POELadder
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        public string fullURL;

        public void Form2_Load(object sender, EventArgs e)
        {
        }

        public void populatePlayer()
        {
            var playerData = JSONHandler.ParseJSON<LadderEvent>(fullURL);
            var frm = new Form1();
            var Player = new RaceTable();
            Console.WriteLine(":" + fullURL);

            foreach (Entry t in playerData.entries)
            {
                //if (frm.trackAccount.ToLower() == t.account.name.ToLower())
                //{
                //for (int i = 0; i < frm.playerDB.Count; i++) {
                Player.Online = t.online;
                Player.Rank = t.rank;
                Player.Account = t.account.name;
                Player.Chracter = t.character.name;
                Player.CharacterClass = t.character.@class;
                Player.Level = t.character.level;
                Player.EXP = t.character.experience;
                //Player.EXPToNextLevel = frm.playerDB[i].GetEXPToNextLevel();
                //Player.EXPThisUpdate = frm.playerDB[i].GetEXPThisUpdate();
                Player.EXPBehindLeader = 0;
                //Player.EST_EXP_Minute = frm.playerDB[i].GetEST_EXP_Minute();
                //Player.RankChange = frm.playerDB[i].GetRankChange();
                //}
            }
            playerTable.DataSource = Player;
            // }
            Console.WriteLine("Count: " + Player);
        }

        public void rURL(string raceURL)
        {
            fullURL = "http://api.pathofexile.com/ladders/" + raceURL + "?limit=200";
            populatePlayer();
        }
    }
}
