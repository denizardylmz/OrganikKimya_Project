using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.QueryMaker;

public class ConcreteQueryMaker : QueryMaker<Domain.Entities.Item>
{
    public IQueryable<Domain.Entities.Item> Queryable { get; set; }

    public ConcreteQueryMaker(IApplicationDbContext context)
    {
        Queryable = context.Items;
    }

    

    public void AddFilter(Func<Domain.Entities.Item, bool> filter)
    {
        Queryable = Queryable.AsEnumerable().Where(filter).AsQueryable();
    }

    public IQueryable<Domain.Entities.Item> ReturnQuery()
    {
        return Queryable;
    }
}
