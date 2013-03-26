using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PoELadder.JSON
{

        public class Season
        {
            public string name { get; set; }
        }

        public class Start
        {
            public Season account { get; set; }
            public int points { get; set; }
            public int rank { get; set; }
        }

        public class PathOfExileJSONLadderSeason
        {
            public string total { get; set; }
            public List<Start> entries { get; set; }
        }
    
}
