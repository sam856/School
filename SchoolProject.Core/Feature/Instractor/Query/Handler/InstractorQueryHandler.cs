using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Instractor.Query.Model;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Instractor.Query.Handler
{
    public class InstractorQueryHandler : ResponseHandler, IRequestHandler<GetInstractorSalaryQuery, Response<decimal>>
    {
        #region Field
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private IInstractorServices instractorServices;
        #endregion
        #region Constractor
        public InstractorQueryHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, IInstractorServices instractorServices) : base(localizer)
        {
            _localizer = localizer;
            _mapper = mapper;
            this.instractorServices = instractorServices;
        }


        #endregion

        #region Handle Function
        public async Task<Response<decimal>> Handle(GetInstractorSalaryQuery request, CancellationToken cancellationToken)
        {
            var result = await instractorServices.GetInstractorSalary();
            return Success(result);
        }
        #endregion
    }
}
