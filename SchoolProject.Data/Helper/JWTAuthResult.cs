namespace SchoolProject.Data.Helper
{
    public class JWTAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken refreshtoken { get; set; }

    }
    public class RefreshToken
    {
        public string UserName { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }

    }
}
