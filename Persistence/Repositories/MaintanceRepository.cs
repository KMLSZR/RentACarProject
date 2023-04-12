using Application.Services.Repositories;
using Domain.Entities;
using Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class MaintanceRepository : EfRepositoryBase<Maintance, int, BaseDbContext>, IMaintanceRepository
{
    public MaintanceRepository(BaseDbContext context) : base(context)
    {
    }
}