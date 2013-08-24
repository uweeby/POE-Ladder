using PoELadder.JSON;
using System;
using System.Net;
using System.Web.Script.Serialization;

namespace POELadder
{
    //Download JSON pages from the Path of Exile site
    public class JSONHandler
    {        
        //All Ladders currently running
        public static T ParseJSON<T>(String JSON)
        {
            String WebPage = DownloadURL(JSON);

            if (WebPage != null)
            {
                try
                {
                    T POELadderAll = new JavaScriptSerializer().Deserialize<T>(WebPage);

                    return POELadderAll;
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);

                    return default(T);
                }
            }

            else
            {
                return default(T);
            }
        }

        //Download provided URL and return as String
        private static String DownloadURL(String URL)
        {
            WebClient WebReqeust = new WebClient();

            try
            {
                return WebReqeust.DownloadString(URL);
            }

            catch (Exception e)
            {
                System.Console.WriteLine(e);

                return null;
            }
        }
    }
}
