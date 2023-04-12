using Application.Features.Maintances.Commands.Create;
using Application.Features.Maintances.Commands.Delete;
using Application.Features.Maintances.Commands.Update;
using Application.Features.Maintances.Queries.GetById;
using Application.Features.Maintances.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MaintancesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMaintanceCommand createMaintanceCommand)
    {
        CreatedMaintanceResponse response = await Mediator.Send(createMaintanceCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMaintanceCommand updateMaintanceCommand)
    {
        UpdatedMaintanceResponse response = await Mediator.Send(updateMaintanceCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        DeletedMaintanceResponse response = await Mediator.Send(new DeleteMaintanceCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        GetByIdMaintanceResponse response = await Mediator.Send(new GetByIdMaintanceQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMaintanceQuery getListMaintanceQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMaintanceListItemDto> response = await Mediator.Send(getListMaintanceQuery);
        return Ok(response);
    }
}