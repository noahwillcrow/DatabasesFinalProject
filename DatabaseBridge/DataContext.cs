using DatabaseBridge.Models;
using System.Data.Entity;

namespace DatabaseBridge
{
    public class DataContext : DbContext
    {

        static DataContext()
        {
            Database.SetInitializer<DataContext>(null);
        }

        public DataContext()
            : base("Name=DataConnection")
        {
        }

        public DbSet<Deed> Deeds { get; set; }
        public DbSet<Elf> Elfs { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Kid> Kids { get; set; }
        public DbSet<Present> Presents { get; set; }
        public DbSet<Reindeer> Reindeers { get; set; }

    }
}
