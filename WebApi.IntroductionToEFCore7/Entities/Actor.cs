namespace WebApi.IntroductionToEFCore7.Entities;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Fortune { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<MovieActor> MovieActors { get; set; } = new List<MovieActor>();
}