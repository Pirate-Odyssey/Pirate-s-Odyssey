namespace PO.Domain.Requests.CrewMember
{
    public class AddCrewMemberRequest
    {
        public Guid CrewId { get; set; }
        public Guid ShipId { get; set; }
    }
}
