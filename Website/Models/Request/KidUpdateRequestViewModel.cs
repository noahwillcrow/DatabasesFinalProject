using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class KidUpdateRequestViewModel
    {

        public int HouseID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public void UpdateKidModel(Kid kid)
        {
            kid.HouseID = this.HouseID;
            kid.Name = this.Name;
            kid.Gender = this.Gender;
            kid.Age = this.Age;
        }

    }
}