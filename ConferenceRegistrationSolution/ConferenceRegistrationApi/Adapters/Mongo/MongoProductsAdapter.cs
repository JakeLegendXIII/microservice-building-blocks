using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ConferenceRegistrationApi.Adapters.Mongo;

public class MongoProductsAdapter
{
    private readonly IMongoCollection<Product> _productsCollection;
    public MongoProductsAdapter(IOptions<ProductsSettings> settings)
    {
        var mongoClient = new MongoClient(settings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
        _productsCollection = mongoDatabase.GetCollection<Product>(settings.Value.CollectionName);
    }

    public async Task<List<Product>> GetAllAsync() => await _productsCollection.Find(_ => true).ToListAsync();

    public async  Task<Product> GetProductById(string id)
    {
        return await _productsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }
}

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("name")]
    public string Name { get; set; } = "";
    [BsonElement("cost")]
    public decimal Cost { get; set; }
}