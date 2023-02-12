using AutoMapper;
using DripChip.Application.Dto;
using DripChip.Core.Entities;

namespace DripChip.Application.Mappers;

public class ApplicationMapperProfile : Profile
{
    public ApplicationMapperProfile()
    {
        CreateMap<User, UserRequestDto.AccountManagement>();
        
        CreateMap<UserRequestDto.AccountManagement, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        
        CreateMap<User, UserResponseDto.Info>();
    }
}