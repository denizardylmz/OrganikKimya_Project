using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddStockGroupNumberHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.StockGroupNumber != null)
        {
            foreach (var data in request.StockGroupNumber)
            {
                base.QueryMaker.AddFilter(f => f.StockGroupNumber == data);    
            }
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