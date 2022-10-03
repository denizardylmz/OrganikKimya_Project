using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddFloorHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Floor != null)
        {
            base.QueryMaker.AddFilter(f => f.Floor == request.Floor);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }

    public AddFloorHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}