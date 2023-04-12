using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IMaintanceRepository : IAsyncRepository<Maintance, int>, IRepository<Maintance, int>
{
}