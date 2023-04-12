using Application.Features.Maintances.Constants;
using Application.Features.Maintances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace Application.Features.Maintances.Commands.Delete;

public class DeleteMaintanceCommand : IRequest<DeletedMaintanceResponse>, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public int Id { get; set; }

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string CacheGroupKey => "GetMaintances";

    public class DeleteMaintanceCommandHandler : IRequestHandler<DeleteMaintanceCommand, DeletedMaintanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintanceRepository _maintanceRepository;
        private readonly MaintanceBusinessRules _maintanceBusinessRules;

        public DeleteMaintanceCommandHandler(IMapper mapper, IMaintanceRepository maintanceRepository,
                                         MaintanceBusinessRules maintanceBusinessRules)
        {
            _mapper = mapper;
            _maintanceRepository = maintanceRepository;
            _maintanceBusinessRules = maintanceBusinessRules;
        }

        public async Task<DeletedMaintanceResponse> Handle(DeleteMaintanceCommand request, CancellationToken cancellationToken)
        {
            Maintance maintance = _maintanceRepository.GetAsync(b => b.Id == request.Id).Result;

            _maintanceRepository.DeleteAsync(maintance);

            DeletedMaintanceResponse response = _mapper.Map<DeletedMaintanceResponse>(maintance);
            return response;
        }
    }
}