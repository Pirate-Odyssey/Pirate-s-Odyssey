namespace PO.Domain.Services.Implementations
{
    public class CrewService(ICrewRepository crewRepository, IMapper mapper) : ICrewService
    {
        public async Task<CrewResponse> AddCrewAsync(AddCrewRequest request)
        {
            var crew = mapper.Map<Crew>(request);
            crewRepository.Create(crew);
            await crewRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<CrewResponse>(crew);
        }

        public async Task<CrewResponse> DeleteCrewAsync(DeleteCrewRequest request)
        {
            var spec = new FindCrewByIdSpecification(request.Id);
            var crew = await crewRepository.FindOneAsync(spec);
            crewRepository.Delete(crew);
            await crewRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<CrewResponse>(crew);
        }

        public async Task<CrewResponse> EditCrewAsync(EditCrewRequest request)
        {
            var crew = mapper.Map<Crew>(request);
            crewRepository.Update(crew);
            await crewRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<CrewResponse>(crew);
        }

        public async Task<CrewResponse> GetCrewAsync(GetCrewByIdRequest request)
        {
            var spec = new FindCrewByIdSpecification(request.Id);
            var crew = await crewRepository.FindOneAsync(spec);
            return mapper.Map<CrewResponse>(crew);
        }

        public async Task<IEnumerable<CrewResponse>> GetCrewsAsync()
        {
            var spec = new FindCrewSpecification();
            var crews = await crewRepository.FindAsync(spec);
            return crews.Select(mapper.Map<CrewResponse>);
        }
    }
}
