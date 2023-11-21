using castledice_game_data_logic.TurnSwitchConditions;
using static castledice_riptide_dto_adapters.Extensions.InternalExtensions.GeneralMessageExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

/// <summary>
/// Tsc stands for Turn Switch Condition.
/// </summary>
public static class TscDataMessageExtensions
{
    public static void AddTscDataList(this Message message, List<TscData> data)
    {
        AddList(message, data, AddTscData);
    }
    
    public static List<TscData> GetTscDataList(this Message message)
    {
        return GetList(message, GetTscData);
    }
    
    public static void AddTscData(this Message message, TscData data)
    {
        var tscDataAdder = new TscDataAdder(message);
        tscDataAdder.AddData(data);
    }
    
    public static TscData GetTscData(this Message message)
    {
        var tscType = (TscType)message.GetInt();
        return tscType switch
        {
            TscType.ActionPoints => message.GetActionPointsConditionData(),
            TscType.Time => message.GetTimeConditionData(),
            _ => throw new ArgumentException("Unfamiliar TscType: " + tscType)
        };
    }
    
    private static ActionPointsConditionData GetActionPointsConditionData(this Message message)
    {
        return new();
    }
    
    private static TimeConditionData GetTimeConditionData(this Message message)
    {
        var turnDuration =  message.GetInt();
        return new(turnDuration);
    }
}