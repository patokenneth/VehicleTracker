using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VehicleTracker.Utility
{
    public static class FetchName
    {
        
        public static string ReturnName(string key, string latitude, string longitude)
        {
            //since this makes an external api call, kindly ensure you are connected to the internet for valid response

            string baseUri = "https://maps.googleapis.com/maps/api/geocode/xml?key={0}&latlng={1},{2}&sensor=false";

            string locality = "";

            string requestUri = string.Format(baseUri, key, latitude, longitude);

            try
            {
                using (WebClient wc = new WebClient())
                {
                    string result = wc.DownloadString(requestUri);
                    var xmlElm = XElement.Parse(result);
                    var status = (from elm in xmlElm.Descendants()
                                  where elm.Name == "status"
                                  select elm).FirstOrDefault();

                    if (status.Value.ToLower() == "ok")
                    {
                        var add = (from elm in xmlElm.Descendants()
                                   where elm.Name == "formatted_address"
                                   select elm).FirstOrDefault();

                        //var local = (from elm in xmlElm.Descendants()
                        //             where elm.Name == "long_name"
                        //             select elm).FirstOrDefault();

                        locality = add.Value;
                    }
                }
            }
            catch (Exception ex)
            {

                //throw;
            }

            return locality;
            
        }
    }
}
