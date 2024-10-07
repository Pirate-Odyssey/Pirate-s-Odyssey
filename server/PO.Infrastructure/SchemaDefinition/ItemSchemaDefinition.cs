using PO.Domain.Entities.Enums;

namespace PO.Infrastructure.SchemaDefinition
{
    public class ItemSchemaDefinition : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(nameof(Item));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Rarity).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.Price);
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);

            builder.HasDiscriminator(x => x.Type)
                .HasValue<Item>(ItemType.Trash)
                .HasValue<Equipment>(ItemType.Equipment)
                .HasValue<Weapon>(ItemType.Weapon);

            builder.HasMany(x => x.Stats)
                .WithOne(y => y.Item)
                .HasForeignKey(y => y.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
