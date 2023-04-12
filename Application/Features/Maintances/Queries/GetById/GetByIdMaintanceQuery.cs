using Application.Features.Maintances.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Maintances.Queries.GetById;

public class GetByIdMaintanceQuery : IRequest<GetByIdMaintanceResponse>
{
    public int Id { get; set; }

    public class GetByIdMaintanceQueryHandler : IRequestHandler<GetByIdMaintanceQuery, GetByIdMaintanceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IMaintanceRepository _maintanceRepository;
        private readonly MaintanceBusinessRules _maintanceBusinessRules;

        public GetByIdMaintanceQueryHandler(IMapper mapper, IMaintanceRepository maintanceRepository, MaintanceBusinessRules maintanceBusinessRules)
        {
            _mapper = mapper;
            _maintanceRepository = maintanceRepository;
            _maintanceBusinessRules = maintanceBusinessRules;
        }

        public async Task<GetByIdMaintanceResponse> Handle(GetByIdMaintanceQuery request, CancellationToken cancellationToken)
        {
            await _maintanceBusinessRules.MaintanceIdShouldExistWhenSelected(request.Id);
            Maintance? maintance = await _maintanceRepository.GetAsync(b => b.Id == request.Id);

            GetByIdMaintanceResponse response = _mapper.Map<GetByIdMaintanceResponse>(maintance);
            return response;
        }
    }
}