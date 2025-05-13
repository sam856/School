using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Feature.Emails.Command.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Services.Abstract;

namespace SchoolProject.Core.Feature.Emails.Command.Handler
{
    public class EmailCommandHandler : ResponseHandler,
        IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly IEmailServices emailServices;
        #endregion

        #region Constracor
        public EmailCommandHandler(IStringLocalizer<SharedResources> _sharedResources, IEmailServices emailServices) : base(_sharedResources)
        {
            this._sharedResources = _sharedResources;
            this.emailServices = emailServices;
        }


        #endregion

        #region Handle Function
        public async Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var response = await emailServices.SendEmailAsync(request.Email, request.Message, null);
            if (response == "Success")
                return Success<string>("");
            return BadRequest<string>(_sharedResources[SharedResourcesKeys.SendEmailFailed]);
        }
        #endregion
    }
}
