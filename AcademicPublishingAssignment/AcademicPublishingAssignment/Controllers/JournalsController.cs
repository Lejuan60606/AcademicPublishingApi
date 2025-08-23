using AcademicPublishingAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcademicPublishingAssignment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalsController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalsController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpGet("{journalId:int}/articles")]
        public async Task<IActionResult> GetArticlesByJournalId(int journalId)
        {
            if (journalId <= 0)
            {
                return BadRequest("Journal ID must be a positive integer.");
            }

            // First check if journal exists
            var journal = await _journalService.GetJournalByIdAsync(journalId);
            if (journal == null)
            {
                return NotFound($"Journal with ID {journalId} not found.");
            }

            var articles = await _journalService.GetArticlesByJournalIdAsync(journalId);
            return Ok(articles);
        }

        [HttpGet("{journalId:int}")]
        public async Task<IActionResult> GetJournalById(int journalId)
        {
            if (journalId <= 0)
            {
                return BadRequest("Journal ID must be a positive integer.");
            }

            var journal = await _journalService.GetJournalByIdAsync(journalId);

            if (journal == null)
            {
                return NotFound($"Journal with ID {journalId} not found.");
            }

            return Ok(journal);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJournals()
        {
            var journals = await _journalService.GetAllJournalsAsync();
            return Ok(journals);
        }
    }
}
