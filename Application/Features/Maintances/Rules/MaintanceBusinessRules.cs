using Application.Features.Maintances.Constants;
using Application.Services.CarService;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;

namespace Application.Features.Maintances.Rules;

public class MaintanceBusinessRules : BaseBusinessRules
{
    private readonly IMaintanceRepository _maintanceRepository;
    private readonly ICarService _carService;

    public MaintanceBusinessRules(IMaintanceRepository maintanceRepository, ICarService carService)
    {
        _maintanceRepository = maintanceRepository;
        _carService = carService;
    }

    public MaintanceBusinessRules(IMaintanceRepository maintanceRepository)
    {
        _maintanceRepository = maintanceRepository;
    }

    public async Task MaintanceIdShouldExistWhenSelected(int id)
    {
        Maintance? result = await _maintanceRepository.GetAsync(predicate: b => b.Id == id, enableTracking: false);
        if (result == null)
            throw new BusinessException(MaintancesBusinessMessages.MaintanceNotExists);
    }

    public async Task MaintanceCarStateControl(int carId)
    {
        Car? car = await _carService.GetById(carId);             
        if (car.CarState!=CarState.Available)
            throw new BusinessException(MaintancesBusinessMessages.CarStateNotAvailableForMaintance);
    }

}