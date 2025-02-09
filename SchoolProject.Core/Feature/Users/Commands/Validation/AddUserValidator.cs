using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Users.Commands.Validation
{
    public class AddUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public AddUserValidator(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Null");

            RuleFor(x => x.UserName).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Email).NotEmpty().WithMessage("Address Must not be Empty")
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.Password).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage("Password Must not be Null");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
           .NotNull().WithMessage("Password Must not be Null")
           .Equal(x => x.Password).WithMessage(localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);


        }
        #endregion
    }
}
