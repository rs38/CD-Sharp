using System;

namespace BMW.Viewmodels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
        }

        public int Km { get; set; }
        public DateTime UpdateTime { get; set; }
        public string door { get; set; }
        public int ChargeLevel { get; set; }
        public int fuel { get; set; }
        public int ERange { get; set; }
    }
}