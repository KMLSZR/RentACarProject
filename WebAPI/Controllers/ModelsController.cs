using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Queries.GetList;
using Application.Features.Models.Commands;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetList.GetListByDynamic;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        IMediator _mediator;

        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
        {
            CreatedModelResponse response = await _mediator.Send(createModelCommand);
            return Created(uri: "", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery query = new GetListModelQuery
            {
                PageRequest = pageRequest
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost("/getlist/dynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery = null)
        {
            GetListByDynamicModelQuery query = new GetListByDynamicModelQuery
            {
                PageRequest = pageRequest,
                DynamicQuery = dynamicQuery
            };

            var response = await _mediator.Send(query);
            return Ok(response);
        }
    }
}
