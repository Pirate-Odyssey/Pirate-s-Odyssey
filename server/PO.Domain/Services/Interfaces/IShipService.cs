namespace PO.Domain.Services.Interfaces
{
    public interface IShipService
    {
        public Task<IEnumerable<ShipResponse>> GetShipsAsync();
        public Task<ShipResponse> GetShipAsync(GetShipByIdRequest request);
        public Task<ShipResponse> AddShipAsync(AddShipRequest request);
        public Task<ShipResponse> EditShipAsync(EditShipRequest request);
        public Task<ShipResponse> DeleteShipAsync(DeleteShipRequest request);
    }
}
