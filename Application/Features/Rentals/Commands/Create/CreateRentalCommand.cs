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
using Application.Services.CarService;
using Domain.Enums;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommand : IRequest<CreatedRentalResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CarId { get; set; }
    public int CustomerId { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public int RentStartKilometer { get; set; }
    public int? RentEndKilometer { get; set; }
    public string CardNumber { get; set; }
    public string CardHolder { get; set; }
    public string ExpiredDate { get; set; }
    public string CVCNumber { get; set; }

    public string[] Roles => new[] { Admin, Write, RentalsOperationClaims.Create };

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetRentals";

    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreatedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;
        private readonly ICarService _carService;

        public CreateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
            RentalBusinessRules rentalBusinessRules, ICarService carService)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
            _carService = carService;
        }

        public async Task<CreatedRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carService.GetById(request.CarId);
            await _rentalBusinessRules.RentalCustomerScoreControlCreated(request.CustomerId, car.MinFindeksCreditRate);
            await _rentalBusinessRules.RentalCarAvailableWhenCreated(request.CarId);
            await _rentalBusinessRules.RentalCustomerBalanceControl(request.CardNumber, request.CardHolder, request.ExpiredDate, request.CVCNumber);
            Rental mappedRental = _mapper.Map<Rental>(request);
            _rentalRepository.Add(mappedRental);
            CreatedRentalResponse response = _mapper.Map<CreatedRentalResponse>(mappedRental);
            car.CarState = CarState.Rented;
            await _carService.Update(car);
            return response;
        }
    }
}