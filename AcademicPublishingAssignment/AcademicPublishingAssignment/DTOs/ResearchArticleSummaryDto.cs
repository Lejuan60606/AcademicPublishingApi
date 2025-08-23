namespace AcademicPublishingAssignment.DTOs
{
    public class ResearchArticleSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public DateTime PublicationDate { get; set; }
        public string DOI { get; set; } = default!;
        public string JournalName { get; set; } = default!;
        public List<string> AuthorNames { get; set; } = default!;
    }
}
