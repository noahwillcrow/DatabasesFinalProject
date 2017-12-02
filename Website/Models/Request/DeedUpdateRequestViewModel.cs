using DatabaseBridge.Models;
using System;

namespace Website.Models.Request
{
    public class DeedUpdateRequestViewModel
    {
        public int KidID { get; set; }

        public DateTime TimeOfDeed { get; set; }

        public string Description { get; set; }

        public int Weight { get; set; }

        public bool IsNice { get; set; }

        public void UpdateDeedModel(Deed deed)
        {
            if (deed.KidID == 0)
            {
                deed.KidID = this.KidID;
                deed.TimeOfDeed = this.TimeOfDeed;
            }
            deed.Description = this.Description;
            deed.Weight = this.Weight;
            deed.IsNice = this.IsNice;
        }
    }
}