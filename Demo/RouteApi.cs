using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Demo;

public class RouteApi
{
    public static async ValueTask<IResult> OperateRecords([FromBody]IList<PositionRecord> records)
    {
        foreach(var record in records)
        {
            Console.WriteLine($"数据记录： {record.PositionName} === {record.PositionFunction}   {record.CreateTime}  {DateTime.Now}");
        }
        return TypedResults.Ok();
    }

    public static async ValueTask<IResult> OperateAlarms([FromBody] AlarmData alarm)
    {
        Console.WriteLine($"告警记录： {alarm.PositionName} ，数量： {alarm.AlarmDetails.Count}");
        return TypedResults.Ok();
    }

    public static async ValueTask<string> GetTest()
    {
        return "123";
    }
}
