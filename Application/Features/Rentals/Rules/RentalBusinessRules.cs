using Application.Features.Rentals.Constants;
using Application.Services.PosService;
using Application.Services.CarService;
using Application.Services.CustomerService;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Rentals.Rules;

public class RentalBusinessRules : BaseBusinessRules
{
    private readonly IRentalRepository _rentalRepository;
    private readonly ICarService _carService;
    private readonly ICustomerService _customerService;
    private readonly IPosService _posService;

    public RentalBusinessRules(IRentalRepository rentalRepository, ICarService carService, ICustomerService customerService, IPosService posService)
    {
        _rentalRepository = rentalRepository;
        _carService = carService;
        _customerService = customerService;
        _posService = posService;
    }

    public async Task RentalIdShouldExistWhenSelected(int id)
    {
        Rental? result = await _rentalRepository.GetAsync(predicate: b => b.Id == id, enableTracking: false);
        if (result == null)
            throw new BusinessException(RentalsBusinessMessages.RentalNotExists);
    }

    public async Task RentalCarAvailableWhenCreated(int carId)
    {
        Car? car = await _carService.GetById(carId);
        if (car != null && car.CarState != CarState.Available)
            throw new BusinessException(RentalsBusinessMessages.RentalCarNotAvailable);
    }

    public async Task RentalCustomerScoreControlCreated(int customerId, short carMinFindeksCreditRate)
    {
        Customer? customer = await _customerService.GetById(customerId);
        var score = await _customerService.GetScore(customer.NationalId);
        if (score < carMinFindeksCreditRate)
            throw new BusinessException(RentalsBusinessMessages.RentalCustomerScoreLessCarMinFindeksCreditRate);
    }

    public async Task RentalCustomerBalanceControl(string carNumber, string cardHolder, string expiredDate, string cvcNumber)
    {
        bool balanceControl = _posService.PayControl(carNumber, cardHolder, expiredDate, cvcNumber);
        if (!balanceControl)
            throw new BusinessException(RentalsBusinessMessages.CustomerBalanceNotYet);
    }
}