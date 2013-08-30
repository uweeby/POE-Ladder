using System;
using System.Drawing;
using System.Windows.Forms;

namespace POELadder
{
    class RaceTable
    {
        public bool Online { get; set; }
        public int Rank { get; set; }
        public Bitmap ChallengeCount { get; set; }
        public String Account { get; set; }
        public Bitmap TwitchURL { get; set; }
        public String Character { get; set; }
        public String CharacterClass { get; set; }
        public byte Level { get; set; }
        public uint EXP { get; set; }
        public uint EXPToNextLevel { get; set; }
        public uint EXPBehindLeader { get; set; }
        public int EXPThisUpdate { get; set; }
        public double EST_EXP_Minute { get; set; }
        public int RankChange { get; set; }
    }

    class SeasonTable
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
    }

    class UpcomingRaces
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string StartAt { get; set; }

    }
}
