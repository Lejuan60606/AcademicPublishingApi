namespace AcademicPublishingAssignment.DTOs
{
    public class ResearchArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Author { get; set; } = default!;
        public DateTime PublicationDate { get; set; }
        public string DOI { get; set; } = default!;
        public JournalDto Journal { get; set; } = null!;
        public List<AuthorDto> Authors { get; set; } = new();
    }
}
