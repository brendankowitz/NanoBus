namespace NanoBus
{
    public static class Mediator
    {
        private static IBus Instance { get; set; }

        public static void SetInstance(IBus bus)
        {
            Instance = bus;
        }

        public static void Send<TCommand>(TCommand busCommand) where TCommand : IBusCommand
        {
            Instance.Send(busCommand).Wait();
        }

        public static void Publish<TBusEvent>(TBusEvent busEvent) where TBusEvent : IBusEvent
        {
            Instance.Publish(busEvent).Wait();
        }

        public static TResponse Request<TRequest, TResponse>(TRequest busRequest)
            where TRequest : IBusRequest<TRequest, TResponse>
            where TResponse : IBusResponse
        {
            var response = Instance.Request(busRequest);
            response.Wait();
            return response.Result;
        }
    }
}