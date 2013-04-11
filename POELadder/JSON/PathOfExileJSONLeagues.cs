using System.Collections.Generic;

namespace PoELadder.JSON
{
    public class Race
    {
        public string id { get; set; }
        public string description { get; set; }
        public string startAt { get; set; }
        public string url { get; set; }
    }
    class PathOfExileJSONLeagues
    {
        public List<Race> entries { get; set; }
    }
}
