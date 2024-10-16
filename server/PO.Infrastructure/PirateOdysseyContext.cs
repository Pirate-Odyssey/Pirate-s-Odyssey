using PO.Infrastructure.SchemaDefinition;

namespace PO.Infrastructure
{
    public class PirateOdysseyContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        #region Item

        public DbSet<Item> Items { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<ItemStat> ItemStats { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemSchemaDefinition());
            modelBuilder.ApplyConfiguration(new EquipmentSchemaDefinition());
            modelBuilder.ApplyConfiguration(new WeaponSchemaDefinition());
            modelBuilder.ApplyConfiguration(new ItemStatSchemaDefinition());
        }
    }
}
