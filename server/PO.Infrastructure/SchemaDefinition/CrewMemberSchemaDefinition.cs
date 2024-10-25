namespace PO.Infrastructure.SchemaDefinition
{
    public class CrewMemberSchemaDefinition : IEntityTypeConfiguration<CrewMember>
    {
        public void Configure(EntityTypeBuilder<CrewMember> builder)
        {
            builder.ToTable(nameof(CrewMember));

            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Crew)
                .WithMany(y => y.CrewMembers)
                .HasForeignKey(x => x.CrewId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Ship)
                .WithMany(y => y.CrewMembers)
                .HasForeignKey(x => x.ShipId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
