using NanoBus.MessageContracts;

namespace NanoBus.Tests.Events.Multicast
{
    public class TestMultiCastEvent : IBusEvent
    {
        public bool WasHandled { get; set; }
        public bool SecondHandlerWasCalled { get; set; }
    }
}