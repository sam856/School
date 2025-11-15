using Test.School.Models;

namespace Test.School.MoqServices
{
    public class CarMoqServices : IMoqCarServices
    {
        List<Car> CarsList;
        public CarMoqServices(List<Car> CarsList)
        {
            this.CarsList = CarsList;
        }
        public bool Add(Car car)
        {
            CarsList.Add(car);
            return true;
        }

        public List<Car> GetAll()
        {
            return CarsList;
        }

        public bool Remove(int? Id)
        {
            if (Id == null) return false;
            var car = CarsList.Find(x => x.Id == Id);
            if (car == null) return false;
            return CarsList.Remove(car);
        }
    }
}
