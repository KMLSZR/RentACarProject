using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class RentalRepository : EfRepositoryBase<Rental, int, BaseDbContext>, IRentalRepository
{
    public RentalRepository(BaseDbContext context) : base(context)
    {
    }
}