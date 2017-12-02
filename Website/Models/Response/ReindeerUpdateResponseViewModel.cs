using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class ReindeerUpdateResponseViewModel
    {
        public int ReindeerID { get; set; }

        public int CaretakerElfID { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public bool UpdateSuccess { get; set; }

        public ReindeerUpdateResponseViewModel()
        {
        }

        public ReindeerUpdateResponseViewModel(Reindeer reindeer)
        {
            this.ReindeerID = reindeer.ID;
            this.CaretakerElfID = reindeer.CaretakerElfID;
            this.Name = reindeer.Name;
            this.Status = reindeer.Status;
        }

    }
}