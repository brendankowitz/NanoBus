using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Features.OwnedInstances;

namespace NanoBus
{
    public class InProcessMediator : IBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public InProcessMediator(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public Task Send<TBusCommand>(TBusCommand busCommand) where TBusCommand : IBusCommand
        {
            using (var handler = _lifetimeScope.Resolve<Owned<IHandleCommand<TBusCommand>>>())
            {
                return handler.Value.Handle(busCommand);
            }
        }

        public Task<TResponse> Request<TRequest, TResponse>(IBusRequest<TRequest, TResponse> busRequest)
            where TRequest : IBusRequest<TRequest, TResponse> 
            where TResponse : IBusResponse
        {
            using (var handler = _lifetimeScope.Resolve<Owned<IHandleRequest<TRequest, TResponse>>>())
            {
                return handler.Value.Handle((TRequest)busRequest);
            }
        }

        public Task Publish<TBusEvent>(TBusEvent busEvent) where TBusEvent : IBusEvent
        {
            return Task.Factory.StartNew(() =>
            {
                using (var handlers = _lifetimeScope.Resolve<Owned<IEnumerable<IHandleMulticastEvent<TBusEvent>>>>())
                {
                    var tasks = handlers.Value
                        .Select(h => h.Handle(busEvent))
                        .ToArray();

                    if (tasks.Any() == false)
                        throw new BusException(string.Format("No event handlers are registered for '{0}'", typeof(TBusEvent).Name));

                    Task.WaitAll(tasks);
                }
            });
        }
    }
}