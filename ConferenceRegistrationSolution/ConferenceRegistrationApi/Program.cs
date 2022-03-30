
using ConferenceRegistrationApi;
using ConferenceRegistrationApi.Adapters.DaprStuff;
using ConferenceRegistrationApi.Adapters.Mongo;
using ConferenceRegistrationApi.GrpcPorts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDaprClient();
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("bsonid", typeof(BsonIdConstraint));
});

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IOptions Stuff
builder.Services.Configure<ProductsSettings>(builder.Configuration.GetSection(ProductsSettings.SectionName));

// My Domain Services

builder.Services.AddScoped<IProductsService, ProductService>();
builder.Services.AddScoped<IProcessReservations, ReservationProcessor>();

// Adapters
builder.Services.AddSingleton<MongoProductsAdapter>();

builder.Services.AddHttpClient<MarkupServiceAdapter>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("markupApi"));
}).AddPolicyHandler(HttpPolicies.GetMarkupRetryPolicy());

builder.Services.AddScoped<MarkupServiceAmountPort>();
builder.Services.AddScoped<DaprReservationAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapSubscribeHandler();
app.UseAuthorization();
app.MapGrpcService<ReservationRequestsGrpcService>();
app.MapControllers();

app.Run();
