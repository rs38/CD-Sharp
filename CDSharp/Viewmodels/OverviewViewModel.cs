using BMW.Models;
using System;
using System.Collections.Generic;


namespace BMW.Viewmodels
{
    public class OverviewViewModel
    {
        public OverviewViewModel(string sortdir, string sort)
        {
            this.sortdir = sortdir;
            this.sort = sort;
            
        }

        public OverviewViewModel(string vin, string sortdir, string sort)
        {
            this.sortdir = sortdir;
            this.sort = sort;
        }
        public string sortdir { get; set; } = "DESC";

        public string sort { get; set; } = "LastUpdate";

        public string VIN { get; set; }
        public IEnumerable<Lasttrip> Lasttrip { get; set; }

        public virtual IEnumerable<Alltrips> Alltrips { get; set; }


    }
}