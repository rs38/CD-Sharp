using System;
using System.Diagnostics;
using BMW.Models;
using Newtonsoft.Json.Linq;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMW.Core;
using System.Collections.Generic;
using System.Linq;
using BMW.Viewmodels;

namespace CDSharp.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestBMW()
        {
            string token = BMW.Models.BMW.GetToken();

            Debug.WriteLine(token);
            Assert.IsFalse(string.IsNullOrEmpty(token));

            BMW.Models.BMW.UpdateStatus(token,"WBY7");
                       
        }
        [TestMethod]
        public void LastTrip()
        {
            using (var db = new BMWContext())
            {
                foreach (var car in db.Vehicles)
                {
                    IEnumerable<Lasttrip> lastT = db.LastTrips;

                    var last = from d in lastT
                               where d.vehicle.vin.Equals(car.vin)
                               orderby d.id descending
                               select d.electricDistance;

                    Assert.IsTrue(last.First() > 0.1);

                }
                
            }

           

        }

        [TestMethod]
        public void GetTokenTest()
        {
            (string token, DateTime expire) = WebserviceHelper.GetAPIToken("user", "pw");
            Assert.IsFalse(string.IsNullOrEmpty(token));
            Assert.IsTrue(expire > DateTime.Now);
        }


        [TestMethod]
        public void TestGeo()
        {
            //http://maps.googleapis.com/maps/api/geocode/json?latlng=51.25137,7.778971

            float Lat = 51.25137F;
            float Long = 7.778971F;

            var cult = new CultureInfo("en-US");

            string LatStr = Lat.ToString("N", cult);
            string LongStr = Long.ToString("N", cult);

            string AddressURL = $"http://maps.google.com/maps/api/geocode/json?latlng={LatStr},{LongStr}";
            var result = new System.Net.WebClient().DownloadString(AddressURL);
            dynamic data = JObject.Parse(result);

            if (data.status == "OK")
            {
                string adr_full = data.results[0].formatted_address;
                string str = data.results[0].address_components[1].short_name;
               string city = data.results[0].address_components[3].short_name;
            }

          
        }

        [TestMethod]
        public void TestGeo2()
        {
            float Lat = 51.25137F;
            float Long = 7.778971F;
            string result = GoogleAPI.GetAdress(Lat, Long);
            Assert.IsNotNull(result);
            Assert.IsTrue(result != "");
        }
        [TestMethod]
        public void GetWebPortalToken()
        {
            (string token, int expires) = BMW.Core.WebserviceHelper.GetPortalToken("user","pw");
            int l = token.Length;

            Assert.IsFalse(string.IsNullOrEmpty(token));
            Assert.IsTrue(expires> 6000);
            Assert.AreEqual(32, l);
        }
    }
}
