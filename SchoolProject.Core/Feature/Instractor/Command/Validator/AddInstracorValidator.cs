using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Feature.Instractor.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Instractor.Command.Validator
{
    public class AddInstracorValidator : AbstractValidator<AddInstractorCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> localizer;
        private readonly IDepartmentServies departmentServies;
        private readonly IInstractorServices instractorServices;

        #endregion

        #region Constractor

        public AddInstracorValidator(IStringLocalizer<SharedResources> localizer, IDepartmentServies departmentServies, IInstractorServices instractorServices)
        {
            this.localizer = localizer;
            this.departmentServies = departmentServies;
            this.instractorServices = instractorServices;
            ApplyValidationRules();


            CustomeValidation();
        }
        #endregion


        #region Action

        public void ApplyValidationRules()
        {
            RuleFor(x => x.ENameAr).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must not be Null")
                .MaximumLength(10).WithMessage("Max Length is 10");

            RuleFor(x => x.ENameEn).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage("Name Must not be Null")
              .MaximumLength(10).WithMessage("Max Length is 10");


            RuleFor(x => x.DID).NotEmpty().WithMessage(localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage("Department Must not be Null");


        }



        public void CustomeValidation()
        {
            RuleFor(x => x.ENameEn).MustAsync(async (Key, CancellationToken) => !await instractorServices.NameIsExist(Key))
               .WithMessage("Name is Exist");

            RuleFor(x => x.ENameAr).MustAsync(async (Key, CancellationToken) => !await instractorServices.NameIsExist(Key))
              .WithMessage("Name is Exist");



            RuleFor(x => x.DID).MustAsync(async (Key, CancellationToken) => await departmentServies.DepartmentIsExist(Key))
         .WithMessage(localizer[SharedResourcesKeys.IsNotExist]);




        }
        #endregion
    }
}
