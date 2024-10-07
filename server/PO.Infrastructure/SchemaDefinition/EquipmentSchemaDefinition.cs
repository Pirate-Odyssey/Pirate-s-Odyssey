namespace PO.Infrastructure.SchemaDefinition
{
    public class EquipmentSchemaDefinition : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(x => x.Armor);
            builder.Property(x => x.EquipmentType).HasConversion<string>().HasMaxLength(20);
        }
    }
}
