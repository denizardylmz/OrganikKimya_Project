using Application.Item.CreateItem;
using FluentValidation;

namespace Application.Item.Commands.Validation;

public class CreateItemValidation : AbstractValidator<CreateItemCommand>
{

    public CreateItemValidation()
    {
        RuleFor(p => p.StockGroupNumber).Matches(@"\d{5}");
        
    }
}