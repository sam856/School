using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Users.Commands.Models;
using SchoolProject.Core.Feature.Users.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    public class ApplicationUserController : AppControllerBase
    {

        [HttpPost(Router.ApplicationUser.Create)]

        public async Task<IActionResult> AddStudent([FromBody] AddUserCommand studentCommand)
        {
            var response = await Mediator.Send(studentCommand);
            return NewResult(response);
        }

        [HttpGet(Router.ApplicationUser.Pagnation)]

        public async Task<IActionResult> GetStudentPagnationsList([FromQuery] GetUsersQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.ApplicationUser.GetById)]

        public async Task<IActionResult> GetUserByIdApi([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetUserById(Id));


            return Ok(response);
        }


        [HttpPut(Router.ApplicationUser.Edit)]

        public async Task<IActionResult> EditUser([FromBody] EditUsersCommand userCommand)
        {
            var response = await Mediator.Send(userCommand

            );
            return NewResult(response);
        }



        [HttpDelete(Router.ApplicationUser.Delete)]

        public async Task<IActionResult> DeleteUser([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteUserCommand(Id)

            );
            return NewResult(response);
        }


        [HttpPut(Router.ApplicationUser.ChangePassword)]

        public async Task<IActionResult> ChangeUserPassword([FromBody] ChangeUserPasswordCommand userCommand)
        {
            var response = await Mediator.Send(userCommand

            );
            return NewResult(response);
        }

    }
}
