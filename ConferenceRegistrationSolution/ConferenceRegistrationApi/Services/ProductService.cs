namespace ConferenceRegistrationApi.Services;

public class ProductService : IProductsService
{
    private readonly MarkupServiceAmountPort _amountPort;

    public ProductService(MarkupServiceAmountPort amountPort)
    {
        _amountPort = amountPort;
    }

    public async Task<ProductInformationResponse> GetProductAsync(int id)
    {
        // this may need many different port/adapters. Some of information may come from a database, etc.
        var markup = await _amountPort.GetMarkupAmountAsync();

        // all the code to get the real product, etc.
        // Cook The Turkey here, do the actual work.

        return new ProductInformationResponse(id, "Cheese", 7.99M * (1 + markup));
    }
}
