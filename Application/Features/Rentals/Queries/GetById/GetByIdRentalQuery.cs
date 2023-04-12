using Application.Features.Rentals.Constants;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Rentals.Constants.RentalsOperationClaims;

namespace Application.Features.Rentals.Queries.GetById;

public class GetByIdRentalQuery : IRequest<GetByIdRentalResponse>, ISecuredRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Read };

    public class GetByIdRentalQueryHandler : IRequestHandler<GetByIdRentalQuery, GetByIdRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public GetByIdRentalQueryHandler(IMapper mapper, IRentalRepository rentalRepository, RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<GetByIdRentalResponse> Handle(GetByIdRentalQuery request, CancellationToken cancellationToken)
        {
            await _rentalBusinessRules.RentalIdShouldExistWhenSelected(request.Id);
            Rental? rental = await _rentalRepository.GetAsync(b => b.Id == request.Id);

            GetByIdRentalResponse response = _mapper.Map<GetByIdRentalResponse>(rental);
            return response;
        }
    }
}