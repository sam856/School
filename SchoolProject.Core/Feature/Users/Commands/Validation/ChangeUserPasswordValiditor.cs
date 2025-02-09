using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Users.Commands.Validation
{
    public class ChangeUserPasswordValiditor : AbstractValidator<ChangeUserPasswordCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public ChangeUserPasswordValiditor(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Id Must not be Null");

            RuleFor(x => x.CurrentPassword).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NewPassword).NotEmpty().WithMessage("New Password Must not be Empty")
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("This Feild Must not be Empty")
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required])
              .Equal(x => x.NewPassword).WithMessage(localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);




        }
        #endregion
    }
}
