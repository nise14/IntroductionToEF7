using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.IntroductionToEFCore7.Context;
using WebApi.IntroductionToEFCore7.DTOs;
using WebApi.IntroductionToEFCore7.Entities;

namespace WebApi.IntroductionToEFCore7.Controllers;

[ApiController]
[Route("api/movies")]
public class MoviesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MoviesController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Post(MovieCreationDTO movieCreation)
    {
        var movie = _mapper.Map<Movie>(movieCreation);

        if (movie.Genders is not null)
        {
            foreach (var gender in movie.Genders)
            {
                _context.Entry(gender).State = EntityState.Unchanged;
            }
        }

        if (movie.MovieActors is not null)
        {
            for (int i = 0; i < movie.MovieActors.Count; i++)
            {
                movie.MovieActors[i].Order = i + 1;
            }
        }

        await _context.AddAsync(movie);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Movie>> Get(int id)
    {
        var movie = await _context.Movies
            .Include(p => p.Comments)
            .Include(p => p.Genders)
            .Include(p => p.MovieActors.OrderBy(o => o.Order))
                .ThenInclude(p => p.Actor)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        return movie;
    }

    [HttpGet("select/{id:int}")]
    public async Task<ActionResult<Movie>> GetSelect(int id)
    {
        var movie = await _context.Movies
            .Select(pel => new
            {
                pel.Id,
                pel.Title,
                Genders = pel.Genders.Select(g => g.Name).ToList(),
                Actors = pel.MovieActors.OrderBy(pa => pa.Order).Select(pa => new
                {
                    Id = pa.ActorId,
                    pa.Actor.Name,
                    pa.Character
                }),
                CountComments = pel.Comments.Count
            })
            .FirstOrDefaultAsync(p => p.Id == id);

        if (movie is null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpDelete("{id:int}/modern")]
    public async Task<ActionResult> Delete(int id)
    {
        var rowsUpdates = await _context.Movies.Where(g => g.Id == id).ExecuteDeleteAsync();

        if (rowsUpdates == 0)
        {
            return NotFound();
        }

        return NoContent();
    }
}