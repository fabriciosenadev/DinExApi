using DinExApi.Business.Interfaces;

namespace DinExApi.Business.Services
{
    public abstract class BaseServices<T> : IBaseServices<T> where T : class
    {
        public BaseServices()
        {

        }

        public abstract bool Validate(T entity);
    }
}
