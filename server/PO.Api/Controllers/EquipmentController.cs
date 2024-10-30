using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PO.Domain.Requests.Equipment;
using PO.Domain.Requests.Equipment.Validators;
using PO.Domain.Responses.Equipment;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController(
        IEquipmentService equipmentService,
        IMapper mapper,
        GetEquipmentByIdRequestValidator getEquipmentByIdValidator,
        AddEquipmentRequestValidator addEquipmentRequestValidator,
        EditEquipmentRequestValidator editEquipmentRequestValidator,
        DeleteEquipmentRequestValidator deleteEquipmentRequestValidator) : ControllerBase
    {
        // GET: api/<EquipmentController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetEquipments",
            Summary = "Get equipments",
            Description = "Get all equipments",
            Tags = ["Equipment"]
        )]
        [SwaggerResponse(200, "The equipments list", typeof(IEnumerable<EquipmentResponse>))]
        public async Task<ActionResult<IEnumerable<EquipmentResponse>>> List()
        {
            return Ok(await equipmentService.GetEquipmentsAsync());
        }

        // GET api/<EquipmentController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetEquipment",
            Summary = "Get equipment",
            Description = "Get one specific equipment",
            Tags = ["Equipment"]
        )]
        [SwaggerResponse(200, "The equipment", typeof(EquipmentResponse))]
        [SwaggerResponse(400, "The equipment requested is invalid")]
        public async Task<ActionResult<EquipmentResponse>> Get(Guid id)
        {
            var request = new GetEquipmentByIdRequest { Id = id };
            var result = await getEquipmentByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await equipmentService.GetEquipmentAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<EquipmentController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddEquipment",
            Summary = "Add equipment",
            Description = "Add equipment",
            Tags = ["Equipment"]
        )]
        [SwaggerResponse(201, "The equipment was created", typeof(EquipmentResponse))]
        [SwaggerResponse(400, "The equipment data is invalid")]
        public async Task<ActionResult<EquipmentResponse>> Post([FromBody] AddEquipmentRequest request)
        {
            var result = await addEquipmentRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var equipment = await equipmentService.AddEquipmentAsync(request);
                return CreatedAtAction(nameof(Get), new { id = equipment.Id }, equipment);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<EquipmentController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditEquipment",
            Summary = "Edit equipment",
            Description = "Edit one specific equipment",
            Tags = ["Equipment"]
        )]
        [SwaggerResponse(200, "The equipment was updated", typeof(EquipmentResponse))]
        [SwaggerResponse(400, "The equipment requested is invalid")]
        public async Task<ActionResult<EquipmentResponse>> Put(Guid id, [FromBody] EditEquipmentRequest request)
        {
            request.Id = id;
            var result = await editEquipmentRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await equipmentService.EditEquipmentAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // PATCH api/<EquipmentController>/5
        [HttpPatch("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "PatchEquipment",
            Summary = "Patch equipment",
            Description = "Patch one specific equipment",
            Tags = ["Equipment"]
        )]
        [SwaggerResponse(200, "The equipment was updated", typeof(EquipmentResponse))]
        [SwaggerResponse(400, "The equipment requested is invalid")]
        public async Task<ActionResult<EquipmentResponse>> Patch(Guid id, [FromBody] JsonPatchDocument<EditEquipmentRequest> jsonPatch)
        {
            var getRequest = new GetEquipmentByIdRequest() { Id = id };
            var getResult = await getEquipmentByIdValidator.ValidateAsync(getRequest);
            if (getResult.IsValid)
            {
                var equipment = await equipmentService.GetEquipmentAsync(getRequest);
                var editRequest = new EditEquipmentRequest();
                mapper.Map(equipment, editRequest);
                jsonPatch.ApplyTo(editRequest);
                var editResult = await editEquipmentRequestValidator.ValidateAsync(editRequest);
                if (editResult.IsValid)
                    return await equipmentService.EditEquipmentAsync(editRequest);
                else
                    return BadRequest(editResult.ToDictionary());
            }
            else return BadRequest(getResult.ToDictionary());
        }

        // DELETE api/<EquipmentController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteEquipment",
            Summary = "Delete equipment",
            Description = "Delete one specific equipment",
            Tags = ["Equipment"]
        )]
        [SwaggerResponse(200, "The equipment was deleted", typeof(EquipmentResponse))]
        [SwaggerResponse(400, "The equipment requested is invalid")]
        public async Task<ActionResult<EquipmentResponse>> Delete(Guid id)
        {
            var request = new DeleteEquipmentRequest { Id = id };
            var result = await deleteEquipmentRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await equipmentService.DeleteEquipmentAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
