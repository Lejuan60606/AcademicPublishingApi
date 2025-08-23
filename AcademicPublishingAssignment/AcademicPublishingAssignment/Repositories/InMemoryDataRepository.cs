using AcademicPublishingAssignment.Models;

namespace AcademicPublishingAssignment.Repositories
{
    public class InMemoryDataRepository : IDataRepository
    {
        private readonly List<Author> _authors;
        private readonly List<Journal> _journals;
        private readonly List<ResearchArticle> _articles;
        private readonly List<ArticleAuthor> _articleAuthors;

        public InMemoryDataRepository()
        {
            _authors = InitializeAuthors();
            _journals = InitializeJournals();
            _articles = InitializeArticles();
            _articleAuthors = InitializeArticleAuthors();

            SetupNavigationProperties();
        }

        public Task<IEnumerable<ResearchArticle>> GetAllArticlesAsync()
        {
            return Task.FromResult(_articles.AsEnumerable());
        }

        public Task<ResearchArticle?> GetArticleByArticleIdAsync(int id)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(article);
        }

        public Task<IEnumerable<ResearchArticle>> GetArticlesByAuthorIdAsync(int authorId)
        {
            var articleIds = _articleAuthors
                .Where(aa => aa.AuthorId == authorId)
                .Select(aa => aa.ArticleId);

            var articles = _articles.Where(a => articleIds.Contains(a.Id));
            return Task.FromResult(articles);
        }

        public Task<IEnumerable<ResearchArticle>> GetArticlesByJournalIdAsync(int journalId)
        {
            var articles = _articles.Where(a => a.JournalId == journalId);
            return Task.FromResult(articles);
        }

        public Task<Author?> GetAuthorByAuthorIdAsync(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id);
            return Task.FromResult(author);
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return Task.FromResult(_authors.AsEnumerable());
        }

        public Task<Journal?> GetJournalByJournalIdAsync(int id)
        {
            var journal = _journals.FirstOrDefault(j => j.Id == id);
            return Task.FromResult(journal);
        }

        public Task<IEnumerable<Journal>> GetAllJournalsAsync()
        {
            return Task.FromResult(_journals.AsEnumerable());
        }

        private List<Author> InitializeAuthors()
        {
            return new List<Author>
            {
                new Author { Id = 1, FirstName = "John", LastName = "Chen", Affiliation = "MIT", Email = "john.chen@mit.edu" },
                new Author { Id = 2, FirstName = "Emily", LastName = "Smith", Affiliation = "Stanford University", Email = "Emily.Smith@stanford.edu" },
                new Author { Id = 3, FirstName = "Raj", LastName = "Patel", Affiliation = "Harvard University", Email = "raj.patel@harvard.edu" },
                new Author { Id = 4, FirstName = "Maria", LastName = "Garcia", Affiliation = "UC Berkeley", Email = "maria.garcia@berkeley.edu" },
                new Author { Id = 5, FirstName = "David", LastName = "Lee", Affiliation = "Caltech", Email = "david.lee@caltech.edu" }
            };
        }

        private List<Journal> InitializeJournals()
        {
            return new List<Journal>
            {
                new Journal { Id = 1, Name = "Nature", ISSN = "0028-0836", Publisher = "Nature Publishing Group", Description = "International journal of science" },
                new Journal { Id = 2, Name = "Science", ISSN = "0036-8075", Publisher = "American Association for the Advancement of Science", Description = "Academic journal of the American Association for the Advancement of Science" },
                new Journal { Id = 3, Name = "Cell", ISSN = "0098-5589", Publisher = "Cell Press", Description = "Journal covering molecular and cell biology" }
            };
        }

        private List<ResearchArticle> InitializeArticles()
        {
            return new List<ResearchArticle>
            {
                new ResearchArticle
                {
                    Id = 1,
                    Title = "Machine Learning Applications in Genomics",
                    Abstract = "This paper explores the application of machine learning techniques in genomic analysis...",
                    PublicationDate = new DateTime(2023, 6, 15),
                    JournalId = 1
                },
                new ResearchArticle
                {
                    Id = 2,
                    Title = "Quantum Computing and Cryptography",
                    Abstract = "An in-depth analysis of quantum computing's impact on modern cryptography...",
                    PublicationDate = new DateTime(2023, 8, 22),
                    JournalId = 2
                },
                new ResearchArticle
                {
                    Id = 3,
                    Title = "Software Architecture Patterns in Microservices",
                    Abstract = "This study examines various architectural patterns used in microservices development...",
                    PublicationDate = new DateTime(2023, 9, 10),
                    JournalId = 3
                },
                new ResearchArticle
                {
                    Id = 4,
                    Title = "Climate Change and Biodiversity",
                    Abstract = "Research on the correlation between climate change and biodiversity loss...",
                    PublicationDate = new DateTime(2023, 11, 5),
                    JournalId = 1
                },
                new ResearchArticle
                {
                    Id = 5,
                    Title = "Neural Networks in Computer Vision",
                    Abstract = "Advanced neural network architectures for computer vision applications...",
                    PublicationDate = new DateTime(2024, 1, 18),
                    JournalId = 2
                }
            };
        }

        private List<ArticleAuthor> InitializeArticleAuthors()
        {
            return new List<ArticleAuthor>
            {
                // Article 1 authors
                new ArticleAuthor { ArticleId = 1, AuthorId = 1, AuthorOrder = 1 },
                new ArticleAuthor { ArticleId = 1, AuthorId = 2, AuthorOrder = 2 },
                
                // Article 2 authors
                new ArticleAuthor { ArticleId = 2, AuthorId = 3, AuthorOrder = 1 },
                new ArticleAuthor { ArticleId = 2, AuthorId = 4, AuthorOrder = 2 },
                
                // Article 3 authors
                new ArticleAuthor { ArticleId = 3, AuthorId = 2, AuthorOrder = 1 },
                new ArticleAuthor { ArticleId = 3, AuthorId = 5, AuthorOrder = 2 },
                
                // Article 4 authors
                new ArticleAuthor { ArticleId = 4, AuthorId = 1, AuthorOrder = 1 },
                new ArticleAuthor { ArticleId = 4, AuthorId = 3, AuthorOrder = 2 },
                new ArticleAuthor { ArticleId = 4, AuthorId = 4, AuthorOrder = 3 },
                
                // Article 5 authors
                new ArticleAuthor { ArticleId = 5, AuthorId = 2, AuthorOrder = 1 },
                new ArticleAuthor { ArticleId = 5, AuthorId = 5, AuthorOrder = 2 }
            };
        }

        private void SetupNavigationProperties()
        {
            // Set up article-journal relationships
            foreach (var article in _articles)
            {
                article.Journal = _journals.First(j => j.Id == article.JournalId);
            }

            // Set up journal-articles relationships
            foreach (var journal in _journals)
            {
                journal.Articles = _articles.Where(a => a.JournalId == journal.Id).ToList();
            }

            // Set up article-author relationships
            foreach (var articleAuthor in _articleAuthors)
            {
                articleAuthor.Article = _articles.First(a => a.Id == articleAuthor.ArticleId);
                articleAuthor.Author = _authors.First(a => a.Id == articleAuthor.AuthorId);
            }

            // Set up navigation collections
            foreach (var article in _articles)
            {
                article.ArticleAuthors = _articleAuthors.Where(aa => aa.ArticleId == article.Id).ToList();
            }

            foreach (var author in _authors)
            {
                author.ArticleAuthors = _articleAuthors.Where(aa => aa.AuthorId == author.Id).ToList();
            }
        }
    }
}
