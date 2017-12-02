using DatabaseBridge.Managers;
using DatabaseBridge.Models;

namespace Website.Models
{
    public class PresentViewModel
    {
        public int KidID { get; set; }
        public string KidName { get; set; }

        public int ItemID { get; set; }
        public string ItemName { get; set; }

        public int ElfID { get; set; }
        public string ElfName { get; set; }

        public bool IsDone { get; set; }

        public PresentViewModel(Present present)
        {
            var kid = KidsManager.GetByID(present.KidID);
            this.KidID = present.KidID;
            this.KidName = kid.Name;

            var item = DataManager<Item>.GetByID(present.ItemID);
            this.ItemID = present.ItemID;
            this.ItemName = item.Name;

            var elf = ElvesManager.GetByID(present.ElfID);
            this.ElfID = present.ElfID;
            this.ElfName = elf.Name;

            this.IsDone = present.IsDone;
        }
    }
}