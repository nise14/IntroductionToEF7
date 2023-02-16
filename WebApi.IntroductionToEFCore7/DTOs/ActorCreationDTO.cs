using System.ComponentModel.DataAnnotations;

namespace WebApi.IntroductionToEFCore7.DTOs;

public class ActorCreationDTO
{
    [StringLength(150)]
    public string Name { get; set; } = null!;
    public decimal Fortune { get; set; }
    public DateTime DateOfBirth { get; set; }
}