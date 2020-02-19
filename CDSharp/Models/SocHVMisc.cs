namespace BMW.Models
{
  
        public class SocHVMisc
    {
            public Attributesmap attributesMap { get; set; }
            public Vehiclemessages vehicleMessages { get; set; }
        }

        public class Attributesmap
        {
            public string updateTime_converted { get; set; }
            public string shdStatusUnified { get; set; }
            public string condition_based_services { get; set; }
            public string door_lock_state { get; set; }
            public string vehicle_tracking { get; set; }
            public string Segment_LastTrip_time_segment_end_formatted_time { get; set; }
            public string lastChargingEndReason { get; set; }
            public string door_passenger_front { get; set; }
            public string charging_inductive_positioning { get; set; }
            public string check_control_messages { get; set; }
            public string chargingHVStatus { get; set; }
            public string beMaxRangeElectricMile { get; set; }
            public string lights_parking { get; set; }
            public string beRemainingRangeFuelKm { get; set; }
            public string connectorStatus { get; set; }
            public string kombi_current_remaining_range_fuel { get; set; }
            public string beRemainingRangeElectricMile { get; set; }
            public string window_passenger_front { get; set; }
            public string mileage { get; set; }
            public string door_driver_front { get; set; }
            public string updateTime { get; set; }
            public string window_passenger_rear { get; set; }
            public string Segment_LastTrip_time_segment_end { get; set; }
            public string remaining_fuel { get; set; }
            public string updateTime_converted_time { get; set; }
            public string window_driver_front { get; set; }
            public string chargeNowAllowed { get; set; }
            public string unitOfCombustionConsumption { get; set; }
            public string beMaxRangeElectric { get; set; }
            public string soc_hv_percent { get; set; }
            public string single_immediate_charging { get; set; }
            public string beRemainingRangeElectric { get; set; }
            public string heading { get; set; }
            public object DCS_CCH_Ongoing { get; set; }
            public string sunroof_state { get; set; }
            public string charging_connection_type { get; set; }
            public string Segment_LastTrip_time_segment_end_formatted { get; set; }
            public string updateTime_converted_timestamp { get; set; }
            public string window_driver_rear { get; set; }
            public string lastChargingEndResult { get; set; }
            public string trunk_state { get; set; }
            public string hood_state { get; set; }
            public string chargingLevelHv { get; set; }
            public string lastUpdateReason { get; set; }
            public string beRemainingRangeFuel { get; set; }
            public string sunroof_position { get; set; }
            public string lsc_trigger { get; set; }
            public string unitOfEnergy { get; set; }
            public string Segment_LastTrip_time_segment_end_formatted_date { get; set; }
            public string prognosisWhileChargingStatus { get; set; }
            public string beMaxRangeElectricKm { get; set; }
            public string unitOfElectricConsumption { get; set; }
            public string Segment_LastTrip_ratio_electric_driven_distance { get; set; }
            public string head_unit_pu_software { get; set; }
            public object DCS_CCH_Activation { get; set; }
            public string head_unit { get; set; }
            public string chargingSystemStatus { get; set; }
            public string door_driver_rear { get; set; }
            public string charging_status { get; set; }
            public string beRemainingRangeFuelMile { get; set; }
            public string beRemainingRangeElectricKm { get; set; }
            public string door_passenger_rear { get; set; }
            public string updateTime_converted_date { get; set; }
            public string unitOfLength { get; set; }
            public string chargingLogicCurrentlyActive { get; set; }
            public string battery_size_max { get; set; }
        }

        public class Vehiclemessages
        {
            public object[] ccmMessages { get; set; }
            public Cbsmessage[] cbsMessages { get; set; }
        }

        public class Cbsmessage
        {
            public string description { get; set; }
            public string text { get; set; }
            public int id { get; set; }
            public string status { get; set; }
            public string messageType { get; set; }
            public string date { get; set; }
        }

    }
