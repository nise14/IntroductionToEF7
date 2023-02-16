using Microsoft.EntityFrameworkCore;

namespace WebApi.IntroductionToEFCore7.Entities.Seeding;

public class SeedingInitial
{
    public static void seed(ModelBuilder modelBuilder)
    {
        var actor1 = new Actor
        {
            Id = 2,
            Name = "Samuel L Jackson",
            DateOfBirth = new DateTime(1948, 12, 21),
            Fortune = 15000
        };

        var actor2 = new Actor
        {
            Id = 3,
            Name = "Robert Downey Jr",
            DateOfBirth = new DateTime(1965, 4, 4),
            Fortune = 18000
        };

        modelBuilder.Entity<Actor>().HasData(actor1, actor2);

        var movie1 = new Movie
        {
            Id = 4,
            Title = "Avengers Endgame",
            ReleaseDate = new DateTime(2019, 4, 22)
        };

        var movie2 = new Movie
        {
            Id = 5,
            Title = "Spiderman: No way home",
            ReleaseDate = new DateTime(2021, 12, 13)
        };

        var movie3 = new Movie
        {
            Id = 6,
            Title = "Spiderman: Across the Spider-Verse (Part one)",
            ReleaseDate = new DateTime(2022, 10, 7)
        };

        modelBuilder.Entity<Movie>().HasData(movie1, movie2, movie3);

        var comment1 = new Comment
        {
            Id = 3,
            IsRecommend = true,
            Content = "Muy buena!!!",
            MovieId = movie1.Id
        };

        var comment2 = new Comment
        {
            Id = 4,
            IsRecommend = true,
            Content = "Dura dura",
            MovieId = movie2.Id
        };

        var comment3 = new Comment
        {
            Id = 5,
            IsRecommend = false,
            Content = "no debieron hacer eso...",
            MovieId = movie3.Id
        };

        modelBuilder.Entity<Comment>().HasData(comment1, comment2, comment3);

        var tableGenderMovie = "GenderMovie";
        var genderId = "GendersId";
        var movieId = "MoviesId";

        modelBuilder.Entity(tableGenderMovie).HasData(
            new Dictionary<string, object>
            {
                [genderId] = 5,
                [movieId] = movie1.Id
            },
            new Dictionary<string, object>
            {
                [genderId] = 5,
                [movieId] = movie2.Id
            },
            new Dictionary<string, object>
            {
                [genderId] = 6,
                [movieId] = movie3.Id
            }
        );

        var movieActor1 = new MovieActor
        {
            ActorId = actor1.Id,
            MovieId = movie2.Id,
            Order = 1,
            Character = "Nick Fury"
        };

        var movieActor2 = new MovieActor
        {
            ActorId = actor1.Id,
            MovieId = movie1.Id,
            Order = 2,
            Character = "Nick Fury"
        };

        var movieActor3 = new MovieActor
        {
            ActorId = actor2.Id,
            MovieId = movie1.Id,
            Order = 1,
            Character = "Iron Man"
        };

        modelBuilder.Entity<MovieActor>().HasData(movieActor1, movieActor2, movieActor3);
    }
}