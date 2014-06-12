using NUnit.Framework;

namespace NanoBus.Tests.Events.Multicast
{
    [TestFixture]
    public class EventTests
    {
        [Test]
        public void GivenAnEventIsCreated_WhenItIsPublished_ThenTheHandlersAreCalled()
        {
            var e = new TestMultiCastEvent();

            Mediator.Publish(e);
            
            Assert.IsTrue(e.WasHandled);
            Assert.IsTrue(e.SecondHandlerWasCalled);
        }
    }
}