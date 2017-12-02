using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class ItemUpdateRequestViewModel
    {
        public string Name { get; set; }

        public void UpdateItemModel(Item item)
        {
            item.Name = this.Name;
        }
    }
}