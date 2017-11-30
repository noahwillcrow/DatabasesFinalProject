using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class HousesManager : DataManager<House>
    {

        public static IEnumerable<House> GetHousesWithOnlyNiceKids(int pagesize, int pagenumber)
        {
            var skippedEntities = pagesize * (pagenumber - 1);
            using (var context = GetContext())
            {
                var houses = context.Database.SqlQuery<House>($"SELECT * FROM dbo.HousesWithOnlyNiceKids ORDER BY HouseID SKIP {skippedEntities} TAKE {pagesize}").ToList();
                return houses;
            }
        }

    }
}
