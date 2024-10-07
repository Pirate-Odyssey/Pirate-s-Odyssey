using PO.Domain.Responses.Weapon;

namespace PO.Domain.Services.Interfaces
{
    public interface IWeaponService
    {
        public Task<IEnumerable<WeaponResponse>> GetWeaponsAsync();
        public Task<WeaponResponse> GetWeaponAsync(GetWeaponByIdRequest request);
        public Task<WeaponResponse> AddWeaponAsync(AddWeaponRequest request);
        public Task<WeaponResponse> EditWeaponAsync(EditWeaponRequest request);
        public Task<WeaponResponse> DeleteWeaponAsync(DeleteWeaponRequest request);
    }
}
