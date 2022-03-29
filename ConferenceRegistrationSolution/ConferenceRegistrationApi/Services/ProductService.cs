using ConferenceRegistrationApi.Adapters.Mongo;

namespace ConferenceRegistrationApi.Services;

public class ProductService : IProductsService
{
    private readonly MarkupServiceAmountPort _amountPort;
    private readonly MongoProductsAdapter _mongoAdapter;

    public ProductService(MarkupServiceAmountPort amountPort, MongoProductsAdapter mongoAdapter)
    {
        _amountPort = amountPort;
        _mongoAdapter = mongoAdapter;
    }

    public async Task<GetProductsResponse> GetAllProductsAsync()
    {
        var products = await _mongoAdapter.GetAllAsync();
        var markup = await _amountPort.GetMarkupAmountAsync();

        var productsConverted = products.Select(p => new ProductInformationResponse(p.Id, p.Name, p.Cost * (1 + markup))).ToList();

        return new GetProductsResponse(productsConverted);
    }

    public async Task<ProductInformationResponse> GetProductAsync(string id)
    {
        // this may need many different port/adapters. Some of information may come from a database, etc.
        var markup = await _amountPort.GetMarkupAmountAsync();
        var item = await _mongoAdapter.GetProductById(id);

        if (item is null)
        {
            return null;
        }
        else
        {
            return new ProductInformationResponse(item.Id, item.Name, item.Cost * (1 + markup));
        }
    }
}
