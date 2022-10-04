using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR.Handlers;

public class AddModelHandler : AbstractHandler
{
    public override void Handle(GetItemByFilterRequest request)
    {
        if (request.Model != null)
        {
            foreach (var data in request.Model)  
            {
                base.QueryMaker.AddFilter(f => f.Model == data);    
            }
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