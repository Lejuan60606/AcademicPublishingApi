namespace AcademicPublishingAssignment.Models
{
    public class ArticleAuthor
    {
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
        public int AuthorOrder { get; set; }
        public ResearchArticle Article { get; set; } = null!;
        public Author Author { get; set; } = null!;
    }
}
