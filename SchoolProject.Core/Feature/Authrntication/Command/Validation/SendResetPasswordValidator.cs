using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Authrntication.Command.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Authrntication.Command.Validation
{
    internal class SendResetPasswordValidator : AbstractValidator<SendResetPasswordCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public SendResetPasswordValidator(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Null");
            RuleFor(x => x.Password).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
               .NotNull().WithMessage("Password Must not be Null");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
         .NotNull().WithMessage("Name Must not be Null")
                .Equal(x => x.Password).WithMessage(localizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);





        }
        #endregion
    }
}

