namespace PO.Infrastructure.SchemaDefinition
{
    public class WeaponSchemaDefinition : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.Property(x => x.Damage);
            builder.Property(x => x.Speed);
            builder.Property(x => x.TwoHanded);
        }
    }
}
