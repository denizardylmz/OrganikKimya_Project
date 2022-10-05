using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Item.Query.GetItems;

public class GetAllItemsRequest : IRequest<GetAllItemsResponse>
{
    
}

public class GetAllItemsResponse
{
    public bool IsSuccessful { get; set; }
    public List<ItemDTO> Items { get; set; }
}



public class GetAllItemQueryHandler : IRequestHandler<GetAllItemsRequest, GetAllItemsResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetAllItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetAllItemsResponse> Handle(GetAllItemsRequest request, CancellationToken cancellationToken)
    {
        var items = _context.Items.ToList();
        
        return new GetAllItemsResponse
        {
            IsSuccessful = true ? items != null : false,
            Items = _mapper.Map<List<ItemDTO>>(items)
        };
    }
}