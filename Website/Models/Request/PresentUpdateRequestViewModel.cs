using DatabaseBridge.Models;

namespace Website.Models.Request
{
    public class PresentUpdateRequestViewModel
    {
        public int KidID { get; set; }

        public int ItemID { get; set; }

        public int ElfID { get; set; }

        public bool IsDone { get; set; }

        public bool UpdateSuccess { get; set; }

        public void UpdatePresentModel(Present present)
        {
            if (this.KidID > 0 && this.ItemID > 0)
            {
                present.KidID = this.KidID;
                present.ItemID = this.ItemID;
            }

            present.ElfID = this.ElfID;
            present.IsDone = this.IsDone;
        }       
    }
}