using Application.Features.Rentals.Constants;
using Application.Features.Rentals.Constants;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Rentals.Constants.RentalsOperationClaims;

namespace Application.Features.Rentals.Commands.Delete;

public class DeleteRentalCommand : IRequest<DeletedRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public string[] Roles => new[] { Admin, Write, RentalsOperationClaims.Delete };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRentals";

    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, DeletedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public DeleteRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<DeletedRentalResponse> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            Rental rental = _rentalRepository.Get(b => b.Id == request.Id);

            _rentalRepository.Delete(rental);

            DeletedRentalResponse response = _mapper.Map<DeletedRentalResponse>(rental);
            return response;
        }
    }
}