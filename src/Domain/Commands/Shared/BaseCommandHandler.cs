using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Template.Webapi.Netcore.Domain.Helpers;
using Template.Webapi.Netcore.Domain.Interfaces.Extensions;

namespace Template.Webapi.Netcore.Domain.Commands.Shared;

public abstract class BaseCommandHandler<THandler, TCommand>
    where THandler : class
    where TCommand : BaseCommand
{
    protected readonly ILogger Logger;
    public IValidatorExtension<TCommand> ValidatorExtension;

    public BaseCommandHandler(
        ILoggerFactory logger,
        IValidatorExtension<TCommand> validatorExtension)
    {
        Logger = logger.CreateLogger<THandler>();
        ValidatorExtension = validatorExtension;
    }

    public async Task<BaseCommandResponse> SafeExecuteAsync(Func<Task<BaseCommandResponse>> function, TCommand command)
    {
        try
        {
            Logger.InformationOperationLog($"{typeof(THandler).Name}", command.CorrelationId, $"Received command  {JsonConvert.SerializeObject(command)}");

            if (!await ValidatorExtension.Isvalid(command))
                return new BaseCommandResponse(command.CorrelationId, 400, ValidatorExtension.GetErrors());

            return await function();
        }
        catch (InvalidOperationException ex)
        {
            var error = $"Error: {typeof(THandler).Name} {ex.Message} [{ex}]";

            Logger.ErrorOperationLog($"{typeof(THandler).Name}", command.CorrelationId, $"{error}");

            return new BaseCommandResponse(command.CorrelationId, 500, error);
        }
        catch (Exception ex)
        {
            var error = $"Error: {nameof(THandler)} | {ex.Message} [{ex}]";

            Logger.ErrorOperationLog($"{typeof(THandler).Name}", command.CorrelationId, $"{error}");

            return new BaseCommandResponse(command.CorrelationId, 500, error);
        }
    }
}

