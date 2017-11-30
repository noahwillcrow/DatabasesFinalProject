﻿using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DatabaseBridge.Managers
{
    public class KidsManager : DataManager<Kid>
    {

        public static IEnumerable<Kid> GetPaginatedList(bool isNice, int pagesize, int pagenumber)
        {
            var viewName = isNice ? "NiceKids" : "NaughtyKids";
            var skippedEntities = pagesize * (pagenumber - 1);
            using (var context = GetContext())
            {
                var kidsOnList = context.Database.SqlQuery<Kid>($"SELECT * FROM dbo.{viewName} ORDER BY KidID SKIP {skippedEntities} TAKE {pagesize}").ToList();
                return kidsOnList;
            }
        }

        public static bool IsKidNice(int kidId)
        {
            using (var context = GetContext()) {
                var niceness = context.Database.SqlQuery<int>("SELECT dbo.CalculateNiceness(@kidId)", new SqlParameter("kidId", kidId)).First();
                return niceness > 0;
            }
        }

        public static IEnumerable<Deed> GetDeeds(int kidId)
        {
            using (var context = GetContext())
            {
                var deeds = context.Database.SqlQuery<Deed>("dbo.GetDeedsForKid", new SqlParameter("kidId", kidId)).ToList();
                return deeds;
            }
        }

        public static IEnumerable<Present> GetPresents(int kidId)
        {
            using (var context = GetContext())
            {
                var presents = context.Database.SqlQuery<Present>("dbo.GetPresentsForKid", new SqlParameter("kidId", kidId)).ToList();
                return presents;
            }
        }

    }
}