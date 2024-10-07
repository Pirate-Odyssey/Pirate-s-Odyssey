namespace PO.Domain.Specifications.Weapon
{
    public class FindWeaponByIdSpecification : Specification<Entities.Items.Weapon>
    {
        public FindWeaponByIdSpecification(Guid weaponId)
        {
            Criteria = weapon => weapon.Id == weaponId;
        }
    }
}
