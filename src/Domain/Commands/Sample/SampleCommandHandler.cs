namespace Template.Webapi.Netcore.Domain.Commands.Sample
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Template.Webapi.Netcore.Domain.Commands.Shared;
    using Template.Webapi.Netcore.Domain.Interfaces.Extensions;

    public sealed class SampleCommandHandler(ILoggerFactory logger, IValidatorExtension<SampleCommand> validatorExtension)
        : BaseCommandHandler<SampleCommandHandler, SampleCommand>(logger, validatorExtension), IRequestHandler<SampleCommand, BaseCommandResponse>
    {
        public async Task<BaseCommandResponse> Handle(SampleCommand request, CancellationToken cancellationToken)
        {
            return await SafeExecuteAsync(async () =>
            {
                // Do something
                return new BaseCommandResponse(request.CorrelationId, 200, "Success");
                
            }, request);
        }
    }
}