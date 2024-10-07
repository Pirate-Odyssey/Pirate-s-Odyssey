using PO.Domain.Requests.Equipment;
using PO.Domain.Responses.Equipment;

namespace PO.Domain.Services.Implementations
{
    public class EquipmentService(IEquipmentRepository equipmentRepository, IMapper mapper) : IEquipmentService
    {
        public async Task<EquipmentResponse> AddEquipmentAsync(AddEquipmentRequest request)
        {
            var equipment = mapper.Map<Equipment>(request);
            equipmentRepository.Create(equipment);
            await equipmentRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<EquipmentResponse>(equipment);
        }

        public async Task<EquipmentResponse> DeleteEquipmentAsync(DeleteEquipmentRequest request)
        {
            var spec = new FindEquipmentByIdSpecification(request.Id);
            var equipment = await equipmentRepository.FindOneAsync(spec);
            equipmentRepository.Delete(equipment);
            await equipmentRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<EquipmentResponse>(equipment);
        }

        public async Task<EquipmentResponse> EditEquipmentAsync(EditEquipmentRequest request)
        {
            var equipment = mapper.Map<Equipment>(request);
            equipmentRepository.Update(equipment);
            await equipmentRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<EquipmentResponse>(equipment);
        }

        public async Task<EquipmentResponse> GetEquipmentAsync(GetEquipmentByIdRequest request)
        {
            var spec = new FindEquipmentByIdSpecification(request.Id);
            var equipment = await equipmentRepository.FindOneAsync(spec);
            return mapper.Map<EquipmentResponse>(equipment);
        }

        public async Task<IEnumerable<EquipmentResponse>> GetEquipmentsAsync()
        {
            var equipments = await equipmentRepository.GetAllAsync();
            return equipments.Select(x => mapper.Map<EquipmentResponse>(x));
        }
    }
}
