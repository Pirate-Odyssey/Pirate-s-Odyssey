using PO.Domain.Requests.Item;
using PO.Domain.Requests.Item.Validators;
using PO.Domain.Responses.Item;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(
        IItemService itemService,
        GetItemByIdRequestValidator getItemByIdValidator,
        AddItemRequestValidator addItemRequestValidator,
        EditItemRequestValidator editItemRequestValidator,
        DeleteItemRequestValidator deleteItemRequestValidator) : ControllerBase
    {
        // GET: api/<ItemController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetItems",
            Summary = "Get items",
            Description = "Get all items",
            Tags = ["Item"]
        )]
        [SwaggerResponse(200, "The items list", typeof(IEnumerable<ItemResponse>))]
        public async Task<ActionResult<IEnumerable<ItemResponse>>> List()
        {
            return Ok(await itemService.GetItemsAsync());
        }

        // GET api/<ItemController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetItem",
            Summary = "Get item",
            Description = "Get one specific item",
            Tags = ["Item"]
        )]
        [SwaggerResponse(200, "The item", typeof(ItemResponse))]
        [SwaggerResponse(400, "The item requested is invalid")]
        public async Task<ActionResult<ItemResponse>> Get(Guid id)
        {
            var request = new GetItemByIdRequest { Id = id };
            var result = await getItemByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await itemService.GetItemAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<ItemController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddItem",
            Summary = "Add item",
            Description = "Add item",
            Tags = ["Item"]
        )]
        [SwaggerResponse(201, "The item was created", typeof(ItemResponse))]
        [SwaggerResponse(400, "The item data is invalid")]
        public async Task<ActionResult<ItemResponse>> Post([FromBody] AddItemRequest request)
        {
            var result = await addItemRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var item = await itemService.AddItemAsync(request);
                return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditItem",
            Summary = "Edit item",
            Description = "Edit one specific item",
            Tags = ["Item"]
        )]
        [SwaggerResponse(200, "The item was updated", typeof(ItemResponse))]
        [SwaggerResponse(400, "The item requested is invalid")]
        public async Task<ActionResult<ItemResponse>> Put(Guid id, [FromBody] EditItemRequest request)
        {
            request.Id = id;
            var result = await editItemRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await itemService.EditItemAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteItem",
            Summary = "Delete item",
            Description = "Delete one specific item",
            Tags = ["Item"]
        )]
        [SwaggerResponse(200, "The item was deleted", typeof(ItemResponse))]
        [SwaggerResponse(400, "The item requested is invalid")]
        public async Task<ActionResult<ItemResponse>> Delete(Guid id)
        {
            var request = new DeleteItemRequest { Id = id };
            var result = await deleteItemRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await itemService.DeleteItemAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
