using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class HouseUpdateResponseViewModel
    {
        public string FamilyName { get; set; }

        public string Address { get; set; }

        public bool HasChimney { get; set; }

        public bool UpdateSuccess { get; set; }

        public HouseUpdateResponseViewModel() { }

        public HouseUpdateResponseViewModel(House house)
        {
            this.FamilyName = house.FamilyName;
            this.Address = house.Address;
            this.HasChimney = house.HasChimney;
        }       
    }
}