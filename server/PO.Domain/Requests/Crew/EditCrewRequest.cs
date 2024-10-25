namespace PO.Domain.Requests.Crew
{
    public class EditCrewRequest
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
