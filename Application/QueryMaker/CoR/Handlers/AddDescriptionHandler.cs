using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddDescriptionHandler : AbstractHandler
{

    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Description != null)
        {
            base.QueryMaker.AddFilter(f => f.Description == request.Description);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }


    public AddDescriptionHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}