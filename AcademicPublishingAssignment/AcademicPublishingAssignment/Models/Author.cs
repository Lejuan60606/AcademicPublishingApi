namespace AcademicPublishingAssignment.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Affiliation { get; set; } = default!;

        public string FullName => $"{FirstName} {LastName}";

        public ICollection<ArticleAuthor> ArticleAuthors { get; set; } = new List<ArticleAuthor>();

    }
}
