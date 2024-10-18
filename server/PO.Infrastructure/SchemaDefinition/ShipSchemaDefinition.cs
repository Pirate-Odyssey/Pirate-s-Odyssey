namespace PO.Infrastructure.SchemaDefinition
{
    public class ShipSchemaDefinition : IEntityTypeConfiguration<Ship>
    {
        public void Configure(EntityTypeBuilder<Ship> builder)
        {
            builder.ToTable(nameof(Ship));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Speed);
            builder.Property(x => x.Health);
            builder.Property(x => x.MinSeat);
            builder.Property(x => x.MaxSeat);
        }
    }
}
