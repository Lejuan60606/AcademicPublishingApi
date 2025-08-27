using AcademicPublishingAssignment.DTOs;

namespace AcademicPublishingAssignment.Services
{
    public interface IResearchArticleService
    {
        Task<ResearchArticleDto?> GetArticleByArticleIdIdAsync(int articleId);
        Task<IEnumerable<ResearchArticleDto>> GetAllArticlesAsync();
    }
}
