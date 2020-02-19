using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BMW.Models
{
    public class AppState
    {
        public int Id { get; set; }
        public string CurrentToken { get; set; }
        public DateTime TokenExpireTime { get; set; }

    }
    public class MyCars
    {
        public Vehicle[] vehicles { get; set; }
    }

    public class Position
    {
        public double lat { get; set; }
        public double lon { get; set; }
        public int heading { get; set; }
        public string status { get; set; }
    }

    public class Lasttrip
    {
        public int id { get; set; }
        public DateTime requestTime { get; set; }
        public virtual Vehicle vehicle { get; set; }
        public float efficiencyValue { get; set; }
        public int totalDistance { get; set; }
        public float electricDistance { get; set; }
        public float avgElectricConsumption { get; set; }
        public float avgRecuperation { get; set; }
        public float drivingModeValue { get; set; }
        public float accelerationValue { get; set; }
        public float anticipationValue { get; set; }
        public int chargingBehaviorValue { get; set; }
        public float electricDistanceShareValue { get; set; }
        public float totalConsumptionValue { get; set; }
        public float auxiliaryConsumptionValue { get; set; }
        public float avgCombinedConsumption { get; set; }
        public float electricDistanceRatio { get; set; }
        public float savedFuel { get; set; }
        public DateTime date { get; set; }
        public int duration { get; set; }
    }
    public class Alltrips
    {
        public int id { get; set; }
        public DateTime requestTime { get; set; }
        public virtual Vehicle vehicle { get; set; }
        public Avgelectricconsumption avgElectricConsumption { get; set; }
        public Avgrecuperation avgRecuperation { get; set; }
        public Chargecyclerange chargecycleRange { get; set; }
        public virtual Totalelectricdistance totalElectricDistance { get; set; }
        public Avgcombinedconsumption avgCombinedConsumption { get; set; }
        public float savedCO2 { get; set; }
        public float savedCO2greenEnergy { get; set; }
        public int totalSavedFuel { get; set; }
        public DateTime resetDate { get; set; }
        public int batterySizeMax { get; set; }
    }

    public class Avgelectricconsumption
    {
        public float communityLow { get; set; }
        public float communityAverage { get; set; }
        public float communityHigh { get; set; }
        public float userAverage { get; set; }
    }

    public class Avgrecuperation
    {
        public int communityLow { get; set; }
        public float communityAverage { get; set; }
        public float communityHigh { get; set; }
        public float userAverage { get; set; }
    }

    public class Chargecyclerange
    {
        public float communityAverage { get; set; }
        public float communityHigh { get; set; }
        public float userAverage { get; set; }
        public float userHigh { get; set; }
        public float userCurrentChargeCycle { get; set; }
    }

    public class Totalelectricdistance
    {
        public float communityLow { get; set; }
        public float communityAverage { get; set; }
        public float communityHigh { get; set; }
        public float userTotal { get; set; }
    }
    public class Avgcombinedconsumption
    {
        public float communityLow { get; set; }
        public float communityAverage { get; set; }
        public float communityHigh { get; set; }
        public float userAverage { get; set; }
    }


}



