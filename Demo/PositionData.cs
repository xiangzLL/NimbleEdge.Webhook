namespace Demo;

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
