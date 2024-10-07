namespace PO.Domain.Services.Implementations
{
    public class WeaponService(IWeaponRepository weaponRepository, IMapper mapper) : IWeaponService
    {
        public async Task<WeaponResponse> AddWeaponAsync(AddWeaponRequest request)
        {
            var weapon = mapper.Map<Weapon>(request);
            weaponRepository.Create(weapon);
            await weaponRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<WeaponResponse>(weapon);
        }

        public async Task<WeaponResponse> DeleteWeaponAsync(DeleteWeaponRequest request)
        {
            var spec = new FindWeaponByIdSpecification(request.Id);
            var weapon = await weaponRepository.FindOneAsync(spec);
            weaponRepository.Delete(weapon);
            await weaponRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<WeaponResponse>(weapon);
        }

        public async Task<WeaponResponse> EditWeaponAsync(EditWeaponRequest request)
        {
            var weapon = mapper.Map<Weapon>(request);
            weaponRepository.Update(weapon);
            await weaponRepository.UnitOfWork.SaveChangesAsync();
            return mapper.Map<WeaponResponse>(weapon);
        }

        public async Task<WeaponResponse> GetWeaponAsync(GetWeaponByIdRequest request)
        {
            var spec = new FindWeaponByIdSpecification(request.Id);
            var weapon = await weaponRepository.FindOneAsync(spec);
            return mapper.Map<WeaponResponse>(weapon);
        }

        public async Task<IEnumerable<WeaponResponse>> GetWeaponsAsync()
        {
            var weapons = await weaponRepository.GetAllAsync();
            return weapons.Select(x => mapper.Map<WeaponResponse>(x));
        }
    }
}
