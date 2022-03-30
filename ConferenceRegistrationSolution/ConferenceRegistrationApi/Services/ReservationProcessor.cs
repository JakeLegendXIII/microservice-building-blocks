using ConferenceRegistrationApi.Adapters.DaprStuff;

namespace ConferenceRegistrationApi.Services;

public class ReservationProcessor : IProcessReservations
{
    private readonly DaprReservationAdapter _reservationAdapter;

    public ReservationProcessor(DaprReservationAdapter reservationAdapter)
    {
        _reservationAdapter = reservationAdapter;
    }

    public async Task ProcessReservationAsync(ConferenceRegistrationRequestMessage message)
    {
        // Todo: All the crap jeff doesn't do in class. Validating stuff beyond what you can do in the controller, error handling (if the adapter throws an exception, this is a good place to figure out what that means, etc. 

        await _reservationAdapter.PublishReservationRequestAsync(message);
    }
}