namespace Template.Webapi.Netcore.Domain.Interfaces.Extensions;

public interface IValidatorExtension<TCommand> where TCommand : class
{
    Task<bool> Isvalid(TCommand command);

    List<string> GetErrors();
}