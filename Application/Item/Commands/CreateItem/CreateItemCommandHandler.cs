using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Item.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
{
    private readonly  IApplicationDbContext _context;

    public CreateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Item()
        {
            SerialNumber = request.SerialNumber,
            Description = request.Description,
            StockGroupNumber = request.StockGroupNumber,
            PurchaseDate = request.PurchaseDate,
            WarrantyDate = request.WarrantyDate,
            Room = request.Room,
            Floor = request.Floor,
            Model = request.Model,
            Brand = request.Brand,
            Vendor = request.Vendor
        };

        _context.Items.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}