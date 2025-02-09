using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authrntication.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Data.Helper;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Authrntication.Command.Handler
{
    public class AuthenticationCommandsHandler : ResponseHandler,
        IRequestHandler<SigInCommand, Response<JWTAuthResult>>,
       IRequestHandler<RefreshTokenCommand, Response<JWTAuthResult>>



    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IAuthenticationServices authenticationServices;



        #endregion

        #region Constractor
        public AuthenticationCommandsHandler(IStringLocalizer<SharedResources> localizer,

             UserManager<User> userManager,
             IAuthenticationServices authenticationServices,
             SignInManager<User> signInManager
            ) : base(localizer)

        {
            this.localizer = localizer;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.authenticationServices = authenticationServices;
        }


        #endregion

        #region Handler Function
        public async Task<Response<JWTAuthResult>> Handle(SigInCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return NotFound<JWTAuthResult>(localizer[SharedResourcesKeys.NotFound]);

            }
            var result = await signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
            {
                return NotFound<JWTAuthResult>(localizer[SharedResourcesKeys.PasswordNotCorrect]);

            }

            var JwtResult = await authenticationServices.GetJWTToken(user);
            return Success(JwtResult);

        }

        public async Task<Response<JWTAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtToken = authenticationServices.ReadJwtToken(request.AccessToken);
            var validated = await authenticationServices.ValidationDetails(jwtToken, request.AccessToken, request.RefreshToken);
            switch (validated)
            {
                case ("Invalid Token", null): return Unauthorized<JWTAuthResult>(localizer[SharedResourcesKeys.AlgorithmIsWrong]);
                case (" Token not expire ", null): return Unauthorized<JWTAuthResult>(localizer[SharedResourcesKeys.TokenIsNotExpired]);
                case ("Refresh Token is Not Valid", null): return Unauthorized<JWTAuthResult>(localizer[SharedResourcesKeys.RefreshTokenIsNotFound]);
                case ("Refresh Token is Expire", null): return Unauthorized<JWTAuthResult>(localizer[SharedResourcesKeys.RefreshTokenIsExpired]);
            }
            var (userId, expiredate) = validated;
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound<JWTAuthResult>();
            var result = await authenticationServices.GetRefreshToken(jwtToken, user, expiredate, request.AccessToken, request.RefreshToken);
            return Success(result);
        }
        #endregion
    }
}
