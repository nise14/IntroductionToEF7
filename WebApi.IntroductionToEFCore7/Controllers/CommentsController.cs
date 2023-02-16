using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.IntroductionToEFCore7.Context;
using WebApi.IntroductionToEFCore7.DTOs;
using WebApi.IntroductionToEFCore7.Entities;

namespace WebApi.IntroductionToEFCore7.Controllers;

[ApiController]
[Route("api/movies/{movieId:int}/comments")]
public class CommentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CommentsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult> Post(int movieId, CommentCreationDTO commentCreationDTO)
    {
        Comment comment = _mapper.Map<Comment>(commentCreationDTO);
        comment.MovieId = movieId;
        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();
        return Ok();
    }
}