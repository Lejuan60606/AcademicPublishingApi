using AcademicPublishingAssignment.DTOs;
using AcademicPublishingAssignment.Repositories;

namespace AcademicPublishingAssignment.Services
{
    public class JournalService : IJournalService
    {
        private readonly IDataRepository _dataRepository;

        public JournalService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<IEnumerable<ResearchArticleDto>> GetArticlesByJournalIdAsync(int journalId)
        {
            var articles = await _dataRepository.GetArticlesByJournalIdAsync(journalId);

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

        public async Task<JournalDto?> GetJournalByIdAsync(int journalId)
        {
            var journal = await _dataRepository.GetJournalByJournalIdAsync(journalId);

            if (journal == null)
                return null;

            return new JournalDto
            {
                Id = journal.Id,
                Name = journal.Name,
                ISSN = journal.ISSN,
                Publisher = journal.Publisher,
                Description = journal.Description
            };
        }

        public async Task<IEnumerable<JournalDto>> GetAllJournalsAsync()
        {
            var journals = await _dataRepository.GetAllJournalsAsync();

            return journals.Select(journal => new JournalDto
            {
                Id = journal.Id,
                Name = journal.Name,
                ISSN = journal.ISSN,
                Publisher = journal.Publisher,
                Description = journal.Description
            });
        }
    }
}
