
using Grpc.Core;
using ReservationsApi;

namespace ConferenceRegistrationApi.GrpcPorts;

public class ReservationRequestsGrpcService : ReservationsApi.ReservationRequests.ReservationRequestsBase
{
    private readonly IProcessReservations _processor;
    private readonly ILogger _logger;

    public ReservationRequestsGrpcService(IProcessReservations processor, ILogger logger)
    {
        _processor = processor;
        _logger = logger;
    }

    public override async Task<SomeMessage> RequestReservation(SomeMessage request, ServerCallContext context)
    {
        var conference = new ConferenceInfo(request.Conference.Id, request.Conference.Name);
        var message = new ConferenceRegistrationRequestMessage(conference, "888.888.888", Guid.NewGuid().ToString(), RegistrationStatus.Pending);
        await _processor.ProcessReservationAsync(message);
        _logger.LogInformation(message.ToString());

        return request;
    }
}
