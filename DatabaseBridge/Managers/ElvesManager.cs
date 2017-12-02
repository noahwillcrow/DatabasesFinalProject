using DatabaseBridge.Models;
using DatabaseBridge.QueryResultModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class ElvesManager : DataManager<Elf>
    {
        /// <summary>
        /// Returns a list of presents allotted to an elf with id elfId
        /// </summary>
        /// <param name="elfID">The elf that made the presents</param>
        public static IEnumerable<Present> GetPresents(int elfId)
        {
            using (var context = GetContext())
            {
                var presentsOnList = context.Database.SqlQuery<Present>("dbo.GetPresentsForElf @elfID", new SqlParameter("elfID", elfId)).ToList();
                return presentsOnList;
            }
        }

        /// <summary>
        /// Returns a list of reindeer allotted to an elf with id elfId
        /// </summary>
        /// <param name="elfID">The elf that takes care of the reindeer</param>
        public static IEnumerable<Reindeer> GetReindeer(int elfId)
        {
            using (var context = GetContext())
            {
                var reindeerOnList = context.Database.SqlQuery<ReindeerResultModel>("dbo.GetReindeerForElf @elfID", new SqlParameter("elfID", elfId)).ToList();
                var result = new List<Reindeer>();
                foreach (var reindeer in reindeerOnList)
                {
                    result.Add(reindeer.ConvertToModel());
                }
                return result;
            }
        }

        /// <summary>
        /// Returns the ratio of salary to presents made
        /// </summary>
        /// <param name="elfID">The elf that made the presents</param>
        public static double GetSalaryToPresentsRatio(int elfId)
        {
            using (var context = GetContext())
            {
                var ratio = context.Database.SqlQuery<double>("SELECT dbo.CalculateEarningsRatio(@elfID)", new SqlParameter("elfID", elfId)).FirstOrDefault();
                return ratio;
            }
        }
    }
}
