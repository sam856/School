using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Stduent.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Stduent.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, Response<string>>,
        IRequestHandler<EditStudentCommand, Response<string>>,
        IRequestHandler<DeleteStudentCommand, Response<string>>


    {
        #region Field
        private readonly IStudentServies studentServies;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResources> stringLocalizer;

        #endregion

        #region Constarctor
        public StudentCommandHandler(IStudentServies studentServies, IMapper mapper, IStringLocalizer<SharedResources> _stringLocalizer) : base(_stringLocalizer)
        {
            this.studentServies = studentServies;
            this.mapper = mapper;
            stringLocalizer = _stringLocalizer;
        }
        #endregion

        #region Handle Function

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = mapper.Map<Student>(request);
            var result = await studentServies.AddStudent(student);
            if (result == "Success")
                return Created("");
            else
                return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentServies.GetStudentByIDWithIncludeAsync(request.StudID);
            if (student == null) return NotFound<string>();
            mapper.Map(request, student);  // Map properties from request to the existing entity
            var result = await studentServies.EditAsync(student);
            if (result == "Success")
                return Success((string)stringLocalizer[SharedResourcesKeys.Updated]);
            return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await studentServies.GetStudentByIDWithIncludeAsync(request.Id);
            if (student == null) return NotFound<string>();
            var result = await studentServies.DeleteAsync(student);
            if (result == "Success")
                return Deleted<string>();
            return BadRequest<string>();
        }


        #endregion
    }
}
