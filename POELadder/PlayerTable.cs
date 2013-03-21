using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POELadder
{
    class PlayerTable
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
}
