namespace WebApi.IntroductionToEFCore7.Entities;

public class Gender
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
}