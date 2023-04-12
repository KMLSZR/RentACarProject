using Application.Features.Brands.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
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

namespace Application.Features.Cities.Queries.GetList;

public class GetListCityQuery : IRequest<GetListResponse<GetListCityListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBrandQueryHandler : IRequestHandler<GetListCityQuery, GetListResponse<GetListCityListItemDto>>
    {
        ICityRepository _cityRepository;
        IMapper _mapper;

        public GetListBrandQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCityListItemDto>> Handle(GetListCityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<City> cities = await _cityRepository.GetListAsync(
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            var mappedCities = _mapper.Map<GetListResponse<GetListCityListItemDto>>(cities);
            return mappedCities;    
        }
    }
}
