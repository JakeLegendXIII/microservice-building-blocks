namespace ConferenceRegistrationApi;

public interface IProcessReservations
{
    Task<ConferenceConfirmation> ProcessReservationAsync(ConferenceRegistration request);
}