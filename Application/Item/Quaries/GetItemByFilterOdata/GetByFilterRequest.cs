using Application.DTOs;
using MediatR;

namespace Application.Item.Quaries.GetItemByFilterOdata;

public class GetByFilterRequest : IRequest<List<ItemDTO>>
{
    
}