namespace ConferenceRegistrationApi.Adapters;

// Typed Client.
public class MarkupServiceAdapter
{
    // Any requests to that service, this is the adapter for.
    private readonly HttpClient _httpClient;

    public MarkupServiceAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetPricingResponse> GetPricingResponseAsync()
    {
        var response = await _httpClient.GetAsync("/markup");
        response.EnsureSuccessStatusCode(); // more about this in a minute

        var getPricingResponse = await response.Content.ReadFromJsonAsync<GetPricingResponse>();

        return getPricingResponse!;
    }

}


public class GetPricingResponse
{
    public decimal amountOfMarkup { get; set; }
    public DateTime adjustedAt { get; set; }
}