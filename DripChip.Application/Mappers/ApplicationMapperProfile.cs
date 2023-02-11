using AutoMapper;
using DripChip.Core.Entities;
using DripChip.Core.RequestDto;

namespace DripChip.Application.Mappers;

public class ApplicationMapperProfile : Profile
{
    public ApplicationMapperProfile()
    {
        CreateMap<User, UserRequestDto.Registration>().ReverseMap();
    }
}