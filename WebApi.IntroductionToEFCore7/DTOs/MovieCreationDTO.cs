namespace WebApi.IntroductionToEFCore7.DTOs;

public class MovieCreationDTO
{
    public string Title { get; set; } = null!;
    public bool InCinema { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<int> Genders { get; set; } = new List<int>();
    public List<MovieActorCreationDTO> MovieActors { get; set; } = new List<MovieActorCreationDTO>();
}