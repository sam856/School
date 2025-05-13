namespace SchoolProject.Services.Abstract
{
    public interface IEmailServices
    {
        public Task<string> SendEmailAsync(string email, string Message, string? reason);
    }
}
