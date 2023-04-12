
using Application.Services.Repositories;
using Core.Security.Entities;
using Domain.Entities;

namespace Application.Services.CarService;

public class CarManager : ICarService
{
    private readonly ICarRepository _carRepository;

    public CarManager(ICarRepository carRepository)
    {
        _carRepository = carRepository;
    }


    public async Task<Car> GetById(int id)
    {
        Car? car = await _carRepository.GetAsync(u => u.Id == id);
        return car;
    }

    public async Task<Car> Update(Car car)
    {
        Car updatedCar = await _carRepository.UpdateAsync(car);
        return updatedCar;
    }
}
