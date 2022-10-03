using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table();
    T? Get(int id);
    IQueryable<T> GetByFilter(Expression<Func<T, bool>> expression);
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);
    void Update(T entity);
    
    Task SaveChangesAsync(CancellationToken cancellationToken);

    void Save();
}
