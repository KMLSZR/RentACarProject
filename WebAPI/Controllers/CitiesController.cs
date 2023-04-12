
using Application.Features.Cities.Commands.Create;
using Application.Features.Cities.Queries.GetById;
using Application.Features.Cities.Queries.GetList;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
       IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateCityCommand createCityCommand)
        {
            CreatedCityResponse response=await _mediator.Send(createCityCommand);
            return Created(uri:"",response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCityQuery query = new GetListCityQuery
            {
                PageRequest = pageRequest
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCityQuery getByIdCityQuery)
        {
            GetByIdCityResponse response = await _mediator.Send(getByIdCityQuery);
            return Ok(response);
        }
    }
}
