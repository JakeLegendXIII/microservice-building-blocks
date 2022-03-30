using Dapr.Client;

namespace ConferenceRegistrationApi.Adapters.DaprStuff;

public class DaprReservationAdapter
{
    private readonly DaprClient _daprClient;

    public DaprReservationAdapter(DaprClient daprClient)
    {
        // TODO: this is a good place to do another one of those IOptions<> things like we did for Mongo.

        _daprClient = daprClient;
    }

    public async Task PublishReservationRequestAsync(ConferenceRegistrationRequestMessage registration)
    {
        // "reservations" is the pub/sub service that we will configure.
        // "reservations-request" is the topic we are publishing to.
        await _daprClient.PublishEventAsync("reservations", "reservation-requests", registration);
    }
}
