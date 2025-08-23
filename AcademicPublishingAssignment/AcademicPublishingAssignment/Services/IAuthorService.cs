using AcademicPublishingAssignment.DTOs;

namespace AcademicPublishingAssignment.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<ResearchArticleSummaryDto>> GetArticlesByAuthorIdAsync(int authorId);
        Task<AuthorDto?> GetAuthorByAuthorIdAsync(int authorId);
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
    }
}
