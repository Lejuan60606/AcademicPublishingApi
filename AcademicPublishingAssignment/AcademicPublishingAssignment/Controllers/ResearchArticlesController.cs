using AcademicPublishingAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademicPublishingAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResearchArticlesController: ControllerBase
    {
        private readonly IResearchArticleService _articleService;
        public ResearchArticlesController(IResearchArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("{articleId:int}")]
        public async Task<IActionResult> GetArticleByArticleId(int articleId)
        {
            if (articleId <= 0)
            {
                return BadRequest("Article ID must be a positive integer.");
            }

            var article = await _articleService.GetArticleByArticleIdIdAsync(articleId);

            if (article == null)
            {
                return NotFound($"Research article with ID {articleId} not found.");
            }

            return Ok(article);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllArticles()
        {
            var articles = await _articleService.GetAllArticlesAsync();
            return Ok(articles);
        }
    }
}
