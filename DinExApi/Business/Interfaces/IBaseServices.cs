namespace DinExApi.Business.Interfaces
{
    public interface IBaseServices<T> where T : class
    {
        bool Exists(T entity);
        //bool Validate(T entity, int userId);
    }
}
