using Application.Features.Maintances.Commands.Create;
using Application.Features.Maintances.Commands.Delete;
using Application.Features.Maintances.Commands.Update;
using Application.Features.Maintances.Queries.GetById;
using Application.Features.Maintances.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Maintances.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Maintance, CreateMaintanceCommand>().ReverseMap();
        CreateMap<Maintance, CreatedMaintanceResponse>().ReverseMap();
        CreateMap<Maintance, UpdateMaintanceCommand>().ReverseMap();
        CreateMap<Maintance, UpdatedMaintanceResponse>().ReverseMap();
        CreateMap<Maintance, DeleteMaintanceCommand>().ReverseMap();
        CreateMap<Maintance, DeletedMaintanceResponse>().ReverseMap();
        CreateMap<Maintance, GetByIdMaintanceResponse>().ReverseMap();
        CreateMap<Maintance, GetListMaintanceListItemDto>().ReverseMap();
        CreateMap<IPaginate<Maintance>, GetListResponse<GetListMaintanceListItemDto>>().ReverseMap();
    }
}