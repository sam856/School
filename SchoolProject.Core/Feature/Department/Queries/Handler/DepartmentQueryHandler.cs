using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Department.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Results;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;
using System.Linq.Expressions;

namespace SchoolProject.Core.Feature.Department.Queries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentById, Response<GetDepartmentDto>>

    {


        #region Fields
        private readonly IStringLocalizer<SharedResources> stringLocalizer;
        private readonly IDepartmentServies departmentServies;
        private readonly IMapper _mapper;
        private readonly IStudentServies studentServies;

        #endregion 

        #region Constractor
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentServies departmentServies, IMapper _mapper, IStudentServies studentServies) : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.departmentServies = departmentServies;
            this._mapper = _mapper;
            this.studentServies = studentServies;
        }
        #endregion
        #region Handel Functions


        public async Task<Response<GetDepartmentDto>> Handle(GetDepartmentById request, CancellationToken cancellationToken)
        {

            var department = await departmentServies.GetDepartmentById(request.Id);
            if (department == null)
            {
                return NotFound<GetDepartmentDto>(stringLocalizer[SharedResourcesKeys.NotFound]);
            }

            var mapper = _mapper.Map<GetDepartmentDto>(department);


            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Localize(e.NameAr, e.NameEn));
            var studenListQuery = studentServies.GetStudentByDepartment(request.Id);

            var PaganationList = await studenListQuery
           .Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = PaganationList;
            return Success(mapper);


        }

        #endregion
    }

}
