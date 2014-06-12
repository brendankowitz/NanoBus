using System.Threading.Tasks;

namespace NanoBus
{
    public interface IHandleRequest<TBusRequest, TBusResponse> where TBusRequest : IBusRequest<TBusRequest, TBusResponse>
                                                               where TBusResponse : IBusResponse
    {
        Task<TBusResponse> Handle(TBusRequest request);
    }
}