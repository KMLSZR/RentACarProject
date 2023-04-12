using Application.Features.Models.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelQuery : IRequest<GetListResponse<GetListModelListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;

        public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
        {
            //IPaginate<Model> models = await _modelRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            //var mappedModels = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);
            //return mappedModels;

            IPaginate<Model> models = await _modelRepository.GetListAsync(
                include: m => m.Include(m => m.Brand).Include(m=>m.Fuel).Include(m=>m.Transmission),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            var mappedModels = _mapper.Map<GetListResponse<GetListModelListItemDto>>(models);
            return mappedModels;
        }
    }
}
