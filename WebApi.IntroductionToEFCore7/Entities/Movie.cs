namespace WebApi.IntroductionToEFCore7.Entities;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public bool InCinema { get; set; }
    public DateTime ReleaseDate { get; set; }
    public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>();
    public HashSet<Gender> Genders { get; set; } = new HashSet<Gender>();
    public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}