using DatabaseBridge.Models;
using NwcLib.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class PresentsManager
    {
        public static Present GetPresent(int kidId, int itemId)
        {
            using (var context = new DataContext())
            {
                return context.Presents.FirstOrDefault(e => e.KidID == kidId && e.ItemID == itemId);
            }
        }

        public static IEnumerable<Present> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Presents.ToList();
            }
        }

        public static bool Save(Present newData)
        {
            using (var context = new DataContext())
            {
                var table = context.Presents;

                var oldData = table.SingleOrDefault(e => e.KidID == newData.KidID && e.ItemID == newData.ItemID);
                if (oldData == null)
                {
                    table.Add(newData);
                }
                else
                {
                    string[] dontAlter = new string[] { "KidID", "ItemID" };
                    ModelUtils.MergeChanges(ref newData, ref oldData, dontAlter);
                }

                return context.SaveChanges() > 0;
            }
        }
    }
}
