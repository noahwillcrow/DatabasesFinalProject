using DatabaseBridge.Models;

namespace DatabaseBridge.QueryResultModels
{
    internal class KidResultModel
    {
        public int KidID { get; set; }
        public int HouseID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public Kid ConvertToModel()
        {
            return new Kid
            {
                ID = this.KidID,
                HouseID = this.HouseID,
                Name = this.Name,
                Gender = this.Gender,
                Age = this.Age
            };
        }
    }
}
