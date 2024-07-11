## KangServer开放的对接数据
> 💡 Tips：可通过此方式将KangServer与MES等系统对接。

- 点位数据记录。
- 告警记录。
## 点位数据记录
> 💡 Tips：Json序列化添加枚举与字符串的格式转换

:::tips

- **URL**：`/data`
- **Method**：`POST`
- **需要登录**：否
- **需要鉴权**：否
:::
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

//数据记录
app.MapPost("/data", (IList<PositionRecord> records) =>
{
    foreach (var record in records)
    {
        Console.WriteLine($"{record.PositionName} => {record.PositionFunction} {record.CreateTime}");
    }
    return TypedResults.Ok();
});

app.Run();
```
```csharp
/// <summary>
/// 点位数据
/// </summary>
public class PositionRecord
{
    /// <summary>
    /// 点位ID
    /// </summary>
    public int PositionId { get; set; }

    /// <summary>
    /// 点位名称
    /// </summary>
    public string PositionName { get; set; }

    /// <summary>
    /// 区域名称
    /// </summary>
    public string AreaName { get; set; }

    /// <summary>
    /// 点位功能类型
    /// </summary>
    public PositionFunctionEnum PositionFunction { get; set; }

    /// <summary>
    /// 点位功能指定数据
    /// </summary>
    public ICollection<RecordContent> Contents { get; set; } = new List<RecordContent>();

    /// <summary>
    /// 记录创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
}

public class RecordContent
{
    /// <summary>
    /// 数据内容
    /// "Flow": "流量"
    /// "Micron01": "0.1μm"
    /// "Micron02": "0.2μm"
    /// "Micron03": "0.3μm"
    /// "Micron05": "0.5μm"
    /// "Micron10": "1.0μm"
    /// "Micron30": "3.0μm"
    /// "Micron50": "5.0μm"
    /// "Micron100": "10.0μm"
    /// "Micron150": "15.0μm"
    /// "Volume": "体积"
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// 当前值
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// 设备状态
    /// </summary>
    public DeviceStatus DeviceStatus { get; set; }

    /// <summary>
    /// 对应设备的地址，用于数据异常时，检测硬件
    /// </summary>
    public int DeviceAddress { get; set; }

    /// <summary>
    /// 设备所属的通道
    /// </summary>
    public string Channel { get; set; }

}

/// <summary>
/// 点位功能类型
/// </summary>
public enum PositionFunctionEnum
{
    /// <summary>
    /// 粒子计数器
    /// </summary>
    ParticleCounting,
    /// <summary>
    /// 浮游菌
    /// </summary>
    AirborneMicrobe,
    /// <summary>
    /// 温湿度
    /// </summary>
    Humiture,
    /// <summary>
    /// 环境参数
    /// </summary>
    Environment,
    /// <summary>
    /// 风速
    /// </summary>
    Wind,
    /// <summary>
    /// 压差
    /// </summary>
    Press,
    /// <summary>
    /// 氧气
    /// </summary>
    Oxygen,
    /// <summary>
    /// 露点
    /// </summary>
    DewPoint
}

/// <summary>
/// 设备状态
/// </summary>
public enum DeviceStatus
{
    /// <summary>
    /// 设备未启动
    /// </summary>
    NotStarted,
    /// <summary>
    /// 设备离线
    /// </summary>
    Offline,
    /// <summary>
    /// 设备正常
    /// </summary>
    Normal,
    /// <summary>
    /// 设备预警
    /// </summary>
    Warning,
    /// <summary>
    /// 设备告警
    /// </summary>
    Alarm
}

```
## 告警记录
💡 Tips：Json序列化添加枚举与字符串的格式转换
:::tips

- **URL**：`/alarm`
- **Method**：`POST`
- **需要登录**：否
- **需要鉴权**：否
:::
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JsonOptions>(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

//告警
app.MapPost("/alarm", (AlarmData alarm) =>
{
    return TypedResults.Ok();
});

app.Run();
```
```csharp
/// <summary>
/// 告警数据
/// </summary>
public class AlarmData
{
    /// <summary>
    /// 记录Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 告警产生时间
    /// </summary>
    public DateTime ReportTime { get; set; }

    /// <summary>
    /// 点位名称
    /// </summary>
    public string PositionName { get; set; }

    public ICollection<AlarmDetailDTO> AlarmDetails { get; set; } = new List<AlarmDetailDTO>();

    /// <summary>
    /// 告警等级
    /// </summary>
    public AlarmLevelEnum Level { get; set; }
}

public class AlarmDetailDTO
{
    /// <summary>
    /// 告警属性
    /// </summary>
    public string AlarmProperty { get; set; }

    /// <summary>
    /// 告警值
    /// </summary>
    public double AlarmValue { get; set; }

    /// <summary>
    /// 点位功能
    /// </summary>
    public PositionFunctionEnum Function { get; set; }

    /// <summary>
    /// 当前属性报警时间
    /// </summary>
    public DateTime ReportTime { get; set; }
}

public enum AlarmLevelEnum
{
    /// <summary>
    /// 预警
    /// </summary>
    Warning,

    /// <summary>
    /// 报警
    /// </summary>
    Alarm
}

```
## 界面配置
> 💡 Tips：注意系统登录的账号需要有消息通知的权限

1. 系统设置，点击消息通知，进入Webhook配置![image.png](https://cdn.nlark.com/yuque/0/2024/png/38594622/1720674555577-c7ff75b9-cc83-4b55-9143-a0af73204032.png#averageHue=%23fefefd&clientId=u35961b88-f4fd-4&from=paste&id=u42a5f8f4&originHeight=880&originWidth=1920&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=82962&status=done&style=none&taskId=u95e29d7a-af58-4123-a7df-6e2896e989b&title=)

2. 选择编辑配置

![1720674103296.jpg](https://cdn.nlark.com/yuque/0/2024/jpeg/38594622/1720674135266-9c360437-13a0-403e-ae07-9da790f0dbf9.jpeg#averageHue=%23fefefe&clientId=u35961b88-f4fd-4&from=paste&id=ub2e94d5c&originHeight=880&originWidth=1920&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=35296&status=done&style=none&taskId=ua9ce9121-4166-4c1d-830e-37eb62af8ee&title=)

3. 输入程序的API地址，选择要响应的功能

![image.png](https://cdn.nlark.com/yuque/0/2024/png/38594622/1720674217061-261be7da-cf33-4caa-92b2-eaf86e315987.png#averageHue=%23cecece&clientId=u35961b88-f4fd-4&from=paste&height=488&id=u76e6d7f0&originHeight=610&originWidth=860&originalType=binary&ratio=1.25&rotation=0&showTitle=false&size=20727&status=done&style=none&taskId=uc38d4f29-8e0d-4ec9-9928-d0b40d7f99d&title=&width=688)

