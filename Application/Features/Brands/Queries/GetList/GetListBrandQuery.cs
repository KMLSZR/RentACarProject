using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Queries.GetList;

public class GetListBrandQuery : IRequest<GetListResponse<GetListBrandListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }

    public string CacheKey => $"GetListBrands({PageRequest.Page},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetBrands";

    public TimeSpan? SlidingExpiration { get; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListBrandQuery, GetListResponse<GetListBrandListItemDto>>
    {
        IBrandRepository _brandrepository;
        IMapper _mapper;

        public GetListBrandQueryHandler(IBrandRepository brandrepository, IMapper mapper)
        {
            _brandrepository = brandrepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBrandListItemDto>> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Brand> brands = await _brandrepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            var mappedBrands = _mapper.Map<GetListResponse<GetListBrandListItemDto>>(brands);
            return mappedBrands;
        }
    }
}
