using Demo;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

//数据记录
app.MapPost("/data", (IList<PositionRecord> records) =>
{
    foreach (var record in records)
    {
        Console.WriteLine($"{record.PositionName} => {record.PositionFunction}   {record.CreateTime}  {DateTime.Now}");
    }
    return TypedResults.Ok();
});

//告警
app.MapPost("/alarm", (AlarmData alarm) =>
{
    return TypedResults.Ok();
});

app.Run();


