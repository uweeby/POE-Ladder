using PoELadder.JSON;
using System;
using System.Net;
using System.Web.Script.Serialization;

namespace POELadder
{
    //Download JSON pages from the Path of Exile site
    public class DownloadJSON
    {        
        //All Ladders currently running
        public static PathOfExileJSONLadderAll[] ParseLadderAll(String JSON)
        {
            String WebPage = DownloadFile(JSON);

            if (WebPage != null)
            {
                try
                {
                    PathOfExileJSONLadderAll[] POELadderAll = new JavaScriptSerializer().Deserialize<PathOfExileJSONLadderAll[]>(WebPage);

                    return POELadderAll;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);

                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        //Currently selected Ladder
        public static PathOfExileJSONLadderSingle ParseLadderSingle(String JSON)
        {
            String WebPage = DownloadFile(JSON);

            if (WebPage != null)
            {
                try
                {
                    PathOfExileJSONLadderSingle POELadderSingle = new JavaScriptSerializer().Deserialize<PathOfExileJSONLadderSingle>(WebPage);

                    return POELadderSingle;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);

                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        //Current season
        public static PathOfExileJSONLadderSeason ParseLadderSeason(String JSON)
        {
            String WebPage = DownloadFile(JSON);

            if (WebPage != null)
            {
                try
                {
                    PathOfExileJSONLadderSeason POELadderSeason = new JavaScriptSerializer().Deserialize<PathOfExileJSONLadderSeason>(WebPage);

                    return POELadderSeason;

                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);

                    return null;
                }
            }

            else
            {
                return null;
            }
        }

        //Download provided URL and return as String
        private static String DownloadFile(String URL)
        {
            WebClient WebReqeust = new WebClient();

            try
            {
                String WebPage = WebReqeust.DownloadString(URL);

                return WebPage;
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e);

                return null;
            }
        }
    }
}
