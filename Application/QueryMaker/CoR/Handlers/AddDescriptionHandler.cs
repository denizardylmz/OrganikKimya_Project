using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddDescriptionHandler : AbstractHandler
{

    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Description != null)
        {
            foreach (var data in request.Description)
            {
                base.QueryMaker.AddFilter(f => f.Description == data);    
            }
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
