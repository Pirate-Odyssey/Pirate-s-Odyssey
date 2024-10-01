using PO.Domain.Requests.Item;
using PO.Domain.Responses.Item;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController(IItemService itemService) : ControllerBase
    {
        // GET: api/<ItemController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ItemController>/5
        [HttpGet("{id:Guid}")]
        public async Task<ItemResponse> Get(Guid id)
        {
            var request = new GetItemByIdRequest { Id = id };
            return await itemService.GetItemAsync(request);
        }

        // POST api/<ItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
