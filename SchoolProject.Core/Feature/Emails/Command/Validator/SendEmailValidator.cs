using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Emails.Command.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Emails.Command.Validator
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public SendEmailValidator(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Email Must not be Null");

            RuleFor(x => x.Message).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);



        }
        #endregion
    }
}

