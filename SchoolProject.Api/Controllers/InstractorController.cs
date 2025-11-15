using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Instractor.Command.Models;
using SchoolProject.Core.Feature.Instractor.Query.Model;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [ApiController]
    public class InstractorController : AppControllerBase
    {
        [HttpGet(Router.Instractor.GetSummary)]
        public async Task<IActionResult> GetSummary()
        {
            var response = await Mediator.Send(new GetInstractorSalaryQuery());
            return NewResult(response);
        }



        [HttpPost(Router.Instractor.AddInstractor)]
        public async Task<IActionResult> AddInstractor([FromForm] AddInstractorCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }

}
