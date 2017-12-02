using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class ReindeerUpdateRequestViewModel
    {
        public int CaretakerElfID { get; set; }

        public string Name { get; set; }

        public string Status { get; set; }

        public void UpdateReindeerModel(Reindeer reindeer)
        {
            reindeer.CaretakerElfID = this.CaretakerElfID;
            reindeer.Name = this.Name;
            reindeer.Status = this.Status;
        }
    }
}