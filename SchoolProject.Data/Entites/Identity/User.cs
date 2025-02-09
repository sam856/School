using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolProject.Data.Entites.Identity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            RefreshTokens = new HashSet<UserRefreshToken>();
        }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string FullName { get; set; }

        [InverseProperty("User")]
        public ICollection<UserRefreshToken> RefreshTokens { get; set; }
    }
}
