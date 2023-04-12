using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Brands.Queries.GetList;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    IMediator _mediator;

    public BrandsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand)
    {
       CreatedBrandResponse response=  await _mediator.Send(createBrandCommand);
        return Created(uri:"",response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandQuery query = new GetListBrandQuery
        {
            PageRequest = pageRequest
        };

        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery)
    {
        GetByIdBrandResponse response = await _mediator.Send(getByIdBrandQuery);
        return Ok(response);
    }
}
