using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ITransactionalRequest,
    ILoggableRequest, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => new[] { "Admin" };

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;
        BrandBusinessRules _brandBusinessRules;

        public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
            _brandBusinessRules = brandBusinessRules;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);
            Brand mappedBrand = _mapper.Map<Brand>(request);
            Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
            CreatedBrandResponse response = _mapper.Map<CreatedBrandResponse>(createdBrand);
            return response;

        }
    }
}
