namespace PO.Domain.Entities
{
    public class Crew
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // FK

        public ICollection<CrewMember> CrewMembers { get; set; } = [];
    }
}
