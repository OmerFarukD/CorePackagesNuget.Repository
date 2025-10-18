using QubitTech.Repositories.Entities;

namespace QubitTech.Repositories.Repositories;

public interface IQuery<T>
{
    IQueryable<T> Query();
}