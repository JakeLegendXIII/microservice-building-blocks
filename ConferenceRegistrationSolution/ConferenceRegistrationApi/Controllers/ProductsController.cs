namespace ConferenceRegistrationApi.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsDomainService;

    public ProductsController(IProductsService productsDomainService)
    {
        _productsDomainService = productsDomainService;
    }

    [HttpGet("products/{id:int}")]
    public async Task<ActionResult> GetProduct(int id)
    {
        ProductInformationResponse response = await _productsDomainService.GetProductAsync(id);
        
        if (response == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }
}
