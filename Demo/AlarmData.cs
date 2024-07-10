namespace Demo;

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
