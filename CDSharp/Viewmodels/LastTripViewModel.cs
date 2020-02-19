using System;
using System.ComponentModel.DataAnnotations;

namespace BMW.Viewmodels
{
    public class LastTripViewModel
    {
        public int Id { get; set; }

        public float L_100km { get; set; }

        public float kWh_100km { get; set; }

        [DisplayFormat(DataFormatString = "{0:F0}")]
        public float Recu { get; set; }

        public float EDistance { get; set; }

        public float Efficiency { get; set; }

        public float Eff_a { get; set; }
        public float Eff_Ant{ get; set; }

        public int Distance { get; set; }

        public int Duration { get; set; }

        [DisplayFormat(DataFormatString = "{0:F0}")]
        public string SpeedAvg { get; set; }

        [DisplayFormat(DataFormatString = "{0:F1}")]
        public string RexConsump { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd.MM.YY HH:mm}")]
        public DateTime Requesttime {
            get;
            set; }

        [Display(Name = "Servertime")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.YY HH:mm}" )]
        public DateTime Date {
            get;
            set; }
    }
}