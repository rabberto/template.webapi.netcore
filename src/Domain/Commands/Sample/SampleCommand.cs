using Template.Webapi.Netcore.Domain.Commands.Shared;

namespace Template.Webapi.Netcore.Domain.Commands.Sample
{
    public sealed class SampleCommand : BaseCommand
    {
        public SampleCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}