using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System.Collections.Generic;

namespace Website.Models.Response
{
    public class HouseDetailsViewModel
    {
        
        public int ID { get; set; }

        public string FamilyName { get; set; }

        public string Address { get; set; }

        public bool HasChimney { get; set; }

        public IEnumerable<Kid> Kids { get; set; }

        public HouseDetailsViewModel(House house)
        {
            this.ID = house.ID;
            this.FamilyName = house.FamilyName;
            this.Address = house.Address;
            this.HasChimney = house.HasChimney;

            Kids = KidsManager.GetKidsInHouse(house.ID);
        }

    }
}