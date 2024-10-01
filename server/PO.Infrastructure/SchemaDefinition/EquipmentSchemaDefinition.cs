namespace PO.Infrastructure.SchemaDefinition
{
    public class EquipmentSchemaDefinition : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(x => x.Type).HasConversion<string>().HasMaxLength(20);
        }
    }
}
