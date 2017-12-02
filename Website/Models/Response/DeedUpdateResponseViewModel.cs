using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class DeedUpdateResponseViewModel
    {
        public string description { get; set; }
        
        public int weight { get; set; }

        public bool isNice { get; set; }

        public bool UpdateSuccess { get; set; }

        public DeedUpdateResponseViewModel()
        {
        }

        public DeedUpdateResponseViewModel(Deed deed)
        {
            this.description = deed.Description;
            this.weight = deed.Weight;
            this.isNice = deed.IsNice;
        }
    }
}