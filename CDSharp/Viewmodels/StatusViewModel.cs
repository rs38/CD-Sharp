using System;
using System.ComponentModel.DataAnnotations;


namespace BMW.Viewmodels
{
    public class StatusViewModel
    {
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }

        public int SoC { get; set; }

        public string DoorState { get; set; }

        public int KM { get; set; }

        public int ERange { get; set; }

        public int FuelRange { get; set; }

        public int Fuel { get; set; }
        public int MaxERange { get; set; }
        [DisplayFormat(DataFormatString = "{0:F6}")]
        public double PosLong { get; set; }
        [DisplayFormat(DataFormatString = "{0:F6}")]
        public double PosLat { get; set; }

        public string PosStatus { get; set; }
    }
}