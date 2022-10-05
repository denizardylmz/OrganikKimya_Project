using Application.Common;
using Application.Interfaces;

namespace Application.Item.CreateItem;

public class CreateItemCommandResponse : IResponse<Domain.Entities.Item>
{
    public string Message { get; set; }
    public ResponseType ResponseType { get; set; }
    public Domain.Entities.Item? Data { get; set; }
    
    public List<CustomValidationError>? ValidationErrors { get; set; }
}