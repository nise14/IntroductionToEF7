using AutoMapper;
using WebApi.IntroductionToEFCore7.DTOs;
using WebApi.IntroductionToEFCore7.Entities;

namespace WebApi.IntroductionToEFCore7.Utils;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<GenderCreationDTO, Gender>();
        CreateMap<ActorCreationDTO, Actor>();
        CreateMap<Actor, ActorDTO>();
        CreateMap<CommentCreationDTO, Comment>();
        CreateMap<MovieCreationDTO, Movie>()
            .ForMember(ent => ent.Genders,
                        dto => dto.MapFrom(f =>
                            f.Genders.Select(id =>
                                new Gender
                                {
                                    Id = id
                                }
                                    )
                                )
                            );

        CreateMap<MovieActorCreationDTO, MovieActor>();

    }
}