using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Customers.Queries.GetList;

public class GetListCustomerQuery : IRequest<GetListResponse<GetListCustomerListItemDto>>, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public bool BypassCache { get; }
    public string CacheKey => $"GetListCustomers({PageRequest.Page},{PageRequest.PageSize})";
    public string CacheGroupKey => "GetCustomers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, GetListResponse<GetListCustomerListItemDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetListCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCustomerListItemDto>> Handle(GetListCustomerQuery request,
                                                                   CancellationToken cancellationToken)
        {
            IPaginate<Customer> customers = await _customerRepository.GetListAsync(index: request.PageRequest.Page,
                                                                          size: request.PageRequest.PageSize);

            GetListResponse<GetListCustomerListItemDto> response = _mapper.Map<GetListResponse<GetListCustomerListItemDto>>(customers);
            return response;
        }
    }
}