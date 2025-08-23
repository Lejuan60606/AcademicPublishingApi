using AcademicPublishingAssignment.Models;

namespace AcademicPublishingAssignment.Repositories
{
    public interface IDataRepository
    {
        Task<IEnumerable<ResearchArticle>> GetAllArticlesAsync();
        Task<ResearchArticle?> GetArticleByArticleIdAsync(int id);
        Task<IEnumerable<ResearchArticle>> GetArticlesByAuthorIdAsync(int authorId);
        Task<IEnumerable<ResearchArticle>> GetArticlesByJournalIdAsync(int journalId);
        Task<Author?> GetAuthorByAuthorIdAsync(int id);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Journal?> GetJournalByJournalIdAsync(int id);
        Task<IEnumerable<Journal>> GetAllJournalsAsync();
    }
}
