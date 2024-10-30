using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PO.Domain.Requests.Crew;
using PO.Domain.Requests.Crew.Validators;
using PO.Domain.Responses.Crew;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController(
        ICrewService crewService,
        IMapper mapper,
        GetCrewByIdRequestValidator getCrewByIdValidator,
        AddCrewRequestValidator addCrewRequestValidator,
        EditCrewRequestValidator editCrewRequestValidator,
        DeleteCrewRequestValidator deleteCrewRequestValidator) : ControllerBase
    {
        // GET: api/<CrewController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetCrews",
            Summary = "Get Crews",
            Description = "Get all Crews",
            Tags = ["Crew"]
        )]
        [SwaggerResponse(200, "The Crews list", typeof(IEnumerable<CrewResponse>))]
        public async Task<ActionResult<IEnumerable<CrewResponse>>> List()
        {
            return Ok(await crewService.GetCrewsAsync());
        }

        // GET api/<CrewController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetCrew",
            Summary = "Get Crew",
            Description = "Get one specific Crew",
            Tags = ["Crew"]
        )]
        [SwaggerResponse(200, "The Crew", typeof(CrewResponse))]
        [SwaggerResponse(400, "The Crew requested is invalid")]
        public async Task<ActionResult<CrewResponse>> Get(Guid id)
        {
            var request = new GetCrewByIdRequest { Id = id };
            var result = await getCrewByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await crewService.GetCrewAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<CrewController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddCrew",
            Summary = "Add Crew",
            Description = "Add Crew",
            Tags = ["Crew"]
        )]
        [SwaggerResponse(201, "The Crew was created", typeof(CrewResponse))]
        [SwaggerResponse(400, "The Crew data is invalid")]
        public async Task<ActionResult<CrewResponse>> Post([FromBody] AddCrewRequest request)
        {
            var result = await addCrewRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var Crew = await crewService.AddCrewAsync(request);
                return CreatedAtAction(nameof(Get), new { id = Crew.Id }, Crew);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<CrewController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditCrew",
            Summary = "Edit Crew",
            Description = "Edit one specific Crew",
            Tags = ["Crew"]
        )]
        [SwaggerResponse(200, "The Crew was updated", typeof(CrewResponse))]
        [SwaggerResponse(400, "The Crew requested is invalid")]
        public async Task<ActionResult<CrewResponse>> Put(Guid id, [FromBody] EditCrewRequest request)
        {
            request.Id = id;
            var result = await editCrewRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await crewService.EditCrewAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // PATCH api/<CrewController>/5
        [HttpPatch("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "PatchCrew",
            Summary = "Patch crew",
            Description = "Patch one specific crew",
            Tags = ["Crew"]
        )]
        [SwaggerResponse(200, "The crew was updated", typeof(CrewResponse))]
        [SwaggerResponse(400, "The crew requested is invalid")]
        public async Task<ActionResult<CrewResponse>> Patch(Guid id, [FromBody] JsonPatchDocument<EditCrewRequest> jsonPatch)
        {
            var getRequest = new GetCrewByIdRequest() { Id = id };
            var getResult = await getCrewByIdValidator.ValidateAsync(getRequest);
            if (getResult.IsValid)
            {
                var crew = await crewService.GetCrewAsync(getRequest);
                var editRequest = new EditCrewRequest();
                mapper.Map(crew, editRequest);
                jsonPatch.ApplyTo(editRequest);
                var editResult = await editCrewRequestValidator.ValidateAsync(editRequest);
                if (editResult.IsValid)
                    return await crewService.EditCrewAsync(editRequest);
                else
                    return BadRequest(editResult.ToDictionary());
            }
            else return BadRequest(getResult.ToDictionary());
        }

        // DELETE api/<CrewController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteCrew",
            Summary = "Delete Crew",
            Description = "Delete one specific Crew",
            Tags = ["Crew"]
        )]
        [SwaggerResponse(200, "The Crew was deleted", typeof(CrewResponse))]
        [SwaggerResponse(400, "The Crew requested is invalid")]
        public async Task<ActionResult<CrewResponse>> Delete(Guid id)
        {
            var request = new DeleteCrewRequest { Id = id };
            var result = await deleteCrewRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await crewService.DeleteCrewAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
