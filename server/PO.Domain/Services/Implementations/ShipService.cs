namespace PO.Domain.Services.Implementations
{
    public class ShipService(IShipRepository shipRepository, IMapper mapper) : IShipService
    {
        public async Task<ShipResponse> AddShipAsync(AddShipRequest request)
        {
            var ship = mapper.Map<Ship>(request);
            shipRepository.Create(ship);
            await shipRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ShipResponse>(ship);
        }

        public async Task<ShipResponse> DeleteShipAsync(DeleteShipRequest request)
        {
            var spec = new FindShipByIdSpecification(request.Id);
            var ship = await shipRepository.FindOneAsync(spec);
            shipRepository.Delete(ship);
            await shipRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ShipResponse>(ship);
        }

        public async Task<ShipResponse> EditShipAsync(EditShipRequest request)
        {
            var ship = mapper.Map<Ship>(request);
            shipRepository.Update(ship);
            await shipRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<ShipResponse>(ship);
        }

        public async Task<ShipResponse> GetShipAsync(GetShipByIdRequest request)
        {
            var spec = new FindShipByIdSpecification(request.Id);
            var ship = await shipRepository.FindOneAsync(spec);
            return mapper.Map<ShipResponse>(ship);
        }

        public async Task<IEnumerable<ShipResponse>> GetShipsAsync()
        {
            var ships = await shipRepository.GetAllAsync();
            return ships.Select(x => mapper.Map<ShipResponse>(x));
        }
    }
}
