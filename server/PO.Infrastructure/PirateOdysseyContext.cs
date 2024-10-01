using Microsoft.EntityFrameworkCore;
using PO.Domain.Repositories.Base;
using PO.Infrastructure.SchemaDefinition;

namespace PO.Infrastructure
{
    public class PirateOdysseyContext(DbContextOptions options) : DbContext(options), IUnitOfWork
    {
        #region Item
        
        public DbSet<Item> Items { get; set; }
        public DbSet<Equipment> Equipment { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ItemSchemaDefinition());
            modelBuilder.ApplyConfiguration(new EquipmentSchemaDefinition());
        }
    }
}
