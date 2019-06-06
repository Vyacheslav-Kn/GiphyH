namespace GiphyH.DAL.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
    {
        TResult Find(TQuery query);
    }
}
