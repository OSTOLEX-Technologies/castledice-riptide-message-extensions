using castledice_game_data_logic.TurnSwitchConditions;
using castledice_game_logic.TurnsLogic.TurnSwitchConditions;
using static castledice_riptide_dto_adapters.Extensions.InternalExtensions.GeneralMessageExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

/// <summary>
/// Tsc stands for Turn Switch Condition.
/// </summary>
public static class TscConfigDataMessageExtensions
{
    public static void AddTscConfigData(this Message message, TscConfigData data)
    {
        message.AddTscTypeList(data.TscTypes);
    }

    public static TscConfigData GetTscConfigData(this Message message)
    {
        var tscTypes = message.GetTscTypeList();
        return new TscConfigData(tscTypes);
    }
    
    private static void AddTscTypeList(this Message message, List<TscType> list)
    {
        AddList(message, list, AddTscType);
    }
    
    private static List<TscType> GetTscTypeList(this Message message)
    {
        return GetList(message, GetTscType);
    }
    
    private static void AddTscType(this Message message, TscType type)
    {
        message.AddInt((int)type);
    }
    
    private static TscType GetTscType(this Message message)
    {
        return (TscType)message.GetInt();
    }
}