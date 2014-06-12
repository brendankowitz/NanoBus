using NanoBus.MessageContracts;

namespace NanoBus.Tests.Commands
{
    public class TestCommand : IBusCommand
    {
        public bool WasHandled { get; set; }
    }
}