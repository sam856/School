using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authorazion.Queries.Modling;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.Dtos;

namespace SchoolProject.Core.Feature.Authorazion.Queries.Handler
{
    public class CliamsQueryHamdler : ResponseHandler, IRequestHandler<ManageUserCliamQuery, Response<ManageUserCliamsDto>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;
        private readonly IAuthorizationServices _authorizationService;
        private readonly UserManager<User> _userManager;



        #endregion

        #region Constractor
        public CliamsQueryHamdler(IStringLocalizer<SharedResources> localizer,

            IAuthorizationServices _authorizationService
            , UserManager<User> userManager) : base(localizer)
        {
            this.localizer = localizer;
            this._authorizationService = _authorizationService;
            _userManager = userManager;

        }


        #endregion

        #region Handle Function
        public async Task<Response<ManageUserCliamsDto>> Handle(ManageUserCliamQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<ManageUserCliamsDto>(localizer[SharedResourcesKeys.UserIsNotFound]);
            var result = await _authorizationService.ManageUserCliamsData(user);
            return Success(result);
        }
        #endregion
    }
}
