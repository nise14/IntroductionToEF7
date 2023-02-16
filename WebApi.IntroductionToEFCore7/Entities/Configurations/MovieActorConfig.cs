using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.IntroductionToEFCore7.Entities.Configurations;

public class MovieActorConfig : IEntityTypeConfiguration<MovieActor>
{
    public void Configure(EntityTypeBuilder<MovieActor> builder)
    {
        builder.HasKey(pa => new { pa.ActorId, pa.MovieId });
    }
}