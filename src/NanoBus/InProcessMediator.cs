using Autofac;

namespace NanoBus
{
    public class InProcessMediator : InProcessResolvedMediator
    {
        public InProcessMediator(ILifetimeScope lifetimeScope) : base(() => lifetimeScope)
        {
        }
    }
}