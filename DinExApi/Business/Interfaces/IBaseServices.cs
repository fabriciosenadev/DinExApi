namespace DinExApi.Business.Interfaces
{
    public interface IBaseServices<T> where T : class
    {
        bool Validate(T entity);
        bool Validate(T entity, int userId);
    }
}
