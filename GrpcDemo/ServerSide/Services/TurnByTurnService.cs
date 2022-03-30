using Grpc.Core;

namespace ServerSide.Services
{
    public class TurnByTurnService : TurnByTurn.TurnByTurnBase
    {
        public override async Task StartGuidance(GuidanceRequest request, IServerStreamWriter<StepResponse> responseStream, ServerCallContext context)
        {
            var steps = new List<StepResponse> {
                new StepResponse { Direction = "Right", Road="Prospect"},
                new StepResponse { Direction = "Left", Road ="Darrow"},
                new StepResponse { Direction ="Left", Road="Bob's House"}
            };

            foreach (var step in steps)
            {
                await Task.Delay(new Random().Next(2000, 8000));
                await responseStream.WriteAsync(step);
            }
        }
    }
}
