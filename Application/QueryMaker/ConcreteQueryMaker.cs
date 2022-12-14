using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.QueryMaker;

//This classes are not used in the project,
//They'd writted while developing the project and I forgot to delete them. I will delete them in the next commit.

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
    
    public void AddFilter(Func<Domain.Entities.Item, bool> filter, bool isOr)
    {
        if (isOr)
        {
            Queryable = Queryable.AsEnumerable().Where(filter).AsQueryable();
        }
        else
        {
            Queryable = Queryable.AsEnumerable().Where(filter).AsQueryable();
        }
    }

    public IQueryable<Domain.Entities.Item> ReturnQuery()
    {
        return Queryable;
    }
}