using System.Collections.Generic;

namespace PoELadder.JSON
{
    public class Character
    {
        public string name { get; set; }
        public byte level { get; set; }
        public string @class { get; set; }
        public uint experience { get; set; }
    }

    public class Challenges
    {
        public int total { get; set; }
    }

    public class Twitch
    {
        public string name { get; set; }
    }

    public class Account
    {
        public string name { get; set; }
        public Challenges challenges { get; set; }
        public Twitch twitch { get; set; }
    }

    public class Entry
    {
        public bool online { get; set; }
        public ushort rank { get; set; }
        public bool dead { get; set; }
        public Character character { get; set; }
        public Account account { get; set; }
    }

    public class LadderEvent
    {
        public int total { get; set; }
        public List<Entry> entries { get; set; }
    }
}
