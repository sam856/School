using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Infrastruture.Abstract;
using SchoolProject.Infrastruture.Context;
using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Repositiries
{
    public class RefreshTokenRepositiry : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepositiry
    {
        #region Fields
        private DbSet<UserRefreshToken> refreshTokens;
        #endregion

        #region Costractor
        public RefreshTokenRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            refreshTokens = dbContext.Set<UserRefreshToken>();
        }
        #endregion
        #region Handle Function

        #endregion
    }
}
