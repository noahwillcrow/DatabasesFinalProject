using DatabaseBridge.Models;
using DatabaseBridge.QueryResultModels;
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
                var kidsOnList = context.Database.SqlQuery<KidResultModel>($"SELECT * FROM dbo.{viewName} ORDER BY KidID").ToList();
                var result = new List<Kid>();
                
                foreach (var kid in kidsOnList)
                {
                    result.Add(kid.ConvertToModel());
                }

                return result;
            }
        }

        public static IEnumerable<Kid> GetKidsInHouse(int houseId)
        {
            using (var context = GetContext())
            {
                var kids = context.Database.SqlQuery<KidResultModel>($"dbo.GetKidsInHouse @houseID", new SqlParameter("@houseID", houseId)).ToList();
                var result = new List<Kid>();

                foreach (var kid in kids)
                {
                    result.Add(kid.ConvertToModel());
                }

                return result;
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
