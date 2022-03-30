using MongoDB.Bson;

namespace ConferenceRegistrationApi.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsDomainService;

    public ProductsController(IProductsService productsDomainService)
    {
        _productsDomainService = productsDomainService;
    }

    [HttpGet("products/{id:bsonid}")]
    public async Task<ActionResult> GetProduct(string id)
    {
        // I'll write it up and give it to you later.
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



    [HttpGet("products")]
    public async Task<ActionResult> GetAllProductsAsync()
    {
        GetProductsResponse response = await _productsDomainService.GetAllProductsAsync();

        return Ok(response);
    }
}
