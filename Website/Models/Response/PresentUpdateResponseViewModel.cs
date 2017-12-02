using DatabaseBridge.Models;

namespace Website.Models.Response
{
    public class PresentUpdateResponseViewModel
    {
        public int KidID { get; set; }

        public int ItemID { get; set; }

        public int ElfID { get; set; }

        public bool IsDone { get; set; }

        public bool UpdateSuccess { get; set; }

        public PresentUpdateResponseViewModel() { }

        public PresentUpdateResponseViewModel(Present present)
        {
            this.KidID = present.KidID;
            this.ItemID = present.ItemID;
            this.ElfID = present.ElfID;
            this.IsDone = present.IsDone;
        }       
    }
}