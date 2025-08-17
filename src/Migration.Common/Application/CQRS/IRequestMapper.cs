namespace Migration.Common;

public interface IRequestMapper<TRequest, TCommand>
{
    TCommand ToCommand(TRequest request);
}
