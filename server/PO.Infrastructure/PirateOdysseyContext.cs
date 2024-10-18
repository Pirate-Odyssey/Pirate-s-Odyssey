using System.Reflection;

namespace PO.Infrastructure
{
    public class PirateOdysseyContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        #region Item

        public DbSet<Item> Items { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<ItemStat> ItemStats { get; set; }
        public DbSet<Ship> Ships { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
