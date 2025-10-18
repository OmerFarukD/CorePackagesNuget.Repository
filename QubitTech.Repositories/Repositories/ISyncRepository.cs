using System.Linq.Expressions;
using QubitTech.Repositories.Entities;
using QubitTech.Repositories.Specifications;

namespace QubitTech.Repositories.Repositories;

public interface ISyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
{
    TEntity Add(TEntity entity);
    ICollection<TEntity> AddRange(ICollection<TEntity> entities);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    ICollection<TEntity> DeleteRange(ICollection<TEntity> entities);
    int SaveChanges();
    
    TEntity? GetById(
        TId id, 
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        bool enableTracking = true);
    
    Paginate<TEntity> GetPaginate(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        int index = 0,
        int size = 10,
        bool enableTracking = true);
    
    List<TEntity> GetList(
        Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        bool enableTracking = true);
    
    TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null,
        bool enableTracking = true);
    
    bool Any(
        Expression<Func<TEntity, bool>>? predicate = null,
        bool enableTracking = true);
    
    
    TEntity SoftDelete(TEntity entity);
    ICollection<TEntity> SoftDeleteRange(ICollection<TEntity> entities);
    
    
    
    TEntity Restore(TEntity entity);
    ICollection<TEntity> RestoreRange(ICollection<TEntity> entities);

    TEntity? Get(ISpecification<TEntity> specification);

    List<TEntity> GetList(ISpecification<TEntity> specification);

    int Count(ISpecification<TEntity> specification);

    bool Any(ISpecification<TEntity> specification);
    
    Paginate<TEntity> GetPaginate(
        ISpecification<TEntity> specification,
        int index = 0,
        int size = 10);
}