namespace WebApi.IntroductionToEFCore7.DTOs;

public class MovieActorCreationDTO
{
    public int ActorId { get; set; }
    public string Character { get; set; } = null!;
}