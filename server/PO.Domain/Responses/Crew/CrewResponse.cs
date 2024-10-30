namespace PO.Domain.Responses.Crew
{
    public class CrewResponse
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        // FK

        [Required]
        public ICollection<CrewMemberResponse> CrewMembers { get; set; }
    }
}
