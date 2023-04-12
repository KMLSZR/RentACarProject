using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerService;

public interface ICustomerService
{
    public Task<Customer?> GetById(int id);
    public Task<short> GetScore(string nationalId);
}
