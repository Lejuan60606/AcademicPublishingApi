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
                Journal = new JournalDto
                {
                    Id = article.Journal.Id,
                    Name = article.Journal.Name,
                    ISSN = article.Journal.ISSN,
                    Publisher = article.Journal.Publisher,
                    Description = article.Journal.Description
                },
                Authors = article.ArticleAuthors
                    .OrderBy(aa => aa.AuthorOrder)
                    .Select(aa => new AuthorDto
                    {
                        Id = aa.Author.Id,
                        FirstName = aa.Author.FirstName,
                        LastName = aa.Author.LastName,
                        Affiliation = aa.Author.Affiliation,
                        Email = aa.Author.Email,
                        FullName = aa.Author.FullName,
                        AuthorOrder = aa.AuthorOrder
                    })
                    .ToList()
            };
        }

        public async Task<IEnumerable<ResearchArticleSummaryDto>> GetAllArticlesAsync()
        {
            var articles = await _dataRepository.GetAllArticlesAsync();

            return articles.Select(article => new ResearchArticleSummaryDto
            {
                Id = article.Id,
                Title = article.Title,
                PublicationDate = article.PublicationDate,
                JournalName = article.Journal.Name,
                AuthorNames = article.ArticleAuthors
                    .OrderBy(aa => aa.AuthorOrder)
                    .Select(aa => aa.Author.FullName)
                    .ToList()
            });
        }
    }
}
