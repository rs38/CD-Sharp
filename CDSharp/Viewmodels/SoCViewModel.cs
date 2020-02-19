using System;


namespace BMW.Viewmodels
{
    public class SoCViewModel
    {
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float auxPowerRegular { get; set; }
        public float auxPowerEcoPro { get; set; }
          public float soc { get; set; }
        public float socMax { get; set; }
        public float SocHV { get; set; } //wird aus Vehiclemass bezogen
        public DateTime Lastupdate { get; set; }


    }
}