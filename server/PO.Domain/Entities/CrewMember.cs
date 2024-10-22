namespace PO.Domain.Entities
{
    public class CrewMember
    {
        public Guid Id { get; set; }

        // FK

        public Guid CrewId { get; set; }
        public Guid ShipId { get; set; }
        public Crew Crew { get; set; }
        public Ship Ship { get; set; }
    }
}
