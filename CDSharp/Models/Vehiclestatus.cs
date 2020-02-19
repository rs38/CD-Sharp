using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BMW.Models
{
    public class Vehiclestatus
    {
        public int id { get; set; }

        [Display(AutoGenerateField = false, Name = "VIN")]
        [DisplayName("VIN")]
        public string vin { get; set; }
        public DateTime LastUpdate { get; set; }
        public int mileage { get; set; }
        public string updateReason { get; set; }
        public DateTime updateTime { get; set; }
        public string doorDriverFront { get; set; }
        public string doorPassengerFront { get; set; }
        public string windowDriverFront { get; set; }
        public string windowPassengerFront { get; set; }
        public string trunk { get; set; }
        public string rearWindow { get; set; }
        public string hood { get; set; }
        public string doorLockState { get; set; }
        public string parkingLight { get; set; }
        public string positionLight { get; set; }
        public int remainingFuel { get; set; }
        public int remainingRangeElectric { get; set; }
        public int remainingRangeElectricMls { get; set; }
        public int remainingRangeFuel { get; set; }
        public int remainingRangeFuelMls { get; set; }
        public int maxRangeElectric { get; set; }
        public int maxRangeElectricMls { get; set; }
        public int maxFuel { get; set; }
        public string connectionStatus { get; set; }
        public string chargingStatus { get; set; }
        public int chargingLevelHv { get; set; }
        public string lastChargingEndReason { get; set; }
        public string lastChargingEndResult { get; set; }
        public Position position { get; set; }
        public DateTime internalDataTimeUTC { get; set; }
        public bool singleImmediateCharging { get; set; }
        public string chargingConnectionType { get; set; }
        public string steering { get; set; }
        // public object[] checkControlMessages { get; set; }
        //public Cbsdata[] cbsData { get; set; }
    }


}



