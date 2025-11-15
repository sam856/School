using FluentAssertions;
using Moq;
using Test.School.Models;
using Test.School.MoqServices;

namespace Test.School
{
    public class CarTestMoq
    {
        private readonly Mock<List<Car>> _mockCarServices = new();
        [Fact]
        public void AddCar()
        {
            var Car = new Car
            {

                Id = 1,
                Name = "Toy",

                Color = "Red"
            };

            var CarServices = new CarMoqServices(_mockCarServices.Object);
            var AddResult = CarServices.Add(Car);
            var GetAllResult = CarServices.GetAll();

            AddResult.Should().BeTrue();
            GetAllResult.Should().NotBeNullOrEmpty();

            Assert.Single(GetAllResult);

        }



        public void RemoveCar()
        {
            var Car = new Car
            {

                Id = 2,
                Name = "Toy",

                Color = "Red"
            };
            var CarServices = new CarMoqServices(_mockCarServices.Object);

            var AddResult = CarServices.Add(Car);
            var GetAllResult = CarServices.GetAll();

            AddResult.Should().BeTrue();
            GetAllResult.Should().NotBeNullOrEmpty().And.HaveCount(2);
            var remove = CarServices.Remove(2);

            remove.Should().BeTrue();
        }

    }
}
