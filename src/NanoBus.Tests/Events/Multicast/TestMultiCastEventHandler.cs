using System.Threading.Tasks;
using NanoBus.Handlers;

namespace NanoBus.Tests.Events.Multicast
{
    public class TestMultiCastEventHandler : IHandleMulticastEvent<TestMultiCastEvent>
    {
        public Task Handle(TestMultiCastEvent busEvent)
        {
            busEvent.WasHandled = true;
            return Task.Factory.StartNew(() => true);
        }
    }
}