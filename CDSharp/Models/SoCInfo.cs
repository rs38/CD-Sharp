using System;

namespace BMW.Models
{
    public class SoCInfo
    {
        public int id { get; set; }
        public string Vin { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string address { get; set; }
        public string isoCountryCode { get; set; }
        public float auxPowerRegular { get; set; }
        public float auxPowerEcoPro { get; set; }
        public float auxPowerEcoProPlus { get; set; }
        public float soc { get; set; }
        public float socMax { get; set; }
        public string eco { get; set; }
        public string norm { get; set; }
        public string ecoEv { get; set; }
        public string normEv { get; set; }
        public string vehicleMass { get; set; } // wird auch für Soc HV mißbraucht... ;)
        public string kAccReg { get; set; }
        public string kDecReg { get; set; }
        public string kAccEco { get; set; }
        public string kDecEco { get; set; }
        public string kUp { get; set; }
        public string kDown { get; set; }
        public string driveTrain { get; set; }
        public bool pendingUpdate { get; set; }
        public bool vehicleTracking { get; set; }
        public DateTime LastUpdate { get; set; }
    }


}



