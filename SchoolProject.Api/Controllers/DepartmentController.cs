using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Bases;
using SchoolProject.Core.Feature.Department.Queries.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{

    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentApi.GetById)]

        public async Task<IActionResult> GetDepartmentById([FromQuery] GetDepartmentById Query)
        {
            var response = await Mediator.Send(Query)

            ;
            return Ok(response);
        }



        [HttpGet(Router.DepartmentApi.GetDepartmentByStudentCount)]

        public async Task<IActionResult> GetDepartmentByStudentCount()
        {
            var response = await Mediator.Send(new GetDepartmentbyStudentCount());

            ;
            return Ok(response);
        }

        [HttpGet(Router.DepartmentApi.GetDepartmentByStudentCountproc)]

        public async Task<IActionResult> GetDepartmentByStudentCountproc([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDepartmentStudentCountProcsQuery { DID = id });

            ;
            return Ok(response);
        }
    }
}
