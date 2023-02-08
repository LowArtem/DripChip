using DripChip.Core.Entities;
using DripChip.Core.Enums;
using DripChip.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DripChip.Infrastructure.Data.Configurations;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        builder.Property(t => t.Gender)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: v => v.ToString(),
                convertFromProviderExpression: v => EnumExtensions.ParseEnumThrowable<Gender>(v)
            );

        builder.Property(t => t.LifeStatus)
            .IsRequired()
            .HasConversion(
                convertToProviderExpression: v => v.ToString(),
                convertFromProviderExpression: v => EnumExtensions.ParseEnumThrowable<LifeStatus>(v)
            );
    }
}