namespace PO.Domain.Responses.Crew
{
    public class CrewResponse
    {
        public Guid Id { get; set; }

        // FK

        public ICollection<CrewMemberResponse> CrewMembers { get; set; }
    }
}
