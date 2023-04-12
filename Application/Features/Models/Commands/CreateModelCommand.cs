using Application.Features.Models.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands;

public class CreateModelCommand : IRequest<CreatedModelResponse>
{
    public string Name { get; set; }
    public int BrandId { get; set; }
    public int FuelId { get; set; }
    public int TransmissionId { get; set; }
    public double DailyPrice { get; set; }
    public string ImageUrl { get; set; }
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;
        ModelBusinessRules _modelBusinessRules;

        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, ModelBusinessRules modelBusinessRules)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _modelBusinessRules = modelBusinessRules;
        }

        public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            await _modelBusinessRules.ModelFuelFiveLimitControlWhenInserted(request.FuelId);
            await _modelBusinessRules.ModelTransmissionFiveLimitControlWhenInserted(request.TransmissionId);
            Model mappedModel = _mapper.Map<Model>(request);
            Model createdModel = await _modelRepository.AddAsync(mappedModel);
            CreatedModelResponse response = _mapper.Map<CreatedModelResponse>(createdModel);
            return response;

        }
    }
}
