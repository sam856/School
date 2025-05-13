using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Emails.Query.Model;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Emails.Query.Validator
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public ConfirmEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.userId).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Email Must not be Null");

            RuleFor(x => x.code).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);



        }
        #endregion
    }
}
