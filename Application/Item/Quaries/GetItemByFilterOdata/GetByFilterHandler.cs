using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using MediatR;


namespace Application.Item.Quaries.GetItemByFilterOdata;

public class GetByFilterHandler : IRequestHandler<GetByFilterRequest, List<ItemDTO>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetByFilterHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ItemDTO>> Handle(GetByFilterRequest request, CancellationToken cancellationToken)
    {
        var items = _context.Items.ToList();
        return _mapper.Map<List<ItemDTO>>(items);
    }
}