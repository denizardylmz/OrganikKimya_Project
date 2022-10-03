using Application.Interfaces;
using Domain.Entities;

namespace Application.QueryMaker;

public interface QueryMaker<T> where T: BaseEntity
{

    public void AddFilter(Func<T, bool> filter);

    public IQueryable<T> ReturnQuery();
}