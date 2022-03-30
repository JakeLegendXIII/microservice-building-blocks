// See https://aka.ms/new-console-template for more information
using Grpc.Core;
using Grpc.Net.Client;
using ServerSide;

Console.WriteLine("Hello, World!");

Console.WriteLine("Calling the Grpc Service");
Console.WriteLine("Hit Enter when the Server is Running");
Console.ReadLine();

Console.Write("Enter your name: ");
var name = Console.ReadLine();

// channel - is to server that has one or more services.
var channel = GrpcChannel.ForAddress("https://localhost:3000");
// using the channel a client
var greeterClient = new Greeter.GreeterClient(channel);

var requestMessage = new HelloRequest() { Name = name };

var response = await greeterClient.SayHelloAsync(requestMessage);

Console.WriteLine($"The server said {response.Message}");
Console.WriteLine($"The server also said {response.CreatedAt}");

Console.WriteLine("Need Turn By Turn Directions? Tell us where you want to go today...");
var destination = Console.ReadLine();

var turnByTurnClient = new TurnByTurn.TurnByTurnClient(channel);

var streamingResponse = turnByTurnClient.StartGuidance(new GuidanceRequest { Address = destination });

await foreach(var step in streamingResponse.ResponseStream.ReadAllAsync())
{
    Console.WriteLine($"Next Step: Turn { step.Direction} on {step.Road}");
}

Console.WriteLine("You have arrived!");