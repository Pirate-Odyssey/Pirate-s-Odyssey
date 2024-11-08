﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using PO.Domain.Requests.CrewMember;
using PO.Domain.Requests.CrewMember.Validators;
using PO.Domain.Responses.CrewMember;

namespace PO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewMemberController(
        ICrewMemberService crewMemberService,
        IMapper mapper,
        GetCrewMemberByIdRequestValidator getCrewMemberByIdValidator,
        AddCrewMemberRequestValidator addCrewMemberRequestValidator,
        EditCrewMemberRequestValidator editCrewMemberRequestValidator,
        DeleteCrewMemberRequestValidator deleteCrewMemberRequestValidator) : ControllerBase
    {
        // GET: api/<crewMemberController>
        [HttpGet]
        [SwaggerOperation(
            OperationId = "GetCrewMembers",
            Summary = "Get CrewMembers",
            Description = "Get all CrewMembers",
            Tags = ["CrewMember"]
        )]
        [SwaggerResponse(200, "The CrewMembers list", typeof(IEnumerable<CrewMemberResponse>))]
        public async Task<ActionResult<IEnumerable<CrewMemberResponse>>> List()
        {
            return Ok(await crewMemberService.GetCrewMembersAsync());
        }

        // GET api/<crewMemberController>/5
        [HttpGet("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "GetCrewMember",
            Summary = "Get CrewMember",
            Description = "Get one specific CrewMember",
            Tags = ["CrewMember"]
        )]
        [SwaggerResponse(200, "The CrewMember", typeof(CrewMemberResponse))]
        [SwaggerResponse(400, "The CrewMember requested is invalid")]
        public async Task<ActionResult<CrewMemberResponse>> Get(Guid id)
        {
            var request = new GetCrewMemberByIdRequest { Id = id };
            var result = await getCrewMemberByIdValidator.ValidateAsync(request);
            if (result.IsValid)
                return await crewMemberService.GetCrewMemberAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // POST api/<crewMemberController>
        [HttpPost]
        [SwaggerOperation(
            OperationId = "AddCrewMember",
            Summary = "Add CrewMember",
            Description = "Add CrewMember",
            Tags = ["CrewMember"]
        )]
        [SwaggerResponse(201, "The CrewMember was created", typeof(CrewMemberResponse))]
        [SwaggerResponse(400, "The CrewMember data is invalid")]
        public async Task<ActionResult<CrewMemberResponse>> Post([FromBody] AddCrewMemberRequest request)
        {
            var result = await addCrewMemberRequestValidator.ValidateAsync(request);
            if (result.IsValid)
            {
                var crewMember = await crewMemberService.AddCrewMemberAsync(request);
                return CreatedAtAction(nameof(Get), new { id = crewMember.Id }, crewMember);
            }
            else return BadRequest(result.ToDictionary());
        }

        // PUT api/<crewMemberController>/5
        [HttpPut("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "EditCrewMember",
            Summary = "Edit CrewMember",
            Description = "Edit one specific CrewMember",
            Tags = ["CrewMember"]
        )]
        [SwaggerResponse(200, "The CrewMember was updated", typeof(CrewMemberResponse))]
        [SwaggerResponse(400, "The CrewMember requested is invalid")]
        public async Task<ActionResult<CrewMemberResponse>> Put(Guid id, [FromBody] EditCrewMemberRequest request)
        {
            request.Id = id;
            var result = await editCrewMemberRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await crewMemberService.EditCrewMemberAsync(request);
            else return BadRequest(result.ToDictionary());
        }

        // PATCH api/<WeaponController>/5
        [HttpPatch("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "PatchCrewMember",
            Summary = "Patch crewMember",
            Description = "Patch one specific crewMember",
            Tags = ["CrewMember"]
        )]
        [SwaggerResponse(200, "The crewMember was updated", typeof(CrewMemberResponse))]
        [SwaggerResponse(400, "The crewMember requested is invalid")]
        public async Task<ActionResult<CrewMemberResponse>> Patch(Guid id, [FromBody] JsonPatchDocument<EditCrewMemberRequest> jsonPatch)
        {
            var getRequest = new GetCrewMemberByIdRequest() { Id = id };
            var getResult = await getCrewMemberByIdValidator.ValidateAsync(getRequest);
            if (getResult.IsValid)
            {
                var crewMember = await crewMemberService.GetCrewMemberAsync(getRequest);
                var editRequest = new EditCrewMemberRequest();
                mapper.Map(crewMember, editRequest);
                jsonPatch.ApplyTo(editRequest);
                var editResult = await editCrewMemberRequestValidator.ValidateAsync(editRequest);
                if (editResult.IsValid)
                    return await crewMemberService.EditCrewMemberAsync(editRequest);
                else
                    return BadRequest(editResult.ToDictionary());
            }
            else return BadRequest(getResult.ToDictionary());
        }

        // DELETE api/<crewMemberController>/5
        [HttpDelete("{id:Guid}")]
        [SwaggerOperation(
            OperationId = "DeleteCrewMember",
            Summary = "Delete CrewMember",
            Description = "Delete one specific CrewMember",
            Tags = ["CrewMember"]
        )]
        [SwaggerResponse(200, "The CrewMember was deleted", typeof(CrewMemberResponse))]
        [SwaggerResponse(400, "The CrewMember requested is invalid")]
        public async Task<ActionResult<CrewMemberResponse>> Delete(Guid id)
        {
            var request = new DeleteCrewMemberRequest { Id = id };
            var result = await deleteCrewMemberRequestValidator.ValidateAsync(request);
            if (result.IsValid)
                return await crewMemberService.DeleteCrewMemberAsync(request);
            else return BadRequest(result.ToDictionary());
        }
    }
}
