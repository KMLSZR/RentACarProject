using Application.Features.Models.Commands;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetList.GetListByDynamic;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Model, CreateModelCommand>().ReverseMap();
        CreateMap<Model, CreatedModelResponse>().ReverseMap();
        CreateMap<Model, GetListModelListItemDto>().ForMember(destinationMember: c => c.BrandName,
            memberOptions: opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
        CreateMap<IPaginate<Model>, GetListResponse<GetListModelListItemDto>>().ReverseMap();
        CreateMap<Model, GetListByDynamicModelListItemDto>().ForMember(destinationMember: c => c.BrandName,
            memberOptions: opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();
        CreateMap<IPaginate<Model>, GetListResponse<GetListByDynamicModelListItemDto>>().ReverseMap();
    }
}
