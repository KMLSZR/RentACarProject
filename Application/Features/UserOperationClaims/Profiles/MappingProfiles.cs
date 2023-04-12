using Application.Features.UserOperationClaims.Commands.Create;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaims.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
        CreateMap<UserOperationClaim, CreatedUserOperationClaimResponse>().ReverseMap();
        //CreateMap<UserOperationClaim, UpdateUserOperationClaimCommand>().ReverseMap();
        //CreateMap<UserOperationClaim, UpdatedUserOperationClaimResponse>().ReverseMap();
        //CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();
        //CreateMap<UserOperationClaim, DeletedUserOperationClaimResponse>().ReverseMap();
        //CreateMap<UserOperationClaim, GetByIdUserOperationClaimResponse>().ReverseMap();
        //CreateMap<UserOperationClaim, GetListUserOperationClaimListItemDto>().ReverseMap();
        //CreateMap<IPaginate<UserOperationClaim>, GetListResponse<GetListUserOperationClaimListItemDto>>().ReverseMap();
    }
}
