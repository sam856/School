using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Authrntication.Command.Models;
using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Feature.Authrntication.Command.Validation
{
    internal class SiginValidatiorCommand : AbstractValidator<SigInCommand>
    {
        #region Field
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor
        public SiginValidatiorCommand(IStringLocalizer<SharedResources> localizer)
        {
            this.localizer = localizer;
            ApplyValidationRules();
        }
        #endregion

        #region Handle function

        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Null");

            RuleFor(x => x.Password).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage(localizer[SharedResourcesKeys.Required]);

          

        }
        #endregion
    }
}

