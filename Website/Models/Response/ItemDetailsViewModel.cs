using DatabaseBridge.Models;
using System.Collections.Generic;

namespace Website.Models.Response
{
    public class ItemDetailsViewModel
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public ItemDetailsViewModel(Item item)
        {
            this.ID = item.ID;
            this.Name = item.Name;
        }
    }
}