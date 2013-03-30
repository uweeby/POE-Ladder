using System;

namespace POELadder
{
    class RaceTable
    {
        public bool Online { get; set; }
        public int Rank { get; set; }
        public String Account { get; set; }
        public String Chracter { get; set; }
        public String CharacterClass { get; set; }
        public byte Level { get; set; }
        public uint EXP { get; set; }
        public uint EXPToNextLevel { get; set; }
        public uint EXPBehindLeader { get; set; }
        public int EXPThisUpdate { get; set; }
        public int EST_EXP_Minute { get; set; }
        public int RankChange { get; set; }
    }

    class SeasonTable
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
    }  
}
