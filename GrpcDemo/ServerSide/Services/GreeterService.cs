using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ServerSide;

namespace ServerSide.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name,
                CreatedAt = Timestamp.FromDateTime(DateTime.Now.ToUniversalTime())
            });
        }
    }
}