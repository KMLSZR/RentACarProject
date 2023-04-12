using Application.Features.OperationClaims.Commands.Create;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();
        CreateMap<OperationClaim, CreatedOperationClaimResponse>().ReverseMap();
        //CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();
        //CreateMap<OperationClaim, UpdatedOperationClaimResponse>().ReverseMap();
        //CreateMap<OperationClaim, DeleteOperationClaimCommand>().ReverseMap();
        //CreateMap<OperationClaim, DeletedOperationClaimResponse>().ReverseMap();
        //CreateMap<OperationClaim, GetByIdOperationClaimResponse>().ReverseMap();
        //CreateMap<OperationClaim, GetListOperationClaimListItemDto>().ReverseMap();
        //CreateMap<IPaginate<OperationClaim>, GetListResponse<GetListOperationClaimListItemDto>>().ReverseMap();
    }
}
