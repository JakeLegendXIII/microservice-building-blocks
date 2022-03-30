using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace ReservationProcessor.Controllers
{
    public class ReservationProcessorController: ControllerBase
    {
        private readonly ILogger<ReservationProcessorController> _logger;
        private readonly DaprClient _daprClient;

        public ReservationProcessorController(ILogger<ReservationProcessorController> logger, DaprClient daprClient)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        [HttpPost("reservation-request")]
        [Topic("reservations", "reservation-requests")]
        public async Task<ActionResult> ProcessReservation([FromBody] ConferenceReservation request)
        {
            _logger.LogInformation(request.ToString());
            // ?? 
            if (request.conference.name == "Jeff")
            {
                await _daprClient.PublishEventAsync("reservations", "denied-reservations", request);                
            }
            else
            {
                await _daprClient.PublishEventAsync("reservations", "approved-reservations", request);
            }
            return Ok(); // Profit!
        }
    }
}

public record Conference(string id, string name);
public record ConferenceReservation(Conference conference, string subject, string id);