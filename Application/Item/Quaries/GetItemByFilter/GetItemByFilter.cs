using System.Linq.Expressions;
using Application.Interfaces;
using Application.QueryMaker;
using Application.QueryMaker.CoR;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Item.Quaries.GetItemByFilter;

public class GetItemByFilterRequest : IRequest<ItemsVm>
{

    public string? SerialNumber { get; set; }
    public string? Description { get; set; }
    public string? StockGroupNumber { get; set; }
    
    public DateTime? PurchaseStartDate { get; set; }
    public DateTime? PurchaseEndDate { get; set; }
    
    public DateTime? WarrantyStartDate { get; set; }
    public DateTime? WarrantyEndDate { get; set; }
    
    public string? Floor { get; set; }
    public string? Room { get; set; }
    
    public string? Model { get; set; }
    public string? Brand { get; set; }
    
    public string? Vendor { get; set; }
    
}

public class ItemsVm
{
    public bool isSucceed { get; set; }
    public List<Domain.Entities.Item> Items { get; set; }
} 


public class GetByFilterQueryHandler : IRequestHandler<GetItemByFilterRequest, ItemsVm>
{

    private readonly IApplicationDbContext _context;

    public GetByFilterQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ItemsVm> Handle(GetItemByFilterRequest request, CancellationToken cancellationToken)
    {

        var queryMaker = new ConcreteQueryMaker(_context);

        var resQuery = CoRMaker.Make(queryMaker, request); 
        

        var result = resQuery.ToList();
        return new ItemsVm()
        {
            isSucceed = true && result.Count > 0,
            Items = result
        };
    }
}