
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Queries.GetById;

public class GetByIdCityQuery : IRequest<GetByIdCityResponse>
{

    public int Id { get; set; }

    public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQuery, GetByIdCityResponse>
    {
        ICityRepository _cityRepository;
        IMapper _mapper;

        public GetByIdCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCityResponse> Handle(GetByIdCityQuery request, CancellationToken cancellationToken)
        {
            City? City = await _cityRepository.GetAsync(x => x.Id == request.Id);

            GetByIdCityResponse _response = _mapper.Map<GetByIdCityResponse>(City);
            return _response;
        }
    }

}
