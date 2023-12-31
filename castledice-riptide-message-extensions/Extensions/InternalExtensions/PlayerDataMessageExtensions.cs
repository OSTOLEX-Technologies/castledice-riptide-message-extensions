using castledice_game_data_logic;
using castledice_game_logic.GameObjects;
using Riptide;
using static castledice_riptide_dto_adapters.Extensions.InternalExtensions.GeneralMessageExtensions;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class PlayerDataMessageExtensions
{
    internal static void AddPlayerDataList(this Message message, List<PlayerData> playerDataList)
    {
        AddList(message, playerDataList, AddPlayerData);
    }
    
    internal static List<PlayerData> GetPlayerDataList(this Message message)
    {
        return GetList(message, GetPlayerData);
    }
    
    internal static void AddPlayerData(this Message message, PlayerData data)
    {
        message.AddInt(data.PlayerId);
        message.AddPlacementTypeList(data.AvailablePlacements);
        message.AddTimeSpan(data.TimeSpan);
    }
    
    internal static PlayerData GetPlayerData(this Message message)
    {
        var playerId = message.GetInt();
        var availablePlacements = message.GetPlacementTypeList();
        var timeSpan = message.GetTimeSpan();
        return new PlayerData(playerId, availablePlacements, timeSpan);
    }
    
    internal static void AddPlacementTypeList(this Message message, List<PlacementType> placementTypes)
    {
        AddList(message, placementTypes, AddPlacementType);
    }
    
    internal static List<PlacementType> GetPlacementTypeList(this Message message)
    {
        return GetList(message, GetPlacementType);
    }
    
    internal static void AddPlacementType(this Message message, PlacementType placementType)
    {
        message.AddInt((int)placementType);
    }
    
    internal static PlacementType GetPlacementType(this Message message)
    {
        return (PlacementType)message.GetInt();
    }
}