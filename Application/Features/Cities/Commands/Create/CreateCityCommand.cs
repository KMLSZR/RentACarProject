
using Application.Features.Cities.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Commands.Create;

public class CreateCityCommand:IRequest<CreatedCityResponse>
{
    public string Name { get; set; }
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, CreatedCityResponse>
    {
        ICityRepository _CityRepository;
        IMapper _mapper;
        CityBusinessRules _cityBusinessRules;

        public CreateCityCommandHandler(ICityRepository cityRepository, IMapper mapper, CityBusinessRules cityBusinessRules)
        {
            _CityRepository = cityRepository;
            _mapper = mapper;
            _cityBusinessRules = cityBusinessRules;
        }

        public async Task<CreatedCityResponse> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            await _cityBusinessRules.CityNameCanNotBeDuplicatedWhenInserted(request.Name);
            City mappedCity = _mapper.Map<City>(request);
            City createdCity = await _CityRepository.AddAsync(mappedCity);
            CreatedCityResponse response = _mapper.Map<CreatedCityResponse>(createdCity);
            return response;
           
        }
    }
}
