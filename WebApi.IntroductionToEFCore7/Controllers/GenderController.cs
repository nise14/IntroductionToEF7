using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.IntroductionToEFCore7.Context;
using WebApi.IntroductionToEFCore7.DTOs;
using WebApi.IntroductionToEFCore7.Entities;

namespace WebApi.IntroductionToEFCore7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenderController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GenderController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Post(GenderCreationDTO genderCreation)
    {
        var existGenderWithThisName = await _context.Genders.AnyAsync(g => g.Name == genderCreation.Name);

        if (existGenderWithThisName)
        {
            return BadRequest($"Already exists gender with name {genderCreation.Name}");
        }

        Gender gender = _mapper.Map<Gender>(genderCreation);

        await _context.AddAsync(gender);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("Varios")]
    public async Task<ActionResult> Post(GenderCreationDTO[] gendersCreationDTO)
    {
        Gender[] genders = _mapper.Map<Gender[]>(gendersCreationDTO);
        await _context.AddRangeAsync(genders);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Gender>>> Get()
    {
        return await _context.Genders.ToListAsync();
    }

    [HttpPut("{id:int}/name2")]
    public async Task<ActionResult> Put(int id)
    {
        var gender = await _context.Genders.FirstOrDefaultAsync(g => g.Id == id);

        if (gender is null)
        {
            return NotFound();
        }

        gender.Name = $"{gender.Name}2";

        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, GenderCreationDTO genderCreationDTO)
    {
        var gender = _mapper.Map<Gender>(genderCreationDTO);
        gender.Id = id;
        _context.Update(gender);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete("{id:int}/modern")]
    public async Task<ActionResult> Delete(int id)
    {
        var rowsUpdates = await _context.Genders.Where(g => g.Id == id).ExecuteDeleteAsync();

        if (rowsUpdates == 0)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}/old")]
    public async Task<ActionResult> DeleteOld(int id)
    {
        var gender = await _context.Genders.FirstOrDefaultAsync(g => g.Id == id);

        if (gender is null)
        {
            return NotFound();
        }

        _context.Remove(gender);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}