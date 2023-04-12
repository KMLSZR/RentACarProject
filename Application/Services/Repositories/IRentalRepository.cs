using Domain.Entities;
using Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IRentalRepository : IAsyncRepository<Rental, int>, IRepository<Rental, int>
{
}