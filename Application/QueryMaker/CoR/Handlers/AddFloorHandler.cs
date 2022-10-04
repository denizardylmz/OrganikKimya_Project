using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddFloorHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Floor != null)
        {
            foreach (var data in request.Floor)
            {
                base.QueryMaker.AddFilter(f => f.Floor == data);    
            }
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