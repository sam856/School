using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authrntication.Queries.Models;
using SchoolProject.Core.Feature.Emails.Query.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Authrntication.Queries.Handler
{
    public class AuthenticationQuriesHandler : ResponseHandler,
        IRequestHandler<AuroizeQuery, Response<string>>,
               IRequestHandler<ConfirmEmailQuery, Response<string>>,
         IRequestHandler<ConfirmResetPasswordQuery, Response<string>>

    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;
        private readonly IAuthenticationServices authenticationServices;
        #endregion

        #region Constractor
        public AuthenticationQuriesHandler(IStringLocalizer<SharedResources> localizer,
                         IAuthenticationServices authenticationServices


              ) : base(localizer)

        {
            this.localizer = localizer;
            this.authenticationServices = authenticationServices;
        }

        #endregion

        #region Handel Function
        public async Task<Response<string>> Handle(AuroizeQuery request, CancellationToken cancellationToken)
        {
            var result = authenticationServices.ValidateToken(request.AccessToken);
            if (result == "Success")

                return Success(result);
            else
                return BadRequest<string>("Expire");

        }

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await authenticationServices.CofirmEmail(request.code, request.userId);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>(localizer[SharedResourcesKeys.ErrorWhenConfirmEmail]);
            return Success<string>(localizer[SharedResourcesKeys.ConfirmEmailDone]);
        }

        public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await authenticationServices.ConfirmResetPassword(request.Code, request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>(localizer[SharedResourcesKeys.UserIsNotFound]);
                case "Failed": return BadRequest<string>(localizer[SharedResourcesKeys.InvaildCode]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(localizer[SharedResourcesKeys.InvaildCode]);
            }
        }
        #endregion
    }
}


