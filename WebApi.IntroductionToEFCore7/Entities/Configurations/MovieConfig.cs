using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.IntroductionToEFCore7.Entities.Configurations;

public class MovieConfig : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        //builder.Property(g => g.Title).HasMaxLength(150);
        builder.Property(g => g.ReleaseDate).HasColumnType("Date");
    }
}