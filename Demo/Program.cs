using Demo;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();


////��λ����
//app.MapPost("/data2", RouteApi.OperateRecords);

////�澯����
//app.MapPost("/alarm2", RouteApi.OperateAlarms);

//��λ����
app.MapPost("/data", (IList<PositionRecord> records) =>
{
    foreach (var record in records)
    {
        Console.WriteLine($"���ݼ�¼�� {record.PositionName} === {record.PositionFunction}   {record.CreateTime}  {DateTime.Now}");
    }
    return TypedResults.Ok();
});

//�澯����
app.MapPost("/alarm", (AlarmData alarm) =>
{
    Console.WriteLine($"�澯��¼�� {alarm.PositionName} �������� {alarm.AlarmDetails.Count}");
    return TypedResults.Ok();
});

app.Run();


