using AutoMapper;
using DripChip.Application.Dto;
using DripChip.Core.Entities;

namespace DripChip.Application.Mappers;

public class ApplicationMapperProfile : Profile
{
    public ApplicationMapperProfile()
    {
        CreateMap<User, UserRequestDto.Registration>().ReverseMap();
        CreateMap<User, UserResponseDto.Info>();
    }
}