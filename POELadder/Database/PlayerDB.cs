using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POELadder
{
    //Object to hold the Ladder Data for Players
    public class PlayerDB
    {
        //Standard Data:
        private bool Online;
        private String Account;
        private String Character;
        private String Class;

        //Custom Data:
        private uint EXPToNextLevel;
        private uint EXPBehindLeader;
        private int EXPThisUpdate;
        private int RankChange;
        private int EST_EXP_Minute;

        private List<DateTime> UpdateTime = new List<DateTime>();
        private List<ushort> Rank = new List<ushort>();
        private List<byte> Level = new List<byte>();
        private List<uint> Experience = new List<uint>();

        public DateTime utcUpdate;

        #region EXP Array
        public uint[] ExpToLevelArray = new uint[101] {
            0,
            0,
            525,
            1760,
            3781,
            7184,
            12186,
            19324,
            29377,
            43181,
            61693,
            85990,
            117506,
            157384,
            207736,
            269997,
            346462,
            439268,
            551295,
            685171,
            843709,
            1030734,
            1249629,
            1504995,
            1800847,
            2142652,
            2535122,
            2984677,
            3496798,
            4080655,
            4742836,
            5490247,
            6334393,
            7283446,
            8384398,
            9541110,
            10874351,
            12361842,
            14018289,
            15859432,
            17905634,
            20171471,
            22679999,
            25456123,
            28517857,
            31897771,
            35621447,
            39721017,
            44225461,
            49176560,
            54607467,
            60565335,
            67094245,
            74247659,
            82075627,
            90631041,
            99984974,
            110197515,
            121340161,
            133497202,
            146749362,
            161191120,
            176922628,
            194049893,
            212684946,
            232956711,
            255001620,
            278952403,
            304972236,
            333233648,
            363906163,
            397194041,
            433312945,
            472476370,
            514937180,
            560961898,
            610815862,
            664824416,
            723298169,
            786612664,
            855129128,
            929261318,
            1009443795,
            1096169525,
            1189918242,
            1291270350,
            1400795257,
            1519130326,
            1646943474,
            1784977296,
            1934009687,
            2094900291,
            2268549086,
            2455921256,
            2658074992,
            2876116901,
            3111280300,
            3364828162,
            3638186694,
            3932818530,
            4250334444};
        #endregion

        public PlayerDB(String Account, String Character, String Class)
        {
            //Constructor for new players
            this.Account = Account;
            this.Character = Character;
            this.Class = Class;
        }


        public void Update(bool Online, ushort Rank, byte Level, uint Experience, DateTime Time, uint LeaderEXP)
        {
            this.Online = Online;
            this.EXPToNextLevel = ExpToLevelArray[Level + 1] - Experience;
            this.EXPBehindLeader = LeaderEXP - Experience;

            UpdateEXPThisUpdate();
            UpdateRankChange(Rank);
            UpdateEXPMin();

            this.UpdateTime.Insert(0, Time);

            this.Rank.Insert(0, Rank);
            this.Level.Insert(0, Level);
            this.Experience.Insert(0, Experience);

            utcUpdate = DateTime.UtcNow;
            
            //if (this.Rank.Count == 1)
            //{
            //    this.Rank.Insert(0, Rank);
            //}

            //if (this.Rank.Count > 1)
            //{
            //    if (this.Rank[0] != Rank)
            //    {
            //        this.Rank.Insert(0, Rank);
            //    }
            //}

            //if (this.Level.Count == 1)
            //{
            //    this.Level.Insert(0, Level);
            //}

            //if (this.Level.Count > 1)
            //{
            //    if (this.Level[0] != Level)
            //    {
            //        this.Level.Insert(0, Level);
            //    }
            //}

            //if (this.Experience.Count == 1)
            //{
            //    this.Experience.Insert(0, Experience);
            //}

            //if (this.Experience.Count > 1)
            //{
            //    if (this.Experience[0] != Experience)
            //    {
            //        this.Experience.Insert(0, Experience);
            //    }
            //}

            ShrinkCollections();
        }


        //Remove Extra data from lists. Only need to store the last 10 updates
        private void ShrinkCollections()
        {
            if (UpdateTime.Count > 10)
            {
                UpdateTime.RemoveAt(UpdateTime.Count - 1);
            }

            if (Rank.Count > 10)
            {
                Rank.RemoveAt(Rank.Count - 1);
            }

            if (Level.Count > 10)
            {
                Level.RemoveAt(Level.Count - 1);
            }

            if (Experience.Count > 10)
            {
                Experience.RemoveAt(Experience.Count - 1);
            }
        }

        //Calculating the Experience gained this update
        private void UpdateEXPThisUpdate()
        {
            if (this.Experience.Count > 1)
            {
                this.EXPThisUpdate = (int)(this.Experience[0] - this.Experience[1]);
            }

        }

        //Calculating the change in rank between two updates.
        private void UpdateRankChange(ushort _Rank)
        {
            ushort CurrentRank = _Rank;
            ushort PreviousRank = _Rank;

            if (this.Rank.Count > 1)
            {
                PreviousRank = this.Rank[1];
            }

            if (CurrentRank > PreviousRank)
            {
                this.RankChange = CurrentRank - PreviousRank;
            }

            if (CurrentRank < PreviousRank)
            {
                this.RankChange = PreviousRank - CurrentRank;
            }

            if (CurrentRank == PreviousRank)
            {
                this.RankChange = 0;
            }


        }

        //Calculating Experience per minute
        private void UpdateEXPMin()
        {
            //Calculate EXP over Time Updates
            int TotalEXP = 0;
            int expMIN = 0;
            //More than one update has happened
            if (Experience.Count > 1)
            {
                for(int i = 1; i < Experience.Count - 1; i++)
                {
                    TotalEXP += (int)(Experience[i] - Experience[i + 1]);
                }

            //This will use the time gap instead, gap is 14 or 15 seconds as per the timer2 auto-update
                int gap = (int)(UpdateTime[0] - UpdateTime[1]).TotalSeconds;
                expMIN = (TotalEXP / Experience.Count) * (60 / gap);

            }

            this.EST_EXP_Minute = expMIN;
        }

        public bool GetOnlineStatus()
        {
            return this.Online;
        }
        public String GetAccount()
        {
            return this.Account;
        }

        public String GetCharacter()
        {
            return this.Character;
        }

        public ushort GetRank()
        {
            return this.Rank[0];
        }

        public String GetClass()
        {
            return this.Class;
        }

        public byte GetLevel()
        {
            return this.Level[0];
        }

        public uint GetExperience()
        {
            return this.Experience[0];
        }

        public uint GetEXPToNextLevel()
        {
            return this.EXPToNextLevel;
        }

        public uint GetEXPBehindLeader()
        {
            return this.EXPBehindLeader;
        }

        public int GetRankChange()
        {
            return this.RankChange;
        }

        public int GetEXPThisUpdate()
        {
            return this.EXPThisUpdate;
        }

        public int GetEST_EXP_Minute()
        {
            return this.EST_EXP_Minute;
        }
    }
}
