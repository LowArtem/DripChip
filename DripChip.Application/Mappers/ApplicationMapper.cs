using AutoMapper;

namespace DripChip.Application.Mappers;

public static class ApplicationMapper
{
    private static readonly Lazy<IMapper> LazyMapper = new(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<ApplicationMapperProfile>();
        });

        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => LazyMapper.Value;
}