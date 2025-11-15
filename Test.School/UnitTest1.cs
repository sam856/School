using FluentAssertions;

namespace Test.School
{
    public class UnitTest1
    {
        [Fact]
        public void Calculate_with5()
        {

            var x = 5;
            var y = 4;
            var z = x + y;
            z.Should().Be(8, "Sum 5 and 6 is 11");


        }
        [Fact]
        public void SringStart()
        {
            string? z = "Welcome";
            z.Should().BeOfType<string>();



        }
    }
}