namespace AcademicPublishingAssignment.DTOs
{
    public class ResearchArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublicationDate { get; set; }
        public string JournalName { get; set; } = null!;
        public List<string> Authors { get; set; } = new();
    }
}
