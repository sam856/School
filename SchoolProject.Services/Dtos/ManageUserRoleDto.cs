namespace SchoolProject.Service
{
    public class ManageUserRoleDto
    {
        public int UserId { get; set; }
        public List<UserRoles> UserRole { get; set; }

    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }

    }
}
