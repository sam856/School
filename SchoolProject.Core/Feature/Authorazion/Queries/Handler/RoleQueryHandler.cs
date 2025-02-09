using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Authorazion.Queries.Modling;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Results;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Service;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Authorazion.Queries.Handler
{
    public class RoleQueryHandler : ResponseHandler, IRequestHandler<GetRolesListCommand, Response<List<GetRolesListDto>>>,
        IRequestHandler<GetRoleByIdCommand, Response<GetRoleByIdDto>>,
        IRequestHandler<ManageUserQuery, Response<ManageUserRoleDto>>


    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;

        private readonly IAuthorizationServices authorizationServices;

        private readonly UserManager<User> _userManager;

        private IMapper mapper;
        #endregion
        #region Constractor
        public RoleQueryHandler(IStringLocalizer<SharedResources> localizer, IAuthorizationServices authorizationServices,
            IMapper mapper, UserManager<User> userManager) : base(localizer)
        {
            this.localizer = localizer;
            this.authorizationServices = authorizationServices;
            this.mapper = mapper;
            _userManager = userManager;
        }


        #endregion
        #region Handle Function
        public async Task<Response<List<GetRolesListDto>>> Handle(GetRolesListCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationServices.GetAllRoles();
            var respone = mapper.Map<List<GetRolesListDto>>(result);
            return Success(respone);

        }

        public async Task<Response<GetRoleByIdDto>> Handle(GetRoleByIdCommand request, CancellationToken cancellationToken)
        {
            var result = await authorizationServices.GetRoleById(request.Id);
            if (result == null)
            {
                return NotFound<GetRoleByIdDto>(localizer[SharedResourcesKeys.IsNotExist]);
            }
            var response = mapper.Map<GetRoleByIdDto>(result);
            return Success(response);
        }

        public async Task<Response<ManageUserRoleDto>> Handle(ManageUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userManager.FindByIdAsync(request.Id.ToString());
            if (users == null)
                return NotFound<ManageUserRoleDto>(localizer[SharedResourcesKeys.UserIsNotFound]);

            var result = await authorizationServices.GetManageUserRoleData(users);
            return Success(result);
        }
        #endregion
    }
}
