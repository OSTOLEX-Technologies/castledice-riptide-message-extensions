using castledice_game_data_logic;
using castledice_game_logic.GameObjects;
using static castledice_riptide_dto_adapters.Extensions.InternalExtensions.GeneralMessageExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class PlayerDeckDataMessageExtensions
{
    internal static void AddPlayerDeckDataList(this Message message, List<PlayerDeckData> list)
    {
        AddList(message, list, AddPlayerDeckData);
    }

    internal static List<PlayerDeckData> GetPlayerDeckDataList(this Message message)
    {
        return GetList(message, GetPlayerDeckData);
    }

    internal static void AddPlayerDeckData(this Message message, PlayerDeckData data)
    {
        message.AddInt(data.PlayerId);
        AddList(message, data.AvailablePlacements, (mes, type) => mes.AddInt((int)type));
    }

    internal static PlayerDeckData GetPlayerDeckData(this Message message)
    {
        var playerId = message.GetInt();
        var availablePlacements = GetList(message, mes => (PlacementType)mes.GetInt());
        return new PlayerDeckData(playerId, availablePlacements);
    }
}