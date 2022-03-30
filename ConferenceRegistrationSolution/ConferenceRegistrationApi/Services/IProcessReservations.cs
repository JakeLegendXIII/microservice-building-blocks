namespace ConferenceRegistrationApi;

public interface IProcessReservations
{
    Task ProcessReservationAsync(ConferenceRegistrationRequestMessage request);
}