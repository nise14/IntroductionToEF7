using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.IntroductionToEFCore7.Entities;
using WebApi.IntroductionToEFCore7.Entities.Seeding;

namespace WebApi.IntroductionToEFCore7.Context;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        SeedingInitial.seed(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Properties<string>().HaveMaxLength(150);
    }

    public DbSet<Gender> Genders => Set<Gender>();
    public DbSet<Actor> Actors => Set<Actor>();
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<MovieActor> MovieActors => Set<MovieActor>();
}