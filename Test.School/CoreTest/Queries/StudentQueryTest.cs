using AutoMapper;
using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Microsoft.Extensions.Localization;

using Moq;
using SchoolProject.Core.Feature.Stduent.Queries.Handler;
using SchoolProject.Core.Feature.Stduent.Queries.Models;
using SchoolProject.Core.Mapping.Student;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Data.Helper;
using SchoolProject.Services.Abstract;
using System.Net;
using Test.School.Models;

namespace Test.School.CoreTest.Queries
{
    public class StudentQueryTest
    {
        private Mock<IStudentServies> _studentServices;
        private IMapper mapper;
        private Mock<IStringLocalizer<SharedResources>> _Locaizer;
        private StudentProfile studentProfile;
        public StudentQueryTest()
        {
            studentProfile = new();
            _studentServices = new();
            _Locaizer = new();
            var configration = new MapperConfiguration(c => c.AddProfile(studentProfile));
            mapper = new Mapper(configration);

        }
        [Fact]
        public async Task Student_Get()
        {

            var studetList = new List<Student>
            {

                new Student() {StudID = 1 , Address="Flex" , NameEn = "Menna",NameAr="منه"}
            };
            var query = new GetStudentListQuery();
            _studentServices.Setup(x => x.GetStudentsAsync()).Returns(Task.FromResult(studetList));
            var handler = new GetStudentHandler(_studentServices.Object, mapper, _Locaizer.Object);
            var result = await handler.Handle(query, default);
            result.Data.Should().NotBeNullOrEmpty();
        }



        [Theory]
        [ClassData(typeof(PassDataUsingClassData))]
        [MemberData(nameof(PassDataUsingMemerData.GetParam), MemberType = typeof(PassDataUsingMemerData))]
        public async Task Student_GeByIdt(int id)
        {
            var department = new Department()
            {
                DID = 1,
                DNameAr = "هندسه برمجيات",
                DNameEN = "SWE"
            };

            var studetList = new List<Student>
            {

                new Student() {StudID = 1 , Address="Flex" , NameEn = "Menna",NameAr="منه" ,DID=1  ,Department =department } ,
               new Student() {StudID = 2 , Address="Cairo" , NameEn = "Nada",NameAr="ندا" ,DID=1  ,Department =department }

            };
            var query = new GetStudentByIdQuery(id);
            _studentServices.Setup(x => x.GetStudentByIDWithIncludeAsync(id)).Returns(Task.FromResult(studetList.FirstOrDefault(x => x.StudID == id)));
            var handler = new GetStudentHandler(_studentServices.Object, mapper, _Locaizer.Object);
            var result = await handler.Handle(query, default);
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }




        [Fact]
        public async Task Student_GetPaginated()
        {
            var department = new Department()
            {
                DID = 1,
                DNameAr = "هندسه برمجيات",
                DNameEN = "SWE"
            };

            var studetList = new AsyncEnumerable<Student>(new List<Student>
            {

                new Student() {StudID = 1 , Address="Flex" , NameEn = "Menna",NameAr="منه" ,DID=1  ,Department =department }
            });
            var query = new GetStudentPagnationQuery()
            {
                OrderBy = OrderingStudentEnum.StudID,
                Search = "منه",
                PageNumber = 1,
                PageSize = 1

            };
            _studentServices.Setup(x => x.FilterStudentIqurable(query.OrderBy, query.Search)).Returns(studetList.AsQueryable());
            var handler = new GetStudentHandler(_studentServices.Object, mapper, _Locaizer.Object);
            var result = await handler.Handle(query, default);
            result.Data.Should().NotBeNullOrEmpty();
        }


    }
}
