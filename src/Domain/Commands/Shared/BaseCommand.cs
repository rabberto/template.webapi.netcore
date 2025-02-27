using MediatR;

namespace Template.Webapi.Netcore.Domain.Commands.Shared;

public abstract class BaseCommand : IRequest<BaseCommandResponse>
{
    protected BaseCommand()
    {
        CorrelationId = Guid.NewGuid();
    }

    public Guid CorrelationId {get; private set;}
}