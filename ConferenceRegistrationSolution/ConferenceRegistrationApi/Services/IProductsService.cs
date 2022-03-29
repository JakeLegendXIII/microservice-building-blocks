namespace ConferenceRegistrationApi.Services;

public interface IProductsService
{
    Task<ProductInformationResponse> GetProductAsync(int id);
}