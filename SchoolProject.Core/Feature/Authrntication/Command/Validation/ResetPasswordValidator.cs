using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Authrntication.Command.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Authrntication.Command.Validation
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public ResetPasswordValidator(IStringLocalizer<SharedResources> localizer)
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




        }
        #endregion
    }
}

