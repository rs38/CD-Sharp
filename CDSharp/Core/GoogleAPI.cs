using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace BMW.Models
{
    public class GoogleAPI
    {
        public static string GetAdress( double Lat, double Long)
        {
            //http://maps.googleapis.com/maps/api/geocode/json?latlng=51.25137,6.778971

            //float Lat = 51.25137F;
            //float Long = 6.778971F;

            var cult = new CultureInfo("en-US");

            string LatStr = Lat.ToString("F7", cult);
            string LongStr = Long.ToString("F7",cult);
            string myApiKey = "myApiKey";

            string AddressURL = $"https://maps.google.com/maps/api/geocode/json?latlng={LatStr},{LongStr}&key={myApiKey}";
            var client = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 };
            var result =client.DownloadString(AddressURL);
            dynamic data = JObject.Parse(result);

            if (data.status == "OK")
            {
                try
                {
                   return data.results[0].formatted_address;
                }
                catch (Exception)
                {
                    return "adress error";
                }
            } else
            {
                return "unknown";
            }

         

        }
    }
}