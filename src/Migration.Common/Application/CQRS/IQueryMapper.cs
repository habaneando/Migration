namespace Migration.Common;

public interface IQueryMapper<TRequest, TQuery>
{
    TQuery ToQuery(TRequest request);
}
