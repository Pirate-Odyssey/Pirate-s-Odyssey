namespace PO.Infrastructure.SchemaDefinition
{
    public class CrewSchemaDefinition : IEntityTypeConfiguration<Crew>
    {
        public void Configure(EntityTypeBuilder<Crew> builder)
        {
            builder.ToTable(nameof(Crew));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50);
        }
    }
}
