using PO.Domain.Requests.Weapon;
using PO.Domain.Requests.Weapon.Validators;
using PO.Domain.Responses.Weapon;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController(
        IWeaponService weaponService,
        GetWeaponByIdRequestValidator getWeaponByIdValidator,
        AddWeaponRequestValidator addWeaponRequestValidator,
        EditWeaponRequestValidator editWeaponRequestValidator,
        DeleteWeaponRequestValidator deleteWeaponRequestValidator) : ControllerBase
    {
        // GET: api/<WeaponController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetWeapons",
            Summary = "Get weapons",
            Description = "Get all weapons",
            Tags = ["Weapon"]
        )]
        [SwaggerResponse(200, "The weapons list", typeof(IEnumerable<WeaponResponse>))]
        public async Task<ActionResult<IEnumerable<WeaponResponse>>> List()
        {
            return Ok(await weaponService.GetWeaponsAsync());
        }

        // GET api/<WeaponController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetWeapon",
            Summary = "Get weapon",
            Description = "Get one specific weapon",
            Tags = ["Weapon"]
        )]
        [SwaggerResponse(200, "The weapon", typeof(WeaponResponse))]
        [SwaggerResponse(400, "The weapon requested is invalid")]
        public async Task<ActionResult<WeaponResponse>> Get(Guid id)
        {
            var request = new GetWeaponByIdRequest { Id = id };
            var result = await getWeaponByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await weaponService.GetWeaponAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<WeaponController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddWeapon",
            Summary = "Add weapon",
            Description = "Add weapon",
            Tags = ["Weapon"]
        )]
        [SwaggerResponse(201, "The weapon was created", typeof(WeaponResponse))]
        [SwaggerResponse(400, "The weapon data is invalid")]
        public async Task<ActionResult<WeaponResponse>> Post([FromBody] AddWeaponRequest request)
        {
            var result = await addWeaponRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var weapon = await weaponService.AddWeaponAsync(request);
                return CreatedAtAction(nameof(Get), new { id = weapon.Id }, weapon);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<WeaponController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditWeapon",
            Summary = "Edit weapon",
            Description = "Edit one specific weapon",
            Tags = ["Weapon"]
        )]
        [SwaggerResponse(200, "The weapon was updated", typeof(WeaponResponse))]
        [SwaggerResponse(400, "The weapon requested is invalid")]
        public async Task<ActionResult<WeaponResponse>> Put(Guid id, [FromBody] EditWeaponRequest request)
        {
            request.Id = id;
            var result = await editWeaponRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await weaponService.EditWeaponAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // DELETE api/<WeaponController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteWeapon",
            Summary = "Delete weapon",
            Description = "Delete one specific weapon",
            Tags = ["Weapon"]
        )]
        [SwaggerResponse(200, "The weapon was deleted", typeof(WeaponResponse))]
        [SwaggerResponse(400, "The weapon requested is invalid")]
        public async Task<ActionResult<WeaponResponse>> Delete(Guid id)
        {
            var request = new DeleteWeaponRequest { Id = id };
            var result = await deleteWeaponRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await weaponService.DeleteWeaponAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
