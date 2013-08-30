using POELadder.JSON;
using System;
using System.Collections.Generic;
using System.Threading;

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
        private int ChallengeCount;
        private String TwitchURL;
        private bool? TwitchOnlineStatus;
        private DateTime TwitchCacheTime;
        private bool Dead;

        //Custom Data:
        private uint EXPToNextLevel;
        private int EXPThisUpdate;
        private int RankChange;
        private double EST_EXP_Minute;
        private int expDifference;

        TimeSpan timeGap;

        private List<DateTime> UpdateTime = new List<DateTime>();
        private List<ushort> Rank = new List<ushort>();
        private List<byte> Level = new List<byte>();
        private List<uint> Experience = new List<uint>();

        private DateTime utcUpdate;

        private bool FlagForRemoval;

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

        public void Update(bool Online, ushort Rank, byte Level, uint Experience, int ChallengeCount, String TwitchURL, bool Dead, DateTime Time)
        {
            this.Online = Online;
            this.ChallengeCount = ChallengeCount;
            this.TwitchURL = TwitchURL;
            this.Dead = Dead;

            if (Level < 100)
            {
                this.EXPToNextLevel = ExpToLevelArray[Level + 1] - Experience;
            }
            else
            {
                EXPToNextLevel = 0;
            }

            //Insert the most recent update to index 0 of each list
            this.UpdateTime.Insert(0, Time);
            this.Rank.Insert(0, Rank);
            this.Level.Insert(0, Level);
            this.Experience.Insert(0, Experience);

            utcUpdate = DateTime.UtcNow;
            UpdateEXPThisUpdate();
            UpdateRankChange(Rank);
            UpdateEXPMin();
        }

        //Remove Extra data from lists. Only need to store the last 10 updates
        private void ShrinkCollections()
        {
            int maxsize = 1000;
            if (UpdateTime.Count > maxsize)
            {
                UpdateTime.RemoveAt(UpdateTime.Count - 1);
            }

            if (Rank.Count > maxsize)
            {
                Rank.RemoveAt(Rank.Count - 1);
            }

            if (Level.Count > maxsize)
            {
                Level.RemoveAt(Level.Count - 1);
            }

            if (Experience.Count > maxsize)
            {
                Experience.RemoveAt(Experience.Count - 1);
            }
        }

        //Calculating the Experience gained this update
        private void UpdateEXPThisUpdate()
        {
            {
                if (Experience.Count > 1)
                {
                    EXPThisUpdate = (int)(Experience[0] - Experience[1]);
                }
            }          
        }

        //Calculating the change in rank between two updates.
        private void UpdateRankChange(ushort _Rank)
        {
            ushort CurrentRank = _Rank;
            ushort PreviousRank = _Rank;

            if (Rank.Count > 1)
            {
                PreviousRank = Rank[1];
            }
            
            this.RankChange = PreviousRank - CurrentRank;

            if (CurrentRank == PreviousRank)
            {
                this.RankChange = 0;
            }
        }

        //Calculating Experience per minute
        private void UpdateEXPMin()
        {
            //More than one update has happened
            if (Experience.Count > 1)
            {
                if (Experience[0] > Experience[1])
                {
                    expDifference = (int)(Experience[0] - Experience[1]);
                    timeGap = UpdateTime[0] - UpdateTime[1];
                }

                else
                {
                    for (int i = 0; i < UpdateTime.Count; i++)
                    {
                        if (UpdateTime[0].AddMinutes(-1) >= UpdateTime[i])
                        {
                            if (Experience[0] == Experience[i])
                            {
                                expDifference = 0;
                                timeGap = UpdateTime[0] - UpdateTime[1];
                            }
                        }
                    }
                }
            }

            if (expDifference != 0)
            {
                this.EST_EXP_Minute = (int)(expDifference / timeGap.TotalSeconds) * 60;
            }

            else 
            {
                this.EST_EXP_Minute = 0;
            }
        }

        #region Getters and Setters
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
            return Rank[0];
        }

        public String GetClass()
        {
            return this.Class;
        }

        public byte GetLevel()
        {
            return Level[0];
        }

        public uint GetExperience()
        {
            return Experience[0];
        }

        public uint GetEXPToNextLevel()
        {
            return this.EXPToNextLevel;
        }

        public int GetRankChange()
        {
            return this.RankChange;
        }

        public int GetEXPThisUpdate()
        {
            return this.EXPThisUpdate;
        }

        public double GetEST_EXP_Minute()
        {
            return this.EST_EXP_Minute;
        }

        public bool GetFlagForRemoval()
        {
            return this.FlagForRemoval;
        }

        public void SetFlagForRemoval(bool FlagForRemoval)
        {
            this.FlagForRemoval = FlagForRemoval;
        }

        public DateTime GetLastUpdateTime()
        {
            return this.UpdateTime[0];
        }

        public int GetChallengeCount()
        {
            return this.ChallengeCount;
        }

        public void SetChallengeCount(int ChallengeCount)
        {
            this.ChallengeCount = ChallengeCount;
        }

        public String GetTwitchURL()
        {
            return this.TwitchURL;
        }

        public void SetTwitchURL(String TwitchURL)
        {
            this.TwitchURL = TwitchURL;
        }

        public bool? GetTwitchOnline()
        {
            if (this.TwitchOnlineStatus.HasValue)
            {
                return this.TwitchOnlineStatus.Value;
            }

            return null;
        }

        public void SetTwitchOnline(bool TwitchOnline)
        {
            this.TwitchOnlineStatus = TwitchOnline;
        }

        public DateTime GetTwitchCacheTime()
        {
            return this.TwitchCacheTime;
        }

        public void SetTwitchCacheTime(DateTime TwitchCacheTime)
        {
            this.TwitchCacheTime = TwitchCacheTime;
        }

        public bool GetDeathStatus()
        {
            return this.Dead;
        }

        public void SetDeathStatus(bool Dead)
        {
            this.Dead = Dead;
        }
        #endregion Getters and Setters
    }
}
