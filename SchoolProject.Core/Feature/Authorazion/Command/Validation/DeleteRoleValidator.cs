using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Resources;

namespace SchoolProject.Core.Feature.Authorazion.Command.Validation
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;

        #endregion

        #region Constractor
        public DeleteRoleValidator(IStringLocalizer<SharedResources> localizer
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
                .NotNull();




        }




        #endregion
    }
}

