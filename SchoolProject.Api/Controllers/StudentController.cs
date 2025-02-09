using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Stduent.Commands.Models;
using SchoolProject.Core.Feature.Stduent.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{

    [ApiController]
    [Authorize]

    public class StudentController : AppControllerBase
    {



        [HttpGet(Router.StudentApi.List)]

        public async Task<IActionResult> GetStudentsList()
        {
            var response = await Mediator.Send(new GetStudentListQuery());
            return NewResult(response);
        }
        [AllowAnonymous]
        [HttpGet(Router.StudentApi.Pagnation)]

        public async Task<IActionResult> GetStudentPagnationsList([FromQuery] GetStudentPagnationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }


        [HttpGet(Router.StudentApi.GetById)]

        public async Task<IActionResult> GetStudentById([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetStudentByIdQuery(Id)

            );
            return NewResult(response);
        }



        [HttpPost(Router.StudentApi.Create)]

        public async Task<IActionResult> AddStudent([FromBody] AddStudentCommand studentCommand)
        {
            var response = await Mediator.Send(studentCommand

            );
            return NewResult(response);
        }



        [HttpPut(Router.StudentApi.Edit)]

        public async Task<IActionResult> EditStudent([FromBody] EditStudentCommand studentCommand)
        {
            var response = await Mediator.Send(studentCommand

            );
            return NewResult(response);
        }

        [HttpDelete(Router.StudentApi.Delete)]

        public async Task<IActionResult> DeleteStudent([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteStudentCommand(Id)

            );
            return NewResult(response);
        }



    }
}
