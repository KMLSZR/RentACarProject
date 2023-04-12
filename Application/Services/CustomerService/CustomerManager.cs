using Application.Services.FindeksService;
using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CustomerService;

public class CustomerManager : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IFindeksService _findeksService;

    public CustomerManager(ICustomerRepository customerRepository, IFindeksService findeksService)
    {
        _customerRepository = customerRepository;
        _findeksService = findeksService;
    }

    public async Task<Customer?> GetById(int id)
    {
        Customer? customer = await _customerRepository.GetAsync(c => c.Id == id);
        return customer;
    }

    public async Task<short> GetScore(string nationalId)
    {
        short score = _findeksService.GetScore(nationalId);
        return score;
    }
}
