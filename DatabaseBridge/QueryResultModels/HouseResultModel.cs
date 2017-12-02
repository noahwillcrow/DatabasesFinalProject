using DatabaseBridge.Models;

namespace DatabaseBridge.QueryResultModels
{
    internal class HouseResultModel
    {
        public int HouseID { get; set; }
        public string Address { get; set; }
        public string FamilyName { get; set; }
        public bool HasChimney { get; set; }

        public House ConvertToModel()
        {
            return new House
            {
                ID = this.HouseID,
                Address = this.Address,
                FamilyName = this.FamilyName,
                HasChimney = this.HasChimney
            };
        }
    }
}
