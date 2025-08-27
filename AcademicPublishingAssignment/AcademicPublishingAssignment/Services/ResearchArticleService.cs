using AcademicPublishingAssignment.DTOs;
using AcademicPublishingAssignment.Repositories;

namespace AcademicPublishingAssignment.Services
{
    public class ResearchArticleService : IResearchArticleService
    {
        private readonly IDataRepository _dataRepository;

        public ResearchArticleService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<ResearchArticleDto?> GetArticleByArticleIdIdAsync(int articleId)
        {
            var article = await _dataRepository.GetArticleByArticleIdAsync(articleId);

            if (article == null)
                return null;

            return new ResearchArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                PublicationDate = article.PublicationDate,
                JournalName = article.Journal.Name,
                Authors = article.ArticleAuthors
                    .OrderBy(aa => aa.AuthorOrder)
                    .Select(aa => aa.Author.FullName)
                    .ToList()
            };
        }

        public async Task<IEnumerable<ResearchArticleDto>> GetAllArticlesAsync()
        {
            var articles = await _dataRepository.GetAllArticlesAsync();

            return articles.Select(article => new ResearchArticleDto
            {
                Id = article.Id,
                Title = article.Title,
                PublicationDate = article.PublicationDate,
                JournalName = article.Journal.Name,
                Authors = article.ArticleAuthors
                    .OrderBy(aa => aa.AuthorOrder)
                    .Select(aa => aa.Author.FullName)
                    .ToList()
            });
        }
    }
}
