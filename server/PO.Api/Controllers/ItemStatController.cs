using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PO.Domain.Requests.ItemStat;
using PO.Domain.Requests.ItemStat.Validators;
using PO.Domain.Responses.ItemStat;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemStatController(
        IItemStatService itemStatService,
        IMapper mapper,
        GetItemStatByIdRequestValidator getItemStatByIdValidator,
        AddItemStatRequestValidator addItemStatRequestValidator,
        EditItemStatRequestValidator editItemStatRequestValidator,
        DeleteItemStatRequestValidator deleteItemStatRequestValidator) : ControllerBase
    {
        // GET: api/<ItemStatController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetItemStats",
            Summary = "Get itemStats",
            Description = "Get all itemStats",
            Tags = ["ItemStat"]
        )]
        [SwaggerResponse(200, "The itemStats list", typeof(IEnumerable<ItemStatResponse>))]
        public async Task<ActionResult<IEnumerable<ItemStatResponse>>> List()
        {
            return Ok(await itemStatService.GetItemStatsAsync());
        }

        // GET api/<ItemStatController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetItemStat",
            Summary = "Get ItemStat",
            Description = "Get one specific ItemStat",
            Tags = ["ItemStat"]
        )]
        [SwaggerResponse(200, "The ItemStat", typeof(ItemStatResponse))]
        [SwaggerResponse(400, "The ItemStat requested is invalid")]
        public async Task<ActionResult<ItemStatResponse>> Get(Guid id)
        {
            var request = new GetItemStatByIdRequest { Id = id };
            var result = await getItemStatByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await itemStatService.GetItemStatAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<ItemStatController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddItemStat",
            Summary = "Add ItemStat",
            Description = "Add ItemStat",
            Tags = ["ItemStat"]
        )]
        [SwaggerResponse(201, "The ItemStat was created", typeof(ItemStatResponse))]
        [SwaggerResponse(400, "The ItemStat data is invalid")]
        public async Task<ActionResult<ItemStatResponse>> Post([FromBody] AddItemStatRequest request)
        {
            var result = await addItemStatRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var ItemStat = await itemStatService.AddItemStatAsync(request);
                return CreatedAtAction(nameof(Get), new { id = ItemStat.Id }, ItemStat);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<ItemStatController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditItemStat",
            Summary = "Edit ItemStat",
            Description = "Edit one specific ItemStat",
            Tags = ["ItemStat"]
        )]
        [SwaggerResponse(200, "The ItemStat was updated", typeof(ItemStatResponse))]
        [SwaggerResponse(400, "The ItemStat requested is invalid")]
        public async Task<ActionResult<ItemStatResponse>> Put(Guid id, [FromBody] EditItemStatRequest request)
        {
            request.Id = id;
            var result = await editItemStatRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await itemStatService.EditItemStatAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // PATCH api/<ItemStatController>/5
        [HttpPatch("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "PatchItemStat",
            Summary = "Patch ItemStat",
            Description = "Patch one specific ItemStat",
            Tags = ["ItemStat"]
        )]
        [SwaggerResponse(200, "The ItemStat was updated", typeof(ItemStatResponse))]
        [SwaggerResponse(400, "The ItemStat requested is invalid")]
        public async Task<ActionResult<ItemStatResponse>> Patch(Guid id, [FromBody] JsonPatchDocument<EditItemStatRequest> jsonPatch)
        {
            var getRequest = new GetItemStatByIdRequest() { Id = id };
            var getResult = await getItemStatByIdValidator.ValidateAsync(getRequest);
            if (getResult.IsValid)
            {
                var ItemStat = await itemStatService.GetItemStatAsync(getRequest);
                var editRequest = new EditItemStatRequest();
                mapper.Map(ItemStat, editRequest);
                jsonPatch.ApplyTo(editRequest);
                var editResult = await editItemStatRequestValidator.ValidateAsync(editRequest);
                if (editResult.IsValid)
                    return await itemStatService.EditItemStatAsync(editRequest);
                else
                    return BadRequest(editResult.ToDictionary());
            }
            else return BadRequest(getResult.ToDictionary());
        }

        // DELETE api/<ItemStatController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteItemStat",
            Summary = "Delete ItemStat",
            Description = "Delete one specific ItemStat",
            Tags = ["ItemStat"]
        )]
        [SwaggerResponse(200, "The ItemStat was deleted", typeof(ItemStatResponse))]
        [SwaggerResponse(400, "The ItemStat requested is invalid")]
        public async Task<ActionResult<ItemStatResponse>> Delete(Guid id)
        {
            var request = new DeleteItemStatRequest { Id = id };
            var result = await deleteItemStatRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await itemStatService.DeleteItemStatAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
