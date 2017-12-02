using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class HouseUpdateRequestViewModel
    {
        public string FamilyName { get; set; }

        public string Address { get; set; }

        public bool HasChimney { get; set; }

        public void UpdateHouseModel(House house)
        {
            house.FamilyName = this.FamilyName;
            house.Address = this.Address;
            house.HasChimney = this.HasChimney;
        }
    }
}