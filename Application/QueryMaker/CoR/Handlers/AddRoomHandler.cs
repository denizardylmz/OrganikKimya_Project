using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddRoomHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Room != null)
        {
            base.QueryMaker.AddFilter(f => f.Room == request.Room);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }

    public AddRoomHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}