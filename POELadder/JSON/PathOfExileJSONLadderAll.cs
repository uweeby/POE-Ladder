using System.Collections.Generic;

namespace PoELadder.JSON
{
    public class PathOfExileJSONLadderAll
    {
        public string id { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public bool @event { get; set; }
        public string registerAt { get; set; }
        public string startAt { get; set; }
        public string endAt { get; set; }
        public List<object> rules { get; set; }
        public List<object> ladder { get; set; }
    }
}
