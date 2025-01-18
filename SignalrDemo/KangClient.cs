using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SignalrDemo;

public class KangClient
{
    private HubConnection _connection;
    private string _urlAddress;

    public KangClient() 
    {
        _urlAddress = $"http://106.15.61.202:6001";
    }

    public async Task InitHubConnectionAsync()
    {
        if (_connection != null)
            return;

        var builder = new HubConnectionBuilder()
            .AddJsonProtocol(t =>
            {
                t.PayloadSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                t.PayloadSerializerOptions.Converters.Add(new DateTimeConverter());
            })
            .WithUrl($"{_urlAddress}/MonitorHub", options =>
            {
                options.Transports = HttpTransportType.WebSockets;
            })
            .WithAutomaticReconnect();

        _connection = builder.Build();

        //数据记录
        //参数：点位Id， 点位功能， 数据列表
        _connection.On<int, string, ICollection<RecordContent>>("PositionRecordReported", (positionId, function, recordContents) =>
        {

        });

        //监控状态变化
        _connection.On<bool>("MonitoringStatusChanged",
            (isMonitoring) =>
            {

            });

        //报警数据
        _connection.On<AlarmQueryModel>("AlarmReported",
            (alarmQueryModel) =>
            {

            });

        await _connection.StartAsync();
    }
}

public class DateTimeConverter : System.Text.Json.Serialization.JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return DateTime.Parse(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}

public class RecordContent
{
    public string Key { get; set; }

    public double Value { get; set; }

    public DeviceStatus DeviceStatus { get; set; }

    /// <summary>
    /// 设备地址
    /// </summary>
    public int DeviceAddress { get; set; }

    public string Channel { get; set; }

    /// <summary>
    /// 记录构造函数
    /// </summary>
    /// <param name="key">对应的设备功能</param>
    /// <param name="value">功能值</param>
    /// <param name="deviceAddress">设备物理地址</param>
    /// <param name="channel">设备对应的通道</param>
    public RecordContent(string key, double value, int deviceAddress, string channel)
    {
        Key = key;
        Value = value;
        DeviceAddress = deviceAddress;
        Channel = channel;
        DeviceStatus = DeviceStatus.Normal;
    }

    public RecordContent(string key, double value)
    {
        Key = key;
        Value = value;
        DeviceStatus = DeviceStatus.Normal;
    }

    public RecordContent()
    {
    }

    public override string ToString()
    {
        return $"{Key} {Value} {DeviceStatus} {DeviceAddress} {Channel}";
    }
}

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

public class AlarmQueryModel
{
    public int Id { get; set; }

    public DateTime ReportTime { get; set; }

    public string PositionName { get; set; }

    public ICollection<AlarmDetailDTO> AlarmDetails { get; set; } = new List<AlarmDetailDTO>();

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

    public AlarmDetailDTO()
    {
        ReportTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Invalid: {Function} {AlarmProperty} = {AlarmValue}";
    }
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

/// <summary>
/// 点位功能类型
/// </summary>
public enum PositionFunctionEnum
{
    /// <summary>
    /// 粒子计数
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
    DewPoint,
    /// <summary>
    /// 电阻率
    /// </summary>
    Resistivity
}