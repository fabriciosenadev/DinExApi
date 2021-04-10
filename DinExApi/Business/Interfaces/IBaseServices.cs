namespace DinExApi.Business.Interfaces
{
    public interface IBaseServices<T> where T : class
    {
        bool Validate(T entity);
    }
}
