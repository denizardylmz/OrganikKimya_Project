using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddRoomHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Room != null)
        {
            foreach (var data in request.Room)
            {
                base.QueryMaker.AddFilter(f => f.Room == data);    
            }
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