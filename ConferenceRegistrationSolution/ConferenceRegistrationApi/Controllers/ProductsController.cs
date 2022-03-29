using MongoDB.Bson;

namespace ConferenceRegistrationApi.Controllers;

public class ProductsController : ControllerBase
{
    private readonly IProductsService _productsDomainService;

    public ProductsController(IProductsService productsDomainService)
    {
        _productsDomainService = productsDomainService;
    }

    [HttpGet("products/{id}")]
    public async Task<ActionResult> GetProduct(string id)
    {
        // TODO: Add a custom route contraint (so the route above would look like [HttpGet("/products/{id:bsonid}")]
        // I'll write it up and give it to you later.
        if (ObjectId.TryParse(id, out var _))
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
        else
        {
            return NotFound(); // BadRequest() 400
        }
    }



    [HttpGet("products")]
    public async Task<ActionResult> GetAllProductsAsync()
    {
        GetProductsResponse response = await _productsDomainService.GetAllProductsAsync();

        return Ok(response);
    }
}
