using AcademicPublishingAssignment.DTOs;

namespace AcademicPublishingAssignment.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<ResearchArticleDto>> GetArticlesByAuthorIdAsync(int authorId);
        Task<AuthorDto?> GetAuthorByAuthorIdAsync(int authorId);
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();
    }
}
