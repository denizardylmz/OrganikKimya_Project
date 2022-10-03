using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddStockGroupNumberHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.StockGroupNumber != null)
        {
            base.QueryMaker.AddFilter(f => f.StockGroupNumber == request.StockGroupNumber);
            base.Handle(request);
        }
        else
        {
            base.Handle(request);

        }
    }

    public AddStockGroupNumberHandler(QueryMaker<Domain.Entities.Item> queryMaker) : base(queryMaker)
    {
    }
}