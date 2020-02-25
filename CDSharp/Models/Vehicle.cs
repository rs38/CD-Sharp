using System.ComponentModel.DataAnnotations;

namespace BMW.Models
{
    public class Vehicle
    {
        
        public string vin { get; set; }
        public string model { get; set; }
        public string bodytype { get; set; }
        public string driveTrain { get; set; }
        public string color { get; set; }
        public string colorCode { get; set; }
        public string brand { get; set; }
        public int yearOfConstruction { get; set; }
        public bool statisticsCommunityEnabled { get; set; }
        public bool statisticsAvailable { get; set; }
        public string hub { get; set; }
        public bool hasAlarmSystem { get; set; }

        public string countryCode { get; set; }
        public string steering { get; set; }
        public string vehicleFinderRestriction { get; set; }
        public string hmiVersion { get; set; }
        public string a4a { get; set; }
        public string vehicleFinder { get; set; }
        public string remote360 { get; set; }
        public string hornBlow { get; set; }
        public string lightFlash { get; set; }
        public string doorLock { get; set; }
        public string doorUnlock { get; set; }
        public string climateControl { get; set; }
        public string climateNow { get; set; }
        public string chargingControl { get; set; }
        public string chargeNow { get; set; }
        public string sendPoi { get; set; }
        public string rangeMap { get; set; }
        public string lastDestinations { get; set; }
        public string intermodalRouting { get; set; }
        public string climateFunction { get; set; }
        public string onlineSearchMode { get; set; }
        public string onlineSearchProvider { get; set; }
        public string smartSolution { get; set; }
        public string lscType { get; set; }
        public string fuelType { get; set; }
        public string licensePlate { get; set; }
    }


}



