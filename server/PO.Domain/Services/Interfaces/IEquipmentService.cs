using PO.Domain.Requests.Equipment;
using PO.Domain.Responses.Equipment;

namespace PO.Domain.Services.Interfaces
{
    public interface IEquipmentService
    {
        public Task<IEnumerable<EquipmentResponse>> GetEquipmentsAsync();
        public Task<EquipmentResponse> GetEquipmentAsync(GetEquipmentByIdRequest request);
        public Task<EquipmentResponse> AddEquipmentAsync(AddEquipmentRequest request);
        public Task<EquipmentResponse> EditEquipmentAsync(EditEquipmentRequest request);
        public Task<EquipmentResponse> DeleteEquipmentAsync(DeleteEquipmentRequest request);
    }
}
