using Application.Features.Cities.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cities.Rules;

public class CityBusinessRules:BaseBusinessRules
{
    ICityRepository _cityRepository;

    public CityBusinessRules(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository;
    }

    public async Task CityNameCanNotBeDuplicatedWhenInserted(string name)
    {
        City? brand = await _cityRepository.GetAsync(x => x.Name.ToLower() == name.ToLower());
        if (brand != null)
            throw new BusinessException(CityMessages.CityNameExists);
    }
}
