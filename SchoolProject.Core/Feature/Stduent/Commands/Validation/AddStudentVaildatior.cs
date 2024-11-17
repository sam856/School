using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Stduent.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Stduent.Commands.Validation
{
    public class AddStudentVaildatior : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentServies studentServies;
        private readonly IStringLocalizer<SharedResources> localizer;
        #endregion

        #region Constractor

        public AddStudentVaildatior(IStudentServies studentServies, IStringLocalizer<SharedResources> localizer)
        {
            this.studentServies = studentServies;
            this.localizer = localizer;
            ApplyValidationRules();


            CustomeValidation();
        }
        #endregion


        #region Action

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Null")
                .MaximumLength(10).WithMessage("Max Length is 10");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage("Name Must not be Null")
              .MaximumLength(10).WithMessage("Max Length is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address Must not be Empty")
               .NotNull().WithMessage("Adress Must not be Null")
               .MaximumLength(20).WithMessage("Max Length is 20");


        }



        public void CustomeValidation()
        {
            RuleFor(x => x.NameAr).MustAsync(async (Key, CancellationToken) => !await studentServies.NameIsExist(Key))
               .WithMessage("Name is Exist");

            RuleFor(x => x.NameEn).MustAsync(async (Key, CancellationToken) => !await studentServies.NameIsExist(Key))
              .WithMessage("Name is Exist");

        }
        #endregion
    }
}
