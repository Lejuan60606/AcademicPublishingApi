namespace AcademicPublishingAssignment.Models
{
    public class ResearchArticle
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Abstract { get; set; } = default!;
        public DateTime PublicationDate { get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; } = default!;

        public ICollection<ArticleAuthor> ArticleAuthors { get; set; } = new List<ArticleAuthor>();
    }
}
