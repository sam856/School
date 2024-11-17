using FluentValidation;
using SchoolProject.Core.Feature.Stduent.Commands.Models;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Stduent.Commands.Validation
{
    public class EditStudentVaildatior : AbstractValidator<EditStudentCommand>
    {
        #region Fields
        private readonly IStudentServies studentServies;
        #endregion

        #region Constractor

        public EditStudentVaildatior(IStudentServies studentServies)
        {
            this.studentServies = studentServies;
            ApplyValidationRules();
            CustomeValidation();
        }
        #endregion


        #region Action

        public void ApplyValidationRules()
        {
            RuleFor(x => x.NameAr).NotEmpty().WithMessage("Name Must not be Empty")
                .NotNull().WithMessage("Name Must not be Null")
                .MaximumLength(10).WithMessage("Max Length is 10");

            RuleFor(x => x.NameEn).NotEmpty().WithMessage("Name Must not be Empty")
              .NotNull().WithMessage("Name Must not be Null")
              .MaximumLength(10).WithMessage("Max Length is 10");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Address Must not be Empty")
               .NotNull().WithMessage("Adress Must not be Null")
               .MaximumLength(20).WithMessage("Max Length is 20");


        }



        public void CustomeValidation()
        {
            RuleFor(x => x.NameAr).MustAsync(async (model, Key, CancellationToken) => !await studentServies.NameIsExistExcludeSelf(Key, model.StudID))
               .WithMessage("Name is Exist");
            RuleFor(x => x.NameEn).MustAsync(async (model, Key, CancellationToken) => !await studentServies.NameIsExistExcludeSelf(Key, model.StudID))
            .WithMessage("Name is Exist");


        }
        #endregion
    }
}

