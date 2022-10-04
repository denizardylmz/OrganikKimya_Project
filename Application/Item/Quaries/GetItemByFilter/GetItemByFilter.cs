using System.Linq.Expressions;
using Application.Interfaces;
using Application.QueryMaker;
using Application.QueryMaker.CoR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Item.Quaries.GetItemByFilter;

public class GetItemByFilterRequest : IRequest<ItemsResponse>
{
    public Dictionary<string, List<string>> Filters { get; set; }


    public List<string>? SerialNumber { get; set; }
    public List<string>? Description { get; set; }
    public List<string>? StockGroupNumber { get; set; }
    
    public DateTime? PurchaseStartDate { get; set; }
    public DateTime? PurchaseEndDate { get; set; }
    
    public DateTime? WarrantyStartDate { get; set; }
    public DateTime? WarrantyEndDate { get; set; }
    
    public List<string>? Floor { get; set; }
    public List<string>? Room { get; set; }
    
    public List<string>? Model { get; set; }
    public List<string>? Brand { get; set; }
    
    public List<string>? Vendor { get; set; }
    
}

public class ItemsResponse
{
    public bool isSucceed { get; set; }
    public List<Domain.Entities.Item> Items { get; set; }
} 


public class GetByFilterQueryHandler : IRequestHandler<GetItemByFilterRequest, ItemsResponse>
{

    private readonly IApplicationDbContext _context;

    public GetByFilterQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ItemsResponse> Handle(GetItemByFilterRequest request, CancellationToken cancellationToken)
    {
        var query = _context.Items.AsQueryable();
        
        foreach (var pair in request.Filters)
        {
            var property = pair.Key;
            var values = pair.Value;
            var parameter = Expression.Parameter(typeof(Domain.Entities.Item), "item");
            var propertyAccess = Expression.MakeMemberAccess(parameter, typeof(Domain.Entities.Item).GetProperty(property));
            var someValue = Expression.Constant(values, typeof(List<string>));
            var containsMethod = typeof(List<string>).GetMethod("Contains", new[] { typeof(string) });
            var containsMethodExp = Expression.Call(someValue, containsMethod, propertyAccess);
            var lambda = Expression.Lambda<Func<Domain.Entities.Item, bool>>(containsMethodExp, parameter);
            query = query.Where(lambda);
            
        }
            
        
        //var queryMaker = new ConcreteQueryMaker(_context);

        //var resQuery = CoRMaker.Make(queryMaker, request); 
        
        //var result = resQuery.ToList();
        
        return new ItemsResponse()
        {
            isSucceed = true,
            Items = query.ToList()
        };
    }
}