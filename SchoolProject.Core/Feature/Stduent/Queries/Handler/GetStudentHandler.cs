using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Stduent.Queries.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Results;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;
using System.Linq.Expressions;

namespace SchoolProject.Core.Feature.Stduent.Queries.Handler
{
    public class GetStudentHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Response<List<GetStudentDto>>>
        , IRequestHandler<GetStudentByIdQuery, Response<GetStudentDto>>,
        IRequestHandler<GetStudentPagnationQuery, PaginatedResult<GetStudentPagnationDto>>


    {
        #region Fields
        private readonly IStudentServies StudentServies;
        private readonly IMapper mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region contrator
        public GetStudentHandler(IStudentServies studentServies, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer)
              : base(stringLocalizer)
        {
            StudentServies = studentServies;
            this.mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }

        #endregion

        #region Handle Function
        public async Task<Response<List<GetStudentDto>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {


            var stduentList = await StudentServies.GetStudentsAsync();
            var stduentListMapper = mapper.Map<List<GetStudentDto>>(stduentList);

            var result = Success(stduentListMapper);
            result.Meta = new { Count = stduentListMapper.Count() };
            return result;

        }

        public async Task<Response<GetStudentDto>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await StudentServies.GetStudentByIDWithIncludeAsync(request.Id);
            if (student == null)
                return NotFound<GetStudentDto>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var StById = mapper.Map<GetStudentDto>(student);
            return Success(StById);

        }

        public async Task<PaginatedResult<GetStudentPagnationDto>> Handle(GetStudentPagnationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPagnationDto>> expression = e => new GetStudentPagnationDto(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Localize(e.Department.DNameAr, e.Department.DNameEN));
            var Filter = StudentServies.FilterStudentIqurable(request.OrderBy, request.Search);
            var PaganationList = await Filter.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaganationList.Meta = new { Count = PaganationList.Data.Count() };
            return PaganationList;
        }

        #endregion

    }
}
