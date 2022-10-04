using Application.Item.Quaries.GetItemByFilter;
using Application.QueryMaker.CoR.Handlers;

namespace Application.QueryMaker.CoR;

public static class CoRMaker
{
    public static IQueryable<Domain.Entities.Item> Make(QueryMaker<Domain.Entities.Item> queryMaker, GetItemByFilterRequest request)
    {
        
        var brand = new AddBrandHandler(queryMaker);
        var next = brand.SetNext(new AddDescriptionHandler(queryMaker));
        next = next.SetNext(new AddFloorHandler(queryMaker));
        next = next.SetNext(new AddModelHandler(queryMaker));
        next = next.SetNext(new AddRoomHandler(queryMaker));
        next = next.SetNext(new AddVendorHandler(queryMaker));
        next = next.SetNext(new AddSerialNumberHandler(queryMaker));
        next = next.SetNext(new AddStockGroupNumberHandler(queryMaker));
        brand.Handle(request);

        return queryMaker.ReturnQuery();
    }
}