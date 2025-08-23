using AcademicPublishingAssignment.DTOs;

namespace AcademicPublishingAssignment.Services
{
    public interface IJournalService
    {
        Task<IEnumerable<ResearchArticleSummaryDto>> GetArticlesByJournalIdAsync(int journalId);
        Task<JournalDto?> GetJournalByIdAsync(int journalId);
        Task<IEnumerable<JournalDto>> GetAllJournalsAsync();
    }
}
