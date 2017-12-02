using DatabaseBridge.Models;
using System.Collections.Generic;

namespace Website.Models.Response
{
    public class ReindeerDetailsViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int CaretakerElfID { get; set; }

        public string Status { get; set; }

        public ReindeerDetailsViewModel(Reindeer reindeer)
        {
            this.ID = reindeer.ID;
            this.Name = reindeer.Name;
            this.CaretakerElfID = reindeer.CaretakerElfID;
            this.Status = reindeer.Status;
        }
    }
}