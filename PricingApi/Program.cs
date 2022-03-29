using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IProvideMarkupInformation, MarkupInformation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGet("/markup", ([FromServices] IProvideMarkupInformation markup) => {
    var amount = markup.GetMarkupAmount();
    var response = new GetMarkupResponse(amount, DateTime.Now);
    return response;
});

app.Run();


public record GetMarkupResponse(decimal amountOfMarkup, DateTime adjustedAt);

public interface IProvideMarkupInformation
{
    decimal GetMarkupAmount();
}

// Return the markup amount

public class MarkupInformation : IProvideMarkupInformation
{
    public decimal GetMarkupAmount()
    {
        var amountLhs = new Random().Next(0, 1);
        var amountRhs = new Random().Next(0, 99);

        var amount = decimal.Parse(amountLhs.ToString() + "." + amountRhs.ToString());
        return amount;
    }
}