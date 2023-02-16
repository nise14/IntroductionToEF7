using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.IntroductionToEFCore7.Entities.Configurations;

public class GenderConfig : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        //builder.HasKey(g => g.Id);
        builder.Property(g => g.Name).HasMaxLength(150);

        var scienceFiction = new Gender
        {
            Id = 5,
            Name = "Science fiction"
        };

        var animation = new Gender
        {
            Id = 6,
            Name = "Animation"
        };

        builder.HasData(scienceFiction, animation);

        builder.HasIndex(p => p.Name).IsUnique();
    }
}