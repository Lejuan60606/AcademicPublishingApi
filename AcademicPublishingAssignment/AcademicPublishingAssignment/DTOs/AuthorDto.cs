namespace AcademicPublishingAssignment.DTOs
{
    public class AuthorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Affiliation { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public int AuthorOrder { get; set; }
    }
}
