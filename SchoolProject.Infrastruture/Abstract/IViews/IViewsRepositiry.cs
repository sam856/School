using SchoolProject.Infrastruture.InfrastrutureBases;

namespace SchoolProject.Infrastruture.Abstract.IViews
{
    public interface IViewsRepositiry<T> : IGenericRepositoryAsync<T> where T : class
    {
    }
}
