namespace PO.Domain.Services.Implementations
{
    public class CrewMemberService(ICrewMemberRepository crewMemberRepository, IMapper mapper) : ICrewMemberService
    {
        public async Task<CrewMemberResponse> AddCrewMemberAsync(AddCrewMemberRequest request)
        {
            var crewmember = mapper.Map<CrewMember>(request);
            crewMemberRepository.Create(crewmember);
            await crewMemberRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<CrewMemberResponse>(crewmember);
        }

        public async Task<CrewMemberResponse> DeleteCrewMemberAsync(DeleteCrewMemberRequest request)
        {
            var spec = new FindCrewMemberByIdSpecification(request.Id);
            var crewmember = await crewMemberRepository.FindOneAsync(spec);
            crewMemberRepository.Delete(crewmember);
            await crewMemberRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<CrewMemberResponse>(crewmember);
        }

        public async Task<CrewMemberResponse> EditCrewMemberAsync(EditCrewMemberRequest request)
        {
            var crewmember = mapper.Map<CrewMember>(request);
            crewMemberRepository.Update(crewmember);
            await crewMemberRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<CrewMemberResponse>(crewmember);
        }

        public async Task<CrewMemberResponse> GetCrewMemberAsync(GetCrewMemberByIdRequest request)
        {
            var spec = new FindCrewMemberByIdSpecification(request.Id);
            var crewmember = await crewMemberRepository.FindOneAsync(spec);
            return mapper.Map<CrewMemberResponse>(crewmember);
        }

        public async Task<IEnumerable<CrewMemberResponse>> GetCrewMembersAsync()
        {
            var spec = new FindCrewMemberSpecification();
            var crewmembers = await crewMemberRepository.FindAsync(spec);
            return crewmembers.Select(mapper.Map<CrewMemberResponse>);
        }
    }
}
