namespace PO.Domain.Requests.Crew
{
    public class DeleteCrewRequest
    {
        [Required]
        public Guid Id { get; set; }
    }
}
