using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class ItemUpdateResponseViewModel
    {
        public string Name { get; set; }
        public bool UpdateSuccess { get; set; }

        public ItemUpdateResponseViewModel()
        {
        }

        public ItemUpdateResponseViewModel(Item item)
        {
            this.Name = item.Name;
        }
    }
}