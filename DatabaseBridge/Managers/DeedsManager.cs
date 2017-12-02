using DatabaseBridge.Models;
using NwcLib.Utils;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class DeedsManager
    {
        public static Deed GetDeeds(int kidID, System.DateTime timeOfDeed)
        {
            using (var context = new DataContext())
            {
                return context.Deeds.FirstOrDefault(e => e.KidID == kidID && e.TimeOfDeed == timeOfDeed);
            }
        }

        public static IEnumerable<Deed> GetAll()
        {
            using (var context = new DataContext())
            {
                return context.Deeds.ToList();
            }
        }

        public static bool Save(Deed newData)
        {
            using (var context = new DataContext())
            {
                var table = context.Deeds;

                var oldData = table.SingleOrDefault(e => e.KidID == newData.KidID && e.TimeOfDeed == newData.TimeOfDeed);
                if (oldData == null)
                {
                    table.Add(newData);
                }
                else
                {
                    string[] dontAlter = new string[] { "KidID", "TimeOfDeed" };
                    ModelUtils.MergeChanges(ref newData, ref oldData, dontAlter);
                }

                return context.SaveChanges() > 0;
            }
        }
    }
}
