using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    [Authorize]

    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentApi.GetById)]

        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentById Query)
        {
            var response = await Mediator.Send(Query)

            ;
            return Ok(response);
        }
    }
}
