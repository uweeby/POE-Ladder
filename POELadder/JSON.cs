using PoELadder.JSON;
using System;
using System.Net;
using System.Web.Script.Serialization;

namespace POELadder
{
    //Download JSON pages from the Path of Exile site
    public class JSON
    {        
        //All Ladders currently running
        public static PathOfExileJSONLadderAll[] ParseLadderAll(String JSON)
        {
            String WebPage = DownloadFile(JSON);

            PathOfExileJSONLadderAll[] POELadderAll = new JavaScriptSerializer().Deserialize<PathOfExileJSONLadderAll[]>(WebPage);

            return POELadderAll;
        }

        //Currently selected Ladder
        public static PathOfExileJSONLadderSingle ParseLadderSingle(String JSON)
        {
            String WebPage = DownloadFile(JSON);

            PathOfExileJSONLadderSingle POELadderSingle = new JavaScriptSerializer().Deserialize<PathOfExileJSONLadderSingle>(WebPage);

            return POELadderSingle;
        }

        //Current season
        public static PathOfExileJSONLadderSeason ParseLadderSeason(String JSON)
        {
            String WebPage = DownloadFile(JSON);

            PathOfExileJSONLadderSeason POELadderSeason = new JavaScriptSerializer().Deserialize<PathOfExileJSONLadderSeason>(WebPage);

            return POELadderSeason;
        }

        //Download provided URL and return as String
        private static String DownloadFile(String _URL)
        {
            WebClient WebReqeust = new WebClient();
            String WebPage = WebReqeust.DownloadString(_URL);
            return WebPage;
        }
    }
}
