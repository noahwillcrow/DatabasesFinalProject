using DatabaseBridge.Models;
using System.Collections.Generic;

namespace Website.Models.Response
{
    public class DeedDetailsViewModel
    {

        public System.DateTime timeOfDeed { get; set; }

        public int kidID { get; set; }

        public string description { get; set; }

        public int weight { get; set; }

        public bool isNice { get; set; }

        public DeedDetailsViewModel(Deed deed)
        {
            this.kidID = deed.KidID;
            this.description = deed.Description;
            this.timeOfDeed = deed.TimeOfDeed;
            this.weight = deed.Weight;
            this.isNice = deed.IsNice;
        }
    }
}