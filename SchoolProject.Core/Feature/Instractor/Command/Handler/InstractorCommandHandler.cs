using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Instractor.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Instractor.Command.Handler
{
    public class InstractorCommandHandler : ResponseHandler, IRequestHandler<AddInstractorCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> stringLocalizer;
        private readonly IDepartmentServies departmentServies;
        private readonly IMapper _mapper;
        private readonly IInstractorServices _instractorServices;

        #endregion 

        #region Constractor
        public InstractorCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentServies departmentServies,
            IMapper _mapper, IInstractorServices instractorServices) : base(stringLocalizer)
        {
            this.stringLocalizer = stringLocalizer;
            this.departmentServies = departmentServies;
            this._mapper = _mapper;
            _instractorServices = instractorServices;
        }


        #endregion
        #region Handel Functions

        public async Task<Response<string>> Handle(AddInstractorCommand request, CancellationToken cancellationToken)
        {
            var ins = _mapper.Map<Instructor>(request);
            var result = await _instractorServices.AddInstractor(ins, request.Image);
            switch (result)
            {


                case "CaanotUploadFile": return BadRequest<string>(stringLocalizer[SharedResourcesKeys.FailedToUploadImage]);
                case "NOImage": return BadRequest<string>(stringLocalizer[SharedResourcesKeys.NoImage]);
                case "FailedToAdd": return BadRequest<string>(stringLocalizer[SharedResourcesKeys.AddFailed]);



            }
            return Success("");

        }

        #endregion
    }

}



