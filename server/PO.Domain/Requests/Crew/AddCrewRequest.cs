namespace PO.Domain.Requests.Crew
{
    public class AddCrewRequest
    {
        [Required]
        public string Name { get; set; }
    }
}
