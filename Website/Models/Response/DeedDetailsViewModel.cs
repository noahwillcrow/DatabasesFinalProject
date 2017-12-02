using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System;

namespace Website.Models.Response
{
    public class DeedDetailsViewModel
    {

        public int KidID { get; set; }
        public string KidName { get; set; }

        public DateTime TimeOfDeed { get; set; }

        public string Description { get; set; }

        public int Weight { get; set; }

        public bool IsNice { get; set; }

        public DeedDetailsViewModel(Deed deed)
        {
            this.KidID = deed.KidID;
            this.Description = deed.Description;
            this.TimeOfDeed = deed.TimeOfDeed;
            this.Weight = deed.Weight;
            this.IsNice = deed.IsNice;

            var kid = KidsManager.GetByID(deed.KidID);
            this.KidName = kid.Name;
        }
    }
}