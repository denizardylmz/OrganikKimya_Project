using Application.Interfaces;
using Domain.Entities;

namespace Application.QueryMaker.Decorators;

public class QueryDecorator<T> : QueryMaker<T> where T : BaseEntity
{

    protected readonly QueryMaker<T> queryMaker;

    public QueryDecorator(QueryMaker<T> sourceQueryMaker)
    {
        queryMaker = sourceQueryMaker;
    }
    
    public void AddFilter(Func<T, bool> filter)
    {
        queryMaker.AddFilter(filter);
    }

    public IQueryable<T> ReturnQuery()
    {
        return queryMaker.ReturnQuery();
    }
}