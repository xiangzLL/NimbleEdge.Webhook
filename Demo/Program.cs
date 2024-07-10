using Demo;
using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();


////点位数据
//app.MapPost("/data2", RouteApi.OperateRecords);

////告警数据
//app.MapPost("/alarm2", RouteApi.OperateAlarms);

//点位数据
app.MapPost("/data", (IList<PositionRecord> records) =>
{
    foreach (var record in records)
    {
        Console.WriteLine($"数据记录： {record.PositionName} === {record.PositionFunction}   {record.CreateTime}  {DateTime.Now}");
    }
    return TypedResults.Ok();
});

//告警数据
app.MapPost("/alarm", (AlarmData alarm) =>
{
    Console.WriteLine($"告警记录： {alarm.PositionName} ，数量： {alarm.AlarmDetails.Count}");
    return TypedResults.Ok();
});

app.Run();


