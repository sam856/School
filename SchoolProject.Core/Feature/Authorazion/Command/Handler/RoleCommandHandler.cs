using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Authorazion.Command.Handler
{
    public class RoleCommandHandler :
        ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
         IRequestHandler<DeleteRoleCommand, Response<string>>




    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;

        private readonly IAuthorizationServices authorizationServices;
        #endregion

        #region Constractor
        public RoleCommandHandler(IStringLocalizer<SharedResources> localizer,
            IAuthorizationServices authorizationServices
            ) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationServices = authorizationServices;
        }


        #endregion

        #region Handle Function
        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationServices.CreateAsyc(request.RoleName);
            if (result == "Success")
            {
                return Success("");
            }
            return BadRequest<string>(localizer[SharedResourcesKeys.AddFailed]);

        }


        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationServices.EditRole(request);
            if (result == "Success")

                return Success<string>(localizer[SharedResourcesKeys.Updated]);

            else if (result == "NotFound")
                return NotFound<string>();

            return BadRequest<string>(result);

        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationServices.DeleteRole(request.Id);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Used") return BadRequest<string>(localizer[SharedResourcesKeys.RoleIsUsed]);
            else if (result == "Success") return Success((string)localizer[SharedResourcesKeys.Deleted]);
            else
                return BadRequest<string>(result);
        }
        #endregion
    }
}
