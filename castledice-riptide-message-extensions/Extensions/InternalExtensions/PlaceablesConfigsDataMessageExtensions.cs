using castledice_game_data_logic.ConfigsData;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class PlaceablesConfigsDataMessageExtensions
{
    internal static void AddPlaceablesConfigData(this Message message, PlaceablesConfigData config)
    {
        message.AddKnightConfigData(config.KnightConfig);
    }
    
    internal static PlaceablesConfigData GetPlaceablesConfigData(this Message message)
    {
        var knightConfig = message.GetKnightConfigData();
        return new PlaceablesConfigData(knightConfig);
    }
    
    internal static void AddKnightConfigData(this Message message, KnightConfigData data)
    {
        message.AddInt(data.PlacementCost);
        message.AddInt(data.Health);
    }
    
    internal static KnightConfigData GetKnightConfigData(this Message message)
    {
        var placementCost = message.GetInt();
        var health = message.GetInt();
        return new KnightConfigData(placementCost, health);
    }
}