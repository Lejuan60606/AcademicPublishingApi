using AcademicPublishingAssignment.DTOs;
using AcademicPublishingAssignment.Repositories;

namespace AcademicPublishingAssignment.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IDataRepository _dataRepository;

        public AuthorService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<ResearchArticleDto>> GetArticlesByAuthorIdAsync(int authorId)
        {
            var articles = await _dataRepository.GetArticlesByAuthorIdAsync(authorId);

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

        public async Task<AuthorDto?> GetAuthorByAuthorIdAsync(int authorId)
        {
            var author = await _dataRepository.GetAuthorByAuthorIdAsync(authorId);

            if (author == null)
                return null;

            return new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Affiliation = author.Affiliation,
                Email = author.Email,
                FullName = author.FullName
            };
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await _dataRepository.GetAllAuthorsAsync();

            return authors.Select(author => new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                Affiliation = author.Affiliation,
                Email = author.Email,
                FullName = author.FullName
            });
        }
    }
}
