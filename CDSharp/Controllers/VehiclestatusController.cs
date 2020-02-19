using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BMW.Models;
using BMW.Viewmodels;
using Microsoft.AspNetCore.Mvc;

namespace BMW.Controllers
{

    public class VehiclestatusController : Controller
    {
        private BMWContext db;

        public VehiclestatusController(BMWContext context)
        {
            db = context;
        }

        // GET: Vehiclestatus
        public ActionResult Index(string vin, string sort)
        {

            var viewmodel = new OverviewViewModel("DESC", sort)
            {
                Lasttrip = db.LastTrips,
                Alltrips = db.AllTripsList,
                VIN = vin
            };

            return View(viewmodel);
        }
        public ActionResult LastLong(string vin, string id)
        {

            //var viewmodel = new OverviewViewModel(vin, "desc", sort)
            //{
            //    Lasttrip = db.LastTrips,
            //};
            //return View("_status",db.LastTrips);

            return (View(db.LastTrips.Where(l => l.vehicle.vin.StartsWith(vin))));
        }

        public ActionResult Details(string vin =  "wby2")
        {

            IEnumerable<Alltrips> all = db.AllTripsList;

            var results = from a in all
                          where a.vehicle.vin.ToLower().StartsWith(vin.ToLower())
                          select new AllTripsViewModel()
                          {
                              Consump = a.avgCombinedConsumption.userAverage,
                              E_Consump = a.avgElectricConsumption.userAverage,
                              Recu = a.avgRecuperation.userAverage,
                              ChargeRange = a.chargecycleRange.userAverage,
                              EDist = a.totalElectricDistance.userTotal,
                              CO2saved = a.savedCO2greenEnergy,
                              requesttime = a.resetDate,
                              ChargeCycAvg = a.chargecycleRange.userAverage,
                              ChargeCycCurr = a.chargecycleRange.userCurrentChargeCycle,
                              ChargeCycHigh = a.chargecycleRange.userHigh

                          };

                        

            return View(results);
        }

        public ActionResult SOC(string vin = "wby2")
        {

            IEnumerable<SoCInfo> all = db.SoCInfos;

            var results = from s in all
                          where s.Vin == null || s.Vin.ToLower().StartsWith(vin.ToLower())
                          select new SoCViewModel()
                          {
                            Lastupdate =s.LastUpdate,
                            Address = s.address,
                              Latitude = s.latitude,
                              Longitude = s.longitude,
                              auxPowerEcoPro = s.auxPowerEcoPro,
                              auxPowerRegular = s.auxPowerRegular,
                              soc = s.soc,
                              socMax = s.socMax
                          };

         

            return View(results);
        }
        public ActionResult Status(string vin = "wby2" )
        {

            IEnumerable<Vehiclestatus> all = db.Status;


            var results = from s in all
                          where s.vin.ToLower().StartsWith(vin.ToLower())
                          select new StatusViewModel()
                          {
                              Date = s.LastUpdate,
                              SoC = s.chargingLevelHv,
                              DoorState = s.doorLockState,
                              KM = s.mileage,
                              ERange = s.remainingRangeElectric,
                              FuelRange = s.remainingRangeFuel,
                              Fuel = s.remainingFuel,
                              MaxERange = s.maxRangeElectric,
                              PosLat = s.position.lat,
                              PosLong = s.position.lon,
                              PosStatus = s.position.status
                            };
            return View(results);
        }

        
       
        public ActionResult Last(string vin = "wby2", int? id = 10)
        {
            int lines = id ?? 10;

            IEnumerable<Lasttrip> lastT = db.LastTrips;

            var last = from d in lastT
                       where d.vehicle.vin.ToLower().StartsWith(vin.ToLower())
                       orderby d.id descending
                       select new LastTripViewModel()
                       {
                           L_100km = d.avgCombinedConsumption,
                           kWh_100km = d.avgElectricConsumption,
                           Recu = d.avgRecuperation,
                           Duration = d.duration,
                           Distance = d.totalDistance,
                           EDistance = d.electricDistance,
                           Efficiency = d.efficiencyValue,
                           Requesttime = d.requestTime,
                           Eff_a = d.accelerationValue,
                           Eff_Ant = d.anticipationValue,
                           Date= d.date,
                           Id=d.id
                       };
                                                
            if (last == null)
            {
                return HttpNotFound();
            }
            else if (lines>10)
            {
                return View("LastCompact", last.Take(lines));

            } else
            {
                return View(last.Take(lines));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
