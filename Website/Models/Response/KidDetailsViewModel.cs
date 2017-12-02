using DatabaseBridge.Models;
using System.Collections.Generic;

namespace Website.Models.Response
{
    public class KidDetailsViewModel
    {
        
        public int ID { get; set; }

        public int HouseID { get; set; }

        public string FamilyName { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public bool IsNice { get; set; }

        public IEnumerable<Deed> Deeds { get; set; }

        public IEnumerable<PresentDetailsViewModel> Presents { get; set; }

        public KidDetailsViewModel(Kid kid, bool isNice, IEnumerable<Deed> deeds, IEnumerable<Present> presents)
        {
            this.ID = kid.ID;
            this.HouseID = kid.HouseID;
            this.Name = kid.Name;
            this.Gender = kid.Gender;
            this.Age = kid.Age;
            this.IsNice = isNice;
            this.Deeds = deeds;

            var house = DatabaseBridge.Managers.DataManager<House>.GetByID(kid.HouseID);
            FamilyName = house.FamilyName;

            var presentViewModels = new List<PresentDetailsViewModel>();
            foreach (var present in presents)
            {
                presentViewModels.Add(new PresentDetailsViewModel(present));
            }
            this.Presents = presentViewModels;
        }

    }
}