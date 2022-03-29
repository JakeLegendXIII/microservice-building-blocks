using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace ProducerApi.Controllers;

public class WorkOrderController : ControllerBase
{
    private readonly DaprClient _daprClient;

    public WorkOrderController(DaprClient daprClient)
    {
        _daprClient = daprClient;
    }

    [HttpPost("work-orders")]
    public async Task<ActionResult> Create([FromBody] WorkOrder workOrder)
    {
        await _daprClient.PublishEventAsync("work-items-pub-sub", "work-items", workOrder);
        // write this to the message queue for someone else to worry about.
        var response = new WorkOrderResponse(workOrder, WorkOrderStatus.Pending);
        return Ok(response);
    }
}

public record WorkOrder(string job, List<string> steps);

public enum WorkOrderStatus { Pending, Approved, Denied}
public record WorkOrderResponse(WorkOrder order, WorkOrderStatus status);