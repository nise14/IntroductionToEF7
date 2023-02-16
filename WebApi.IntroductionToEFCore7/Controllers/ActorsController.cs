using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.IntroductionToEFCore7.Context;
using WebApi.IntroductionToEFCore7.DTOs;
using WebApi.IntroductionToEFCore7.Entities;

namespace WebApi.IntroductionToEFCore7.Controllers;

[ApiController]
[Route("api/actors")]
public class ActorsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ActorsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Post(ActorCreationDTO actorCreation)
    {
        var actor = _mapper.Map<Actor>(actorCreation);
        await _context.AddAsync(actor);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Actor>>> Get()
    {
        return await _context.Actors.OrderBy(a => a.DateOfBirth).ToListAsync();
    }

    [HttpGet("name")]
    public async Task<ActionResult<IEnumerable<Actor>>> Get(string name)
    {
        return await _context.Actors.Where(a => a.Name.Contains(name))
        .OrderBy(a => a.Name)
        .ThenBy(a => a.DateOfBirth)
        .ToListAsync();
    }

    [HttpGet("dateOfBirth/range")]
    public async Task<ActionResult<IEnumerable<Actor>>> GetV2(DateTime start, DateTime end)
    {
        return await _context.Actors.Where(a => a.DateOfBirth >= start && a.DateOfBirth <= end).ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Actor>> Get(int id)
    {
        var actor = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);

        if (actor is null)
        {
            return NotFound();
        }

        return actor;
    }

    [HttpGet("idYName")]
    public async Task<ActionResult<IEnumerable<ActorDTO>>> GetIdName()
    {
        return await _context.Actors.ProjectTo<ActorDTO>(_mapper.ConfigurationProvider).ToListAsync();
    }
}