using Application.Interfaces;
using MediatR;

namespace Application.Item.Query.GetItems;

public class GetItemsRequest : IRequest<GetItemsResponse>
{
    
}

public class GetItemsResponse
{
    public bool IsSuccessful { get; set; }
    public List<Domain.Entities.Item> Items { get; set; }
}



public class GetItemQueryHandler : IRequestHandler<GetItemsRequest, GetItemsResponse>
{
    private readonly IApplicationDbContext _context;
    public GetItemQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<GetItemsResponse> Handle(GetItemsRequest request, CancellationToken cancellationToken)
    {
        var items = _context.Items.ToList();
        return new GetItemsResponse
        {
            IsSuccessful = true ? items != null : false,
            Items = items
        };
    }
}