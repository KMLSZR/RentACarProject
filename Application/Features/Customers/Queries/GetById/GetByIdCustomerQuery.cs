using Application.Features.Customers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerQuery : IRequest<GetByIdCustomerResponse>
{
    public int Id { get; set; }

    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetByIdCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerBusinessRules _customerBusinessRules;

        public GetByIdCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository, CustomerBusinessRules customerBusinessRules)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _customerBusinessRules = customerBusinessRules;
        }

        public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            await _customerBusinessRules.CustomerIdShouldExistWhenSelected(request.Id);
            Customer? customer = await _customerRepository.GetAsync(b => b.Id == request.Id);

            GetByIdCustomerResponse response = _mapper.Map<GetByIdCustomerResponse>(customer);
            return response;
        }
    }
}