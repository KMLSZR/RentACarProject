using Application.Features.Cars.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;
using static Application.Features.Cars.Constants.CarsOperationClaims;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarQuery : IRequest<GetListResponse<GetListCarListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCars({PageRequest.Page},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCars";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, GetListResponse<GetListCarListItemDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarListItemDto>> Handle(GetListCarQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _carRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);

            GetListResponse<GetListCarListItemDto> response = _mapper.Map<GetListResponse<GetListCarListItemDto>>(cars);
            return response;
        }
    }
}