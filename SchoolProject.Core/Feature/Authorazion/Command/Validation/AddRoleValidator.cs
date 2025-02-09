using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Authorazion.Command.Validation
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;
        private readonly IAuthorizationServices authorizationServices;

        #endregion

        #region Constractor
        public AddRoleValidator(IStringLocalizer<SharedResources> localizer,
            IAuthorizationServices authorizationServices)
        {
            this.localizer = localizer;
            this.authorizationServices = authorizationServices;
            ApplyValidationRules();
            CustomeValidation();



        }
        #endregion

        #region Handle Function
        public void ApplyValidationRules()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Null")
                .MaximumLength(10).WithMessage("Max Length is 10");




        }



        public void CustomeValidation()
        {
            RuleFor(x => x.RoleName).MustAsync(async (Key, CancellationToken) => !await authorizationServices.IsRoleExsist(Key))
              .WithMessage("Role Name is Exist");





        }
        #endregion
    }
}
