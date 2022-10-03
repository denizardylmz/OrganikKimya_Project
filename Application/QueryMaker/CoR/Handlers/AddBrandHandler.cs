using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddBrandHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Brand != null)
        {
            base.QueryMaker.AddFilter(f => f.Brand == request.Brand);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);
        }
    }

    public AddBrandHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}