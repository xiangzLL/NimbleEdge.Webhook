// See https://aka.ms/new-console-template for more information

using SignalrDemo;

var client = new KangClient();
await client.InitHubConnectionAsync();


Console.ReadLine();
