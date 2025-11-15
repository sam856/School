using System.Collections;

namespace Test.School.Models
{
    public class PassDataUsingMemerData : IEnumerable<object[]>
    {


        public static IEnumerable<object[]> GetParam()
        {

            return new List<object[]>
            {

            new object[]{1},
            new object[]{2},

            };

        }
        public IEnumerator<object[]> GetEnumerator()
        {
            return (IEnumerator<object[]>)GetParam();


        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
