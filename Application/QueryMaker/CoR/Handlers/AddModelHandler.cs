using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddModelHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Model != null)
        {
            base.QueryMaker.AddFilter(f => f.Model == request.Model);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }


    public AddModelHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}