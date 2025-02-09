using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Users.Commands.Validation
{
    public class UpdateUserValidator : AbstractValidator<EditUsersCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public UpdateUserValidator(IStringLocalizer<SharedResources> localizer)
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



        }
        #endregion
    }
}



