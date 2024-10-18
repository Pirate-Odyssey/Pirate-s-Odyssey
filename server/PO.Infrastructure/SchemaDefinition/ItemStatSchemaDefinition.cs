namespace PO.Infrastructure.SchemaDefinition
{
    public class ItemStatSchemaDefinition : IEntityTypeConfiguration<ItemStat>
    {
        public void Configure(EntityTypeBuilder<ItemStat> builder)
        {
            builder.ToTable(nameof(ItemStat));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Stats).HasConversion<string>().HasMaxLength(20);
            builder.Property(x => x.Value);

            builder.HasOne(x => x.Item)
                .WithMany(y => y.Stats)
                .HasForeignKey(x => x.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
