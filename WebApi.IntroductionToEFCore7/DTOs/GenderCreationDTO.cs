using System.ComponentModel.DataAnnotations;

namespace WebApi.IntroductionToEFCore7.DTOs;

public class GenderCreationDTO
{
    [StringLength(maximumLength: 150)]
    public string Name { get; set; } = null!;
}