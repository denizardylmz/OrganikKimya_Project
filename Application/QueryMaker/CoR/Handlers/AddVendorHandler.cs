using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddVendorHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Vendor != null)
        {
            base.QueryMaker.AddFilter(f => f.Vendor == request.Vendor);
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