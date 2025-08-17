namespace Migration.Common;

public interface ICommandMapper<TRequest, TCommand>
{
    TCommand ToCommand(TRequest request);
}
