using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites.Identity;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Users.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
        IRequestHandler<EditUsersCommand, Response<string>>,
       IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>


    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;
        private readonly IMapper _mapper;
        private readonly UserManager<User> userManager;
        private readonly IUserServices userServices;
        #endregion

        #region Constractor
        public UserCommandHandler(IStringLocalizer<SharedResources> localizer, IMapper _mapper,
            UserManager<User> userManager,
            IHttpContextAccessor httpContextAccessor,
            IUserServices userServices
            ) : base(localizer)
        {
            this.localizer = localizer;
            this._mapper = _mapper;
            this.userManager = userManager;
            this.userServices = userServices;
        }
        #endregion

        #region Handle Function
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {


            var IdentityUser = _mapper.Map<User>(request);
            var result = await userServices.AddUserAsync(IdentityUser, request.Password);

            switch (result)
            {
                case "EmailIsExist": return BadRequest<string>(localizer[SharedResourcesKeys.EmailIsExist]);
                case "UserNameIsExist": return BadRequest<string>(localizer[SharedResourcesKeys.UserNameIsExist]);
                case "ErrorInCreateUser": return BadRequest<string>(localizer[SharedResourcesKeys.FaildToAddUser]);
                case "Failed": return BadRequest<string>(localizer[SharedResourcesKeys.TryToRegisterAgain]);
                case "Success": return Success<string>("");
                default: return BadRequest<string>(result);
            }

        }

        public async Task<Response<string>> Handle(EditUsersCommand request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == request.Id);
            if (user == null)
            {
                return NotFound<string>(localizer[SharedResourcesKeys.NotFound]);
            }

            var result = _mapper.Map(request, user);
            var UpdatedUser = await userManager.UpdateAsync(result);
            if (!UpdatedUser.Succeeded)
                return BadRequest<string>(localizer[SharedResourcesKeys.UpdateFailed]);
            return Success((string)localizer[SharedResourcesKeys.Updated]);
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = userManager.Users.FirstOrDefault(x => x.Id == request.Id);
            if (user == null)
            {
                return NotFound<string>(localizer[SharedResourcesKeys.NotFound]);
            }

            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest<string>(localizer[SharedResourcesKeys.DeletedFailed]);
            return Success((string)localizer[SharedResourcesKeys.Deleted]);


        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(x => x.Id == request.Id);
            if (user == null)
            {
                return NotFound<string>("User not found.");
            }

            if (!await userManager.CheckPasswordAsync(user, request.CurrentPassword))
            {
                return BadRequest<string>("Incorrect password.");
            }

            var result = await userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {

                return BadRequest<string>(string.Join("; ", result.Errors.Select(e => e.Description)));
            }

            return Success("Password changed successfully.");
        }
        #endregion


    }
}