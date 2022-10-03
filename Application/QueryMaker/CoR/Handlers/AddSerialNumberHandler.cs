using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddSerialNumberHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.SerialNumber != null)
        {
            base.QueryMaker.AddFilter(f => f.SerialNumber == request.SerialNumber);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }

    public AddSerialNumberHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}