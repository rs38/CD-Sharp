using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using static BMW.Core.WebserviceHelper;
using Microsoft.EntityFrameworkCore;

namespace BMW.Models
{
    public class BMW
    {
        static DateTime tokenExpireTime;
        DbContextOptions _options;
        public BMW()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BMWContext>();

            _options = optionsBuilder.Options;
        }
       
        public static string GetToken()
        {
            var optionsBuilder = new DbContextOptionsBuilder<BMWContext>();

            using (var db = new BMWContext())
            {
                if (db.AppStates.Any())
                {
                    var appstate = db.AppStates.First();
                    if (DateTime.Now > appstate.TokenExpireTime)
                    {
                        string token = renewToken();
                        appstate.CurrentToken = token;
                        appstate.TokenExpireTime = tokenExpireTime;
                        Trace.WriteLine("Token renewed to:" + appstate.TokenExpireTime);
                        db.SaveChanges();
                        return token;
                    }
                    else
                    {
                        return appstate.CurrentToken;
                    }
                }
                else
                {
                    string token = renewToken();
                    var appstate = new AppState
                    {
                        CurrentToken = token,
                        TokenExpireTime = tokenExpireTime.AddSeconds(-60)
                    };


                    db.AppStates.Add(appstate);
                    db.SaveChanges();
                    return token;
                }
            }
            
        }


            public static string renewToken()
            {
                string token = "";
                (token, tokenExpireTime) = GetAPIToken("user", "pw");
                

                if (!string.IsNullOrEmpty(token))
                {
                    return token;
                }
                else
                    return "error";
            }


            public static void UpdateVehiclesOnline(string token)
        {
            string jsondataString = Core.WebserviceHelper.GetVehiclesJson(token);
            var mycars = JsonConvert.DeserializeObject<MyCars>(jsondataString);

            using (var db = new BMWContext())
            {
                foreach (var car in mycars.vehicles) {
                    db.Vehicles.Add(car);
                }
                db.SaveChanges();
            }
        }

        public static void UpdateStatus(string token, string vin )
        {
            using (var db = new BMWContext())
            {
                if (!db.Vehicles.Any())
                {
                    UpdateVehiclesOnline(token);
                }
                foreach (var car in db.Vehicles.Where(v => v.hasAlarmSystem == true)) //attribut misused for aktive/inaktive
                {
                    if (car.vin.ToLower().StartsWith(vin.ToLower()))
                    {
                
                        Trace.WriteLine(car.vin);
                        var jsondataString = GetStatusJson(token, car.vin);

                        Trace.WriteLine(jsondataString);

                        //Rootobject skipped
                        var status = JObject.Parse(jsondataString).SelectToken("vehicleStatus").ToObject<Vehiclestatus>();

                        if (db.Status.Any())
                        {
                            string socData, SocHVMisc;
                            var misc = (socData, SocHVMisc) = GetSOCJson(token, car.vin);
                            Trace.Write("SocData:");
                            Trace.WriteLine(socData);
                            string lasttrip = GetLastTripJson(token, car.vin);
                            Trace.Write("lasttrip:");
                            Trace.WriteLine(lasttrip);
                            string alltrips = GetAllTripsJson(token, car.vin);
                            Trace.Write("alltrips:");
                            Trace.WriteLine(alltrips);

                            //SOC
                            var soc = new SoCInfo(); 
                            try
                            {
                                soc = JObject.Parse(socData).ToObject<SoCInfo>();
                                if (db.SoCInfos // update only when  SOC changed
                                    .Where(s => s.Vin.ToLower() == car.vin.ToLower())
                                    .OrderByDescending(s => s.id)
                                    .FirstOrDefault()
                                    .soc != soc.soc)  //nullexeption danger
                                {
                                    soc.LastUpdate = DateTime.Now;
                                    soc.Vin = car.vin;
                                    soc.address = GoogleAPI.GetAdress(soc.latitude, soc.longitude);
                                    db.SoCInfos.Add(soc);
                                }
                            }
                            catch (Exception)
                            {
                                soc.soc = -1;
                            }

                            var socHVMisc = new SocHVMisc();
                            socHVMisc=  JObject.Parse(SocHVMisc).ToObject<SocHVMisc>();
                            Trace.WriteLine("SOC_HV_Percent:" + socHVMisc.attributesMap.soc_hv_percent);
                            Trace.WriteLine("RemainingRangeFuel:" + socHVMisc.attributesMap.beRemainingRangeFuelKm);
                            Trace.WriteLine("Soc:" + soc.soc);
                            Trace.WriteLine("SocMax:" + soc.socMax);

                            bool firstTime = !db.Status.Any(l => l.vin.ToLower() == car.vin.ToLower());


                            if (firstTime || 
                                db.Status
                                    .Where(l => l.vin.ToLower() == car.vin.ToLower())
                                    .OrderByDescending(s => s.updateTime)
                                    .FirstOrDefault()
                                    .updateTime != status.updateTime)

                            {
                                status.LastUpdate = DateTime.Now;
                                status.position.status = GoogleAPI.GetAdress(status.position.lat,status.position.lon);
                                db.Status.Add(status);
                            }

                            var last = JObject.Parse(lasttrip).SelectToken("lastTrip").ToObject<Lasttrip>();
                            if (firstTime || 
                                db.LastTrips
                                    .Where(l => l.vehicle.vin.ToLower() == car.vin.ToLower())
                                    .OrderByDescending(lt => lt.date)
                                    .FirstOrDefault()
                                    .date != last.date)
                               
                            {
                                last.requestTime = DateTime.Now;
                                last.vehicle = car;
                                db.LastTrips.Add(last);
                            }

                            if (alltrips != "error")
                            {
                                var all = JObject.Parse(alltrips).SelectToken("allTrips").ToObject<Alltrips>();
                                if (firstTime ||
                                    db.AllTripsList
                                        .Where(a => a.vehicle.vin.ToLower() == car.vin.ToLower())
                                        .OrderByDescending(a => a.resetDate)
                                        .FirstOrDefault()
                                        .resetDate != all.resetDate)

                                {
                                    all.requestTime = DateTime.Now;
                                    all.vehicle = car;
                                    db.AllTripsList.Add(all);
                                }
                            }
                        }
                    }
                }
                db.SaveChanges();
            }
        }
    }

}