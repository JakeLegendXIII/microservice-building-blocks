namespace ConferenceRegistrationApi.Adapters;

public class MarkupServiceAmountPort
{
    private readonly MarkupServiceAdapter _adapter;

    public MarkupServiceAmountPort(MarkupServiceAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<decimal> GetMarkupAmountAsync()
    {
        // Have a plan b
        var response = await _adapter.GetPricingResponseAsync();

        return response.amountOfMarkup;
    }
}
