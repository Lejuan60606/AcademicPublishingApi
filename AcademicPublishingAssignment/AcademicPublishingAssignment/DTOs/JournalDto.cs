namespace AcademicPublishingAssignment.DTOs
{
    public class JournalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string ISSN { get; set; } = default!;
        public string Publisher { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
