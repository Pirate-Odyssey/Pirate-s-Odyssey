namespace PO.Domain.Services.Interfaces
{
    public interface ICrewMemberService
    {
        public Task<IEnumerable<CrewMemberResponse>> GetCrewMembersAsync();
        public Task<CrewMemberResponse> GetCrewMemberAsync(GetCrewMemberByIdRequest request);
        public Task<CrewMemberResponse> AddCrewMemberAsync(AddCrewMemberRequest request);
        public Task<CrewMemberResponse> EditCrewMemberAsync(EditCrewMemberRequest request);
        public Task<CrewMemberResponse> DeleteCrewMemberAsync(DeleteCrewMemberRequest request);
    }
}
