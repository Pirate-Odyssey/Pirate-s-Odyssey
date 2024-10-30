using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PO.Domain.Requests.Ship;
using PO.Domain.Requests.Ship.Validators;
using PO.Domain.Responses.Ship;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipController(
        IShipService shipService,
        IMapper mapper,
        GetShipByIdRequestValidator getShipByIdValidator,
        AddShipRequestValidator addShipRequestValidator,
        EditShipRequestValidator editShipRequestValidator,
        DeleteShipRequestValidator deleteShipRequestValidator) : ControllerBase
    {
        // GET: api/<ShipController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetShips",
            Summary = "Get ships",
            Description = "Get all ships",
            Tags = ["Ship"]
        )]
        [SwaggerResponse(200, "The ships list", typeof(IEnumerable<ShipResponse>))]
        public async Task<ActionResult<IEnumerable<ShipResponse>>> List()
        {
            return Ok(await shipService.GetShipsAsync());
        }

        // GET api/<ShipController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetShip",
            Summary = "Get ship",
            Description = "Get one specific ship",
            Tags = ["Ship"]
        )]
        [SwaggerResponse(200, "The ship", typeof(ShipResponse))]
        [SwaggerResponse(400, "The ship requested is invalid")]
        public async Task<ActionResult<ShipResponse>> Get(Guid id)
        {
            var request = new GetShipByIdRequest { Id = id };
            var result = await getShipByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await shipService.GetShipAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<ShipController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddShip",
            Summary = "Add ship",
            Description = "Add ship",
            Tags = ["Ship"]
        )]
        [SwaggerResponse(201, "The ship was created", typeof(ShipResponse))]
        [SwaggerResponse(400, "The ship data is invalid")]
        public async Task<ActionResult<ShipResponse>> Post([FromBody] AddShipRequest request)
        {
            var result = await addShipRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var ship = await shipService.AddShipAsync(request);
                return CreatedAtAction(nameof(Get), new { id = ship.Id }, ship);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<ShipController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditShip",
            Summary = "Edit ship",
            Description = "Edit one specific ship",
            Tags = ["Ship"]
        )]
        [SwaggerResponse(200, "The ship was updated", typeof(ShipResponse))]
        [SwaggerResponse(400, "The ship requested is invalid")]
        public async Task<ActionResult<ShipResponse>> Put(Guid id, [FromBody] EditShipRequest request)
        {
            request.Id = id;
            var result = await editShipRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await shipService.EditShipAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // PATCH api/<ShipController>/5
        [HttpPatch("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "PatchShip",
            Summary = "Patch ship",
            Description = "Patch one specific ship",
            Tags = ["Ship"]
        )]
        [SwaggerResponse(200, "The ship was updated", typeof(ShipResponse))]
        [SwaggerResponse(400, "The ship requested is invalid")]
        public async Task<ActionResult<ShipResponse>> Patch(Guid id, [FromBody] JsonPatchDocument<EditShipRequest> jsonPatch)
        {
            var getRequest = new GetShipByIdRequest() { Id = id };
            var getResult = await getShipByIdValidator.ValidateAsync(getRequest);
            if (getResult.IsValid)
            {
                var ship = await shipService.GetShipAsync(getRequest);
                var editRequest = new EditShipRequest();
                mapper.Map(ship, editRequest);
                jsonPatch.ApplyTo(editRequest);
                var editResult = await editShipRequestValidator.ValidateAsync(editRequest);
                if (editResult.IsValid)
                    return await shipService.EditShipAsync(editRequest);
                else
                    return BadRequest(editResult.ToDictionary());
            }
            else return BadRequest(getResult.ToDictionary());
        }

        // DELETE api/<ShipController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteShip",
            Summary = "Delete ship",
            Description = "Delete one specific ship",
            Tags = ["Ship"]
        )]
        [SwaggerResponse(200, "The ship was deleted", typeof(ShipResponse))]
        [SwaggerResponse(400, "The ship requested is invalid")]
        public async Task<ActionResult<ShipResponse>> Delete(Guid id)
        {
            var request = new DeleteShipRequest { Id = id };
            var result = await deleteShipRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await shipService.DeleteShipAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
