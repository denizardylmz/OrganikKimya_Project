using Application.Common;
using Application.Interfaces;
using Application.Item.Commands.Validation;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Item.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, CreateItemCommandResponse>
{
    private readonly  IApplicationDbContext _context;

    public CreateItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateItemCommandResponse> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        request.PurchaseDate = request.PurchaseDate.Date;

        var entity = new Domain.Entities.Item()
        {
            SerialNumber = request.SerialNumber,
            Description = request.Description,
            StockGroupNumber = request.StockGroupNumber,
            PurchaseDate = request.PurchaseDate,
            Room = request.Room,
            Floor = request.Floor,
            Model = request.Model,
            Brand = request.Brand,
            Vendor = request.Vendor,
            WarrantyDate = request.WarrantyDate ?? request.PurchaseDate.AddYears(2)
        };
        try
        {
            _context.Items.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return new CreateItemCommandResponse()
            {
                Data = entity,
                Message = "Item created successfully",
                ResponseType = ResponseType.Success,
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}