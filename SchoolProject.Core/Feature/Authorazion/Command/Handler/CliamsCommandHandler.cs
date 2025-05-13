using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;



namespace SchoolProject.Core.Feature.Authorazion.Command.Handler
{
    public class CliamsCommandHandler : ResponseHandler, IRequestHandler<UpdateUserCliamsCommand, Response<string>>
    {
        #region Fields 
        private readonly IStringLocalizer<SharedResources> localizer;

        private readonly IAuthorizationServices authorizationServices;
        #endregion
        #region Constractor
        public CliamsCommandHandler(IStringLocalizer<SharedResources> localizer, IAuthorizationServices authorizationServices) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationServices = authorizationServices;

        }


        #endregion
        #region Handle Function
        public async Task<Response<string>> Handle(UpdateUserCliamsCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationServices.UpdateUserCliams(request);
            switch (result)
            {
                case "UserIsNull": return NotFound<string>(localizer[SharedResourcesKeys.UserIsNotFound]);
                case "FailedToRemoveOldClaims": return BadRequest<string>(localizer[SharedResourcesKeys.FailedToRemoveOldClaims]);
                case "FailedToAddNewClaims": return BadRequest<string>(localizer[SharedResourcesKeys.FailedToAddNewClaims]);
                case "FailedToUpdateClaims": return BadRequest<string>(localizer[SharedResourcesKeys.FailedToUpdateClaims]);
            }
            return Success<string>(localizer[SharedResourcesKeys.Success]);
        }
        #endregion
    }

}
