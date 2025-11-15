using AutoMapper;
using FluentAssertions;
using Microsoft.Extensions.Localization;
using Moq;
using SchoolProject.Core.Feature.Stduent.Commands.Handler;
using SchoolProject.Core.Feature.Stduent.Commands.Models;
using SchoolProject.Core.Mapping.Student;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entites;
using SchoolProject.Services.Abstract;
using System.Net;

namespace Test.School.CoreTest.Commands
{
    public class StudentCommandTest
    {
        private Mock<IStudentServies> _studentServices;
        private IMapper mapper;
        private Mock<IStringLocalizer<SharedResources>> _Locaizer;
        private StudentProfile studentProfile;
        public StudentCommandTest()
        {
            studentProfile = new();
            _studentServices = new();
            _Locaizer = new();
            var configration = new MapperConfiguration(c => c.AddProfile(studentProfile));
            mapper = new Mapper(configration);

        }

        [Fact]
        public async Task Add_Student_Status()
        {
            var handler = new StudentCommandHandler(_studentServices.Object, mapper, _Locaizer.Object);
            var AddStudent = new AddStudentCommand() { NameAr = "Menna", NameEn = "منه محمد" };

            _studentServices.Setup(x => x.AddStudent(It.IsAny<Student>())).Returns(Task.FromResult("Success"));
            var result = await handler.Handle(AddStudent, default);
            result.StatusCode.Should().Be(HttpStatusCode.Created);
            result.Succeeded.Should().BeTrue();
            _studentServices.Verify(x => x.AddStudent(It.IsAny<Student>()), Times.Once, "Not Called");
        }


        [Fact]
        public async Task Edit_student_Async()
        {
            var handler = new StudentCommandHandler(_studentServices.Object, mapper, _Locaizer.Object);
            var AddStudent = new EditStudentCommand() { NameAr = "Menna", NameEn = "منه محمد" };
            var studnet = new Student();
            _studentServices.Setup(x => x.GetStudentByIDWithIncludeAsync(It.IsAny<int>())).Returns(Task.FromResult(studnet));
            var result = await handler.Handle(AddStudent, default);
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
            result.Succeeded.Should().BeTrue();
            _studentServices.Verify(x => x.GetStudentByIDWithIncludeAsync(It.IsAny<int>()), Times.Once, "Not Called");
        }
    }
}
