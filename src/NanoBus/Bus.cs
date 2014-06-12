using System.Threading.Tasks;

namespace NanoBus
{
    public static class Bus
    {
        private static IBus Instance { get; set; }

        public static void SetInstance(IBus bus)
        {
            Instance = bus;
        }

        public static void Send(IBusCommand busCommand)
        {
            Instance.Send(busCommand).Wait();
        }

        public static void Publish(IBusEvent busEvent)
        {
            Instance.Publish(busEvent).Wait();
        }

        public static TResponse Request<TRequest, TResponse>(TRequest busRequest)
            where TRequest : IBusRequest<TRequest, TResponse>
            where TResponse : IBusResponse
        {
            var response = Instance.Request<TRequest, TResponse>(busRequest);
            response.Wait();
            return response.Result;
        }
    }
}