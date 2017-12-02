using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class HousesManager : DataManager<House>
    {

        public static IEnumerable<House> GetHousesWithOnlyNiceKids()
        {
            using (var context = GetContext())
            {
                var houses = context.Database.SqlQuery<House>($"SELECT * FROM dbo.HousesWithOnlyNiceKids ORDER BY HouseID").ToList();
                return houses;
            }
        }

    }
}
