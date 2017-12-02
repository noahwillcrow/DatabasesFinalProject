using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class DeedUpdateRequestViewModel
    {
        public string description { get; set; }

        public int weight { get; set; }

        public bool isNice { get; set; }

        public void UpdateDeedModel(Deed deed)
        {
            deed.Description = this.description;
            deed.Weight = this.weight;
            deed.IsNice = this.isNice;
        }
    }
}