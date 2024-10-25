namespace PO.Domain.Requests.CrewMember
{
    public class AddCrewMemberRequest
    {
        [Required]
        public string Name { get; set; }

        // FK

        public Guid CrewId { get; set; }
        public Guid ShipId { get; set; }
    }
}
