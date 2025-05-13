namespace SchoolProject.Services.Dtos
{
    public class ManageUserCliamsDto
    {
        public int UserId { get; set; }
        public List<UserCliams> userCliam { get; set; }

    }
    public class UserCliams
    {
        public string Type { get; set; }
        public bool Value { get; set; }

    }
}
