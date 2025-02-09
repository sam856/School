namespace SchoolProject.Core.Results
{
    public class GetUserByIdDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }

    }
}
