namespace ConferenceRegistrationApi.Controllers;

public class ConferenceRegistrationsController : ControllerBase
{
    private readonly IProcessReservations _reservationProcessor;

    public ConferenceRegistrationsController(IProcessReservations reservationProcessor) => _reservationProcessor = reservationProcessor;

    [HttpPost("conference-registrations")]
    public async Task<ActionResult> AddRegistration([FromBody] ConferenceRegistration request)
    {
        // var myInfo = new ConferenceInfo("989", "Jeff");
        // var updatedInfo = myInfo with { name = "Joe" };        
        //var c = new ConferenceRegistration()
        //{
        //    Conference = new ConferenceInfo("99", "Bill")
        //};

        // Validate the thing.
        ConferenceConfirmation response = await _reservationProcessor.ProcessReservationAsync(request);

        return StatusCode(201, response);
    }
}

