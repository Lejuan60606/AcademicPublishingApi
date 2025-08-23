using AcademicPublishingAssignment.Models;
using AcademicPublishingAssignment.Repositories;
using AcademicPublishingAssignment.Services;
using Moq;

namespace AcademicPublishingAssignmentTests
{
    [TestFixture]
    public class Tests
    {
        private Mock<IDataRepository> _mockRepository;
        private ResearchArticleService _service;
        private List<ResearchArticle> _testArticles;
        private List<Author> _testAuthors;
        private List<Journal> _testJournals;
        private List<ArticleAuthor> _testArticleAuthors;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IDataRepository>();
            _service = new ResearchArticleService(_mockRepository.Object);
            SetupTestData();
        }


        private void SetupTestData()
        {
            _testAuthors = new List<Author>
            {
                new Author { Id = 1, FirstName = "John", LastName = "Chen", Affiliation = "MIT", Email = "john.chen@mit.edu" },
                new Author { Id = 2, FirstName = "Emily", LastName = "Smith", Affiliation = "Stanford University", Email = "Emily.Smith@stanford.edu" },
            };

            _testJournals = new List<Journal>
            {
                new Journal { Id = 1, Name = "Nature", ISSN = "0028-0836", Publisher = "Nature Publishing Group" }
            };

            _testArticleAuthors = new List<ArticleAuthor>
            {
                new ArticleAuthor { ArticleId = 1, AuthorId = 1, AuthorOrder = 1, Author = _testAuthors[0] },
                new ArticleAuthor { ArticleId = 1, AuthorId = 2, AuthorOrder = 2, Author = _testAuthors[1] }
            };

            _testArticles = new List<ResearchArticle>
            {
                new ResearchArticle
                {
                    Id = 1,
                    Title = "Test Article",
                    Abstract = "Test abstract",
                    PublicationDate = new DateTime(2023, 1, 1),
                    JournalId = 1,
                    Journal = _testJournals[0],
                    ArticleAuthors = _testArticleAuthors
                }
            };

            _testArticleAuthors[0].Article = _testArticles[0];
            _testArticleAuthors[1].Article = _testArticles[0];
        }

        [Test]
        public async Task GetArticleByIdAsync_WithValidId_ShouldReturnMappedDto()
        {
            const int articleId = 1;
            _mockRepository.Setup(r => r.GetArticleByArticleIdAsync(articleId))
                          .ReturnsAsync(_testArticles[0]);

  
            var result = await _service.GetArticleByArticleIdIdAsync(articleId);

            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(articleId));
            Assert.That(result.Title, Is.EqualTo("Test Article"));
            Assert.IsNotNull(result.Journal);
            Assert.That(result.Journal.Name, Is.EqualTo("Nature"));
            Assert.That(result.Authors, Has.Count.EqualTo(2));
            Assert.True(result.Authors.Any(a => a.FullName == "John Chen"));
            Assert.True(result.Authors.Any(a => a.FullName == "Emily Smith"));
        }
    }
}