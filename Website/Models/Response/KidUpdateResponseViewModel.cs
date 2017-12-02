using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class KidUpdateResponseViewModel
    {

        public int HouseID { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public bool UpdateSuccess { get; set; }

        public KidUpdateResponseViewModel() { }

        public KidUpdateResponseViewModel(Kid kid)
        {
            this.HouseID = kid.HouseID;
            this.Name = kid.Name;
            this.Gender = kid.Gender;
            this.Age = kid.Age;
        }

    }
}