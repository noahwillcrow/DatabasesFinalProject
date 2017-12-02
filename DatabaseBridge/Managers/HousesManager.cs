using DatabaseBridge.Models;
using DatabaseBridge.QueryResultModels;
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
                var houses = context.Database.SqlQuery<HouseResultModel>($"SELECT * FROM dbo.HousesWithOnlyNiceKids ORDER BY HouseID").ToList();
                var result = new List<House>();

                foreach (var house in houses)
                {
                    result.Add(house.ConvertToModel());
                }

                return result;
            }
        }

    }
}
