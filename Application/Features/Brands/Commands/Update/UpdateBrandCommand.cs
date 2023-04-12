using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Update;

public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand? brand = await _brandRepository.GetAsync(x => x.Id == request.Id);
            _mapper.Map(request, brand);
            Brand updateBrand = await _brandRepository.UpdateAsync(brand);

            UpdatedBrandResponse _response = _mapper.Map<UpdatedBrandResponse>(updateBrand);
            return _response;
        }
    }
}
