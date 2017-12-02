using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class ElvesManager : DataManager<Elf>
    {
        //returns a list of all elves and their parameters
        public static IEnumerable<Elf> GetPaginatedList()
        {
            using (var context = GetContext())
            {
                var elvesOnList = context.Database.SqlQuery<Elf>($"SELECT * FROM dbo ORDER BY ElfID").ToList();
                return elvesOnList;
            }      
        }

        //returns a list of presents allotted to an elf with id elfId
        public static IEnumerable<Present> GetPresents(int elfID)
        {
            using (var context = GetContext())
            {
                var presentsOnList = context.Database.SqlQuery<Present>("dbo.GetPresentsForElf", new SqlParameter("@elfId", elfID));
                return presentsOnList;
            }
        }

        //returns a list of all reindeer allotted to an elf with id elfId
        public static IEnumerable<Reindeer> GetReindeer(int elfID)
        {
            using (var context = GetContext())
            {
                var reindeerOnList = context.Database.SqlQuery<Reindeer>("dbo.GetReindeerForElf", new SqlParameter("@elfId", elfID));
                return reindeerOnList;
            }
        }
    }
}
