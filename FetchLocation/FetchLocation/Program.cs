using System;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace FetchLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(RetrieveFormatedAddress("6.856667", "7.395833"));
            Console.ReadLine();
        }

        static string baseUri =
  "https://maps.googleapis.com/maps/api/geocode/xml?key=AIzaSyDrISxrPABg9mM5DNejacWvo0d2DBndmkw&latlng={0},{1}&sensor=false";
        string location = string.Empty;
        

        public static string RetrieveFormatedAddress(string lat, string lng)
        {
            string locality = "";
            string requestUri = string.Format(baseUri, lat, lng);

            using (WebClient wc = new WebClient())
            {
                string result = wc.DownloadString(requestUri);
                var xmlElm = XElement.Parse(result);
                var status = (from elm in xmlElm.Descendants()
                              where
elm.Name == "status"
                              select elm).FirstOrDefault();
                if (status.Value.ToLower() == "ok")
                {
                    var res = (from elm in xmlElm.Descendants()
                               where
elm.Name == "address_component"
                               select elm).FirstOrDefault();

                    var local = (from elm in xmlElm.Descendants() where elm.Name == "long_name" select elm).FirstOrDefault();
                    locality = local.Value;
                }
            }

            return locality;
        }
    }
}
