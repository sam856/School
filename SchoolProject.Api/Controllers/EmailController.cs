using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Feature.Emails.Command.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : AppControllerBase
    {

        [HttpPost(Router.Email.Send)]
        public async Task<IActionResult> Create([FromForm] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

    }
}
