using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Authorazion.Command.Models;
using SchoolProject.Core.Feature.Authorazion.Queries.Modling;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AuthroziationController : AppControllerBase
    {

        [HttpPost(Router.Authorize.Create)]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }


        [HttpPut(Router.Authorize.Edit)]
        public async Task<IActionResult> Update([FromForm] EditRoleCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.Authorize.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var response = await Mediator.Send(new DeleteRoleCommand(Id));
            return NewResult(response);
        }
        [HttpGet(Router.Authorize.AllRoles)]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetRolesListCommand());
            return NewResult(response);
        }

        [HttpGet(Router.Authorize.GetById)]
        public async Task<IActionResult> GetAll([FromRoute] int Id)
        {
            var response = await Mediator.Send(new GetRoleByIdCommand(Id));
            return NewResult(response);
        }

        [HttpGet(Router.Authorize.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromRoute] int Id)
        {
            var response = await Mediator.Send(new ManageUserQuery(Id));
            return NewResult(response);
        }
    }
}
