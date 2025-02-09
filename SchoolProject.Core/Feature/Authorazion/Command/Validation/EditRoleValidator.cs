using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Authorazion.Command.Validation
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;

        #endregion

        #region Constractor
        public EditRoleValidator(IStringLocalizer<SharedResources> localizer
            )
        {
            this.localizer = localizer;
            ApplyValidationRules();



        }
        #endregion

        #region Handle Function
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage("Id Must not be Null")
           .WithMessage("Max Length is 10");

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage("Name Must not be Null")
            .MaximumLength(10).WithMessage("Max Length is 10");




        }




        #endregion
    }
}

