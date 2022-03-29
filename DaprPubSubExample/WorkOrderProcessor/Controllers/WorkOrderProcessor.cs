using Dapr;
using Microsoft.AspNetCore.Mvc;


namespace WorkOrderProcessor.Controllers;

public class WorkOrderProcessor : ControllerBase
{
    private ILogger<WorkOrderProcessor> _logger;

    public WorkOrderProcessor(ILogger<WorkOrderProcessor> logger)
    {
        _logger = logger;
    }

    [HttpPost("processor")]
    [Topic("work-items-pub-sub", "work-items")]
    public async Task<IActionResult> Post([FromBody] WorkOrder workOrder)
    {
        // Do all the work of processing the order....
        _logger.LogInformation($"Working on Work Order {workOrder.job}");
        foreach (var step in workOrder.steps)
        {
            _logger.LogInformation($"\tOn Step {step}");
        }
        return Ok();
    }
}



public record WorkOrder(string job, List<string> steps);