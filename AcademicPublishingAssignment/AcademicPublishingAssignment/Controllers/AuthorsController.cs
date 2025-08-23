using AcademicPublishingAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademicPublishingAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("{authorId:int}/articles")]
        public async Task<IActionResult> GetArticlesByAuthorId(int authorId)
        {
            if (authorId <= 0)
            {
                return BadRequest("Author ID must be a positive integer.");
            }

            // First check if author exists
            var author = await _authorService.GetAuthorByAuthorIdAsync(authorId);
            if (author == null)
            {
                return NotFound($"Author with ID {authorId} not found.");
            }

            var articles = await _authorService.GetArticlesByAuthorIdAsync(authorId);
            return Ok(articles);
        }

        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> GetAuthorByAuthorId(int authorId)
        {
            if (authorId <= 0)
            {
                return BadRequest("Author ID must be a positive integer.");
            }

            var author = await _authorService.GetAuthorByAuthorIdAsync(authorId);

            if (author == null)
            {
                return NotFound($"Author with ID {authorId} not found.");
            }

            return Ok(author);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }
    }
}
