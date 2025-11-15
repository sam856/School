using Test.School.Models;

namespace Test.School.MoqServices
{
    public interface IMoqCarServices
    {
        public bool Add(Car car);
        public bool Remove(int? Id);
        public List<Car> GetAll();
    }
}
