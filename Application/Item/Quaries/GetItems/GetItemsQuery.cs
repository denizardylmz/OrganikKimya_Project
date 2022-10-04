using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Item.Query.GetItems;

public class GetItemsRequest : IRequest<GetItemsResponse>
{
    
}

public class GetItemsResponse
{
    public bool IsSuccessful { get; set; }
    public List<ItemDTO> Items { get; set; }
}



public class GetItemQueryHandler : IRequestHandler<GetItemsRequest, GetItemsResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetItemsResponse> Handle(GetItemsRequest request, CancellationToken cancellationToken)
    {
        var items = _context.Items.ToList();
        
        return new GetItemsResponse
        {
            IsSuccessful = true ? items != null : false,
            Items = _mapper.Map<List<ItemDTO>>(items)
        };
    }
}