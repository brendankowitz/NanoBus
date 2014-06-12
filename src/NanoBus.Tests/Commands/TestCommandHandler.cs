using System.Threading.Tasks;
using NanoBus.Handlers;

namespace NanoBus.Tests.Commands
{
    public class TestCommandHandler : IHandleCommand<TestCommand>
    {
        public Task Handle(TestCommand busCommand)
        {
            busCommand.WasHandled = true;
            return Task.Factory.StartNew(() => true);
        }
    }
}