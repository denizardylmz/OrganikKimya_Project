using Application.DTOs;
using AutoMapper;

namespace Application.Mappings;

public class ItemProfile : Profile
{
    public ItemProfile()
    {
        CreateMap<Domain.Entities.Item, ItemDTO>().ReverseMap();
    }
    
}