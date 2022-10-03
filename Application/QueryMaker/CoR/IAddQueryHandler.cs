using Application.Item.Quaries.GetItemByFilter;

namespace Application.QueryMaker.CoR;

public interface IAddQueryHandler
{
    IAddQueryHandler SetNext(IAddQueryHandler handler);
    
    public void Handle(GetItemByFilterRequest request);
}

public class AbstractHandler : IAddQueryHandler
{
    public QueryMaker<Domain.Entities.Item> QueryMaker { get; set; }

    private IAddQueryHandler _nextHandler;

    public AbstractHandler(QueryMaker<Domain.Entities.Item> queryMaker)
    {
        QueryMaker = queryMaker;
    }

    public IAddQueryHandler SetNext(IAddQueryHandler handler)
    {
        this._nextHandler = handler;
        return handler;
    }

    public virtual void Handle(GetItemByFilterRequest request)
    {
        if (this._nextHandler != null)
        {
            this._nextHandler.Handle(request);
        }
    }
}



