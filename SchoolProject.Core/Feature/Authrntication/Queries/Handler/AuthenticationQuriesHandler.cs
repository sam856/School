using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authrntication.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Authrntication.Queries.Handler
{
    public class AuthenticationQuriesHandler : ResponseHandler,
        IRequestHandler<AuroizeQuery, Response<string>>
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
        #endregion
    }
}


