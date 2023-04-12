using Application.Features.Maintances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Domain.Enums;
using Application.Services.CarService;

namespace Application.Features.Maintances.Commands.Create;

public class CreateMaintanceCommand : IRequest<CreatedMaintanceResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMaintances";

    public class CreateMaintanceCommandHandler : IRequestHandler<CreateMaintanceCommand, CreatedMaintanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintanceRepository _maintanceRepository;
        private readonly MaintanceBusinessRules _maintanceBusinessRules;
        private readonly ICarService _carService;

        public CreateMaintanceCommandHandler(IMapper mapper, IMaintanceRepository maintanceRepository, MaintanceBusinessRules maintanceBusinessRules, ICarService carService)
        {
            _mapper = mapper;
            _maintanceRepository = maintanceRepository;
            _maintanceBusinessRules = maintanceBusinessRules;
            _carService = carService;
        }

        public async Task<CreatedMaintanceResponse> Handle(CreateMaintanceCommand request, CancellationToken cancellationToken)
        {
            Car car = await _carService.GetById(request.CarId);
            await _maintanceBusinessRules.MaintanceCarStateControl(request.CarId);
            Maintance mappedMaintance = _mapper.Map<Maintance>(request);
            _maintanceRepository.Add(mappedMaintance);
            car.CarState = CarState.Maintenance;
            await _carService.Update(car);
            CreatedMaintanceResponse response = _mapper.Map<CreatedMaintanceResponse>(mappedMaintance);
            return response;
        }
    }
}