namespace AcademicPublishingAssignment.Models
{
    public class Journal
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Publisher { get; set; } = default!;
        public string ISSN { get; set; } = default!;
        public string Description { get; set; } = default!;
        public ICollection<ResearchArticle> Articles { get; set; } = new List<ResearchArticle>();
    }
}
