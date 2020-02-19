using System;


namespace BMW.Viewmodels
{
    public class AllTripsViewModel
    {
        public float Consump { get; set; }

        public float E_Consump { get; set; }

        public float Recu { get; set; }

        public float EDist { get; set; }

        public float ChargeRange { get; set; }

        public float ChargeCycAvg { get; set; }
        public float ChargeCycHigh { get; set; }
        public float ChargeCycCurr { get; set; }
        public float CO2saved { get; set; }

        public DateTime requesttime { get; set; }

        // "chargecycleRange": {
        //    "communityAverage": 121.58,
        //    "communityHigh": 200,
        //    "userAverage": 72.62,
        //    "userHigh": 135,
        //    "userCurrentChargeCycle": 60
        //},
    }
}