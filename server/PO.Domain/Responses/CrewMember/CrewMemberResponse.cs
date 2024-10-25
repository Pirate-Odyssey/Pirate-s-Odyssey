namespace PO.Domain.Responses.CrewMember
{
    public class CrewMemberResponse
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        // FK

        public Guid? CrewId { get; set; }
        public Guid? ShipId { get; set; }
        public CrewResponse Crew { get; set; }
        public ShipResponse Ship { get; set; }
    }
}
