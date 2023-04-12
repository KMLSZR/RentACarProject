using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ICarRepository : IAsyncRepository<Car, int>, IRepository<Car, int>
{
}