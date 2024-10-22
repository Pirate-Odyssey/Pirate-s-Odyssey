namespace PO.Domain.Services.Interfaces
{
    public interface ICrewService
    {
        public Task<IEnumerable<CrewResponse>> GetCrewsAsync();
        public Task<CrewResponse> GetCrewAsync(GetCrewByIdRequest request);
        public Task<CrewResponse> AddCrewAsync(AddCrewRequest request);
        public Task<CrewResponse> EditCrewAsync(EditCrewRequest request);
        public Task<CrewResponse> DeleteCrewAsync(DeleteCrewRequest request);
    }
}
