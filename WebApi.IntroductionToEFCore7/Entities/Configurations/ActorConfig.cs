using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.IntroductionToEFCore7.Entities.Configurations;

public class ActorConfig : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        //builder..Property(g => g.Name).HasMaxLength(150);
        builder.Property(g => g.DateOfBirth).HasColumnType("Date");
        builder.Property(g => g.Fortune).HasPrecision(18, 2);
    }
}