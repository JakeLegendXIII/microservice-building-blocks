namespace ConferenceRegistrationApi.Models;

public record ProductInformationResponse(string id, string name, decimal price);

public record GetProductsResponse(List<ProductInformationResponse> data);
