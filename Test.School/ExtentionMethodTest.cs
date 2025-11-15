using EntityFrameworkCore.Testing.Common;
using FluentAssertions;
using Moq;
using SchoolProject.Core.Wapper;
using SchoolProject.Data.Entites;
using Test.School.Wrapper;

namespace Test.School
{
    public class ExtentionMethodTest
    {
        public Mock<IPaginatedServices<Student>> moq;
        public ExtentionMethodTest()
        {
            moq = new Mock<IPaginatedServices<Student>>();
        }

        [Fact]
        public async Task Exte()
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
            var result = new PaginatedResult<Student>(studetList.ToList());

            moq.Setup(x => x.ReturnPaginatedResult(studetList, 1, 10)).Returns(Task.FromResult(result));
            var E = await moq.Object.ReturnPaginatedResult(studetList, 1, 10);
            E.Data.Should().NotBeNull();


        }

    }
}
