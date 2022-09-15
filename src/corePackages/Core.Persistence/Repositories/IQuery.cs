namespace Core.Persistence.Repositories;

public interface IQuery<out T>
{
    IQueryable<T> Query();
}