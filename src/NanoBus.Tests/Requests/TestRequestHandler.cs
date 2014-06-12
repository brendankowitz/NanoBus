using System.Threading.Tasks;
using NanoBus.Handlers;

namespace NanoBus.Tests.Requests
{
    public class TestRequestHandler : IHandleRequest<TestRequest,TestResponse>
    {
        public Task<TestResponse> Handle(TestRequest request)
        {
            return Task.Factory.StartNew(() => new TestResponse());
        }
    }
}