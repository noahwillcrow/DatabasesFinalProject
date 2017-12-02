using DatabaseBridge.Models;
using System;

namespace Website.Models.Response
{
    public class DeedUpdateResponseViewModel
    {
        public int KidID { get; set; }
        
        public DateTime TimeOfDeed { get; set; }

        public string Description { get; set; }
        
        public int Weight { get; set; }

        public bool IsNice { get; set; }

        public bool UpdateSuccess { get; set; }

        public DeedUpdateResponseViewModel()
        {
        }

        public DeedUpdateResponseViewModel(Deed deed)
        {
            this.KidID = deed.KidID;
            this.TimeOfDeed = deed.TimeOfDeed;
            this.Description = deed.Description;
            this.Weight = deed.Weight;
            this.IsNice = deed.IsNice;
        }
    }
}