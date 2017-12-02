using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class KidsManager : DataManager<Kid>
    {

        public static IEnumerable<Kid> GetList(bool isNice)
        {
            var viewName = isNice ? "NiceKids" : "NaughtyKids";
            using (var context = GetContext())
            {
                var kidsOnList = context.Database.SqlQuery<Kid>($"SELECT * FROM dbo.{viewName} ORDER BY KidID").ToList();
                return kidsOnList;
            }
        }

        public static bool IsKidNice(int kidId)
        {
            using (var context = GetContext())
            {
                var niceness = context.Database.SqlQuery<int>("SELECT dbo.CalculateNiceness(@kidId)", new SqlParameter("@kidID", kidId)).First();
                return niceness > 0;
            }
        }

        public static IEnumerable<Deed> GetDeeds(int kidId)
        {
            using (var context = GetContext())
            {
                var deeds = context.Database.SqlQuery<Deed>("dbo.GetDeedsForKid @kidID", new SqlParameter("kidID", kidId)).ToList();
                return deeds;
            }
        }

        public static IEnumerable<Present> GetPresents(int kidId)
        {
            using (var context = GetContext())
            {
                var presents = context.Database.SqlQuery<Present>("dbo.GetPresentsForKid @kidID", new SqlParameter("@kidID", kidId)).ToList();
                return presents;
            }
        }

    }
}
