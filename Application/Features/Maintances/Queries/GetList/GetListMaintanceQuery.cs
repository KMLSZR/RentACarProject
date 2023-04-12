using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Maintances.Queries.GetList;

public class GetListMaintanceQuery : IRequest<GetListResponse<GetListMaintanceListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListMaintances({PageRequest.Page},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetMaintances";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListMaintanceQueryHandler : IRequestHandler<GetListMaintanceQuery, GetListResponse<GetListMaintanceListItemDto>>
    {
        private readonly IMaintanceRepository _maintanceRepository;
        private readonly IMapper _mapper;

        public GetListMaintanceQueryHandler(IMaintanceRepository maintanceRepository, IMapper mapper)
        {
            _maintanceRepository = maintanceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListMaintanceListItemDto>> Handle(GetListMaintanceQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<Maintance> maintances = await _maintanceRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);

            GetListResponse<GetListMaintanceListItemDto> response = _mapper.Map<GetListResponse<GetListMaintanceListItemDto>>(maintances);
            return response;
        }
    }
}