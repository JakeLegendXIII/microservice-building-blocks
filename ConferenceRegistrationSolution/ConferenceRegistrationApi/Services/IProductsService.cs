namespace ConferenceRegistrationApi.Services;

public interface IProductsService
{
    Task<GetProductsResponse> GetAllProductsAsync();
    Task<ProductInformationResponse> GetProductAsync(string id);
}