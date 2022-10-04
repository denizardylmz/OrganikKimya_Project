using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddVendorHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Vendor != null)
        {
            foreach (var data in request.Vendor)
            {
                base.QueryMaker.AddFilter(f => f.Vendor == data);    
            }
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }

    public AddVendorHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}