namespace PO.Domain.Requests.CrewMember
{
    public class EditCrewMemberRequest
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        // FK

        public Guid CrewId { get; set; }
        public Guid ShipId { get; set; }
    }
}
