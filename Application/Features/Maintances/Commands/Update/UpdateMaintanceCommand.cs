using Application.Features.Maintances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using Application.Services.CarService;
using Domain.Enums;

namespace Application.Features.Maintances.Commands.Update;

public class UpdateMaintanceCommand : IRequest<UpdatedMaintanceResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMaintances";

    public class UpdateMaintanceCommandHandler : IRequestHandler<UpdateMaintanceCommand, UpdatedMaintanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintanceRepository _maintanceRepository;
        private readonly MaintanceBusinessRules _maintanceBusinessRules;
        private readonly ICarService _carService;

        public UpdateMaintanceCommandHandler(IMapper mapper, IMaintanceRepository maintanceRepository, MaintanceBusinessRules maintanceBusinessRules, ICarService carService)
        {
            _mapper = mapper;
            _maintanceRepository = maintanceRepository;
            _maintanceBusinessRules = maintanceBusinessRules;
            _carService = carService;
        }

        public async Task<UpdatedMaintanceResponse> Handle(UpdateMaintanceCommand request, CancellationToken cancellationToken)
        {
            Car? car=await _carService.GetById(request.CarId);
            Maintance maintance = _maintanceRepository.Get(b => b.Id == request.Id);
            Maintance mappedMaintance = _mapper.Map(request, maintance);
            _maintanceRepository.Update(mappedMaintance);
            car.CarState = CarState.Available;
            await _carService.Update(car);
            UpdatedMaintanceResponse response = _mapper.Map<UpdatedMaintanceResponse>(maintance);
            return response;
        }
    }
}