using System.Linq.Expressions;
using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddBrandHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Brand != null)
        {
            
            /**var property = pair.Key;
            var values = pair.Value;
            var parameter = Expression.Parameter(typeof(Domain.Entities.Item), "item");
            var propertyAccess = Expression.MakeMemberAccess(parameter, typeof(Domain.Entities.Item).GetProperty(property));
            var someValue = Expression.Constant(values, typeof(List<string>));
            var containsMethod = typeof(List<string>).GetMethod("Contains", new[] { typeof(string) });
            var containsMethodExp = Expression.Call(someValue, containsMethod, propertyAccess);
            var lambda = Expression.Lambda<Func<Domain.Entities.Item, bool>>(containsMethodExp, parameter);
            query = query.Where(lambda);**/

            foreach (var data in request.Brand)
            {
                
                
                base.QueryMaker.AddFilter(f => f.Brand == data);
            }
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }

    public AddBrandHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}