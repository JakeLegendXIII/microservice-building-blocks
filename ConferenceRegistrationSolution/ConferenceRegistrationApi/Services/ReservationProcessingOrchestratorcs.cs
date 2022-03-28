namespace ConferenceRegistrationApi.Services;

// Kind of an Anti-Pattern
public class ReservationProcessingOrchestratorcs : IProcessReservations
{
    public Task<ConferenceConfirmation> ProcessReservationAsync(ConferenceRegistration request)
    {
        // "Transaction List"
        // - I have the id, but is that a real conference? has it already happend? is it full?
        // - is this a real user? Are they allowed to attend conferences, all that jazz... and WHAT IS THEIR NAME AND EMAIL ADDRESS?
        // - If the above two are true, charge their credit card.
        // - if that worked, then register them for the conference.
        // - what else? Send a confirmation email? blah blah blah blah


        throw new NotImplementedException();
    }
}
