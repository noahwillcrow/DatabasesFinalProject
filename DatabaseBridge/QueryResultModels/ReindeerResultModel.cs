using DatabaseBridge.Models;

namespace DatabaseBridge.QueryResultModels
{
    internal class ReindeerResultModel
    {
        public int ReindeerID { get; set; }
        public int CaretakerElfID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Reindeer ConvertToModel()
        {
            return new Reindeer
            {
                ID = this.ReindeerID,
                CaretakerElfID = this.CaretakerElfID,
                Name = this.Name,
                Status = this.Status
            };
        }
    }
}
