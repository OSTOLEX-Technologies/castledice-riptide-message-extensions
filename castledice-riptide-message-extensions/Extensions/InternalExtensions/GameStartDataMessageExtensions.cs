using castledice_game_data_logic;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class GameStartDataMessageExtensions
{
    internal static void AddGameStartData(this Message message, GameStartData data)
    {
        message.AddString(data.Version);
        message.AddBoardData(data.BoardData);
        message.AddPlaceablesConfigData(data.PlaceablesConfigData);
        message.AddIntList(data.PlayersIds);
        message.AddPlayerDeckDataList(data.Decks);
    }

    internal static GameStartData GetGameStartData(this Message message)
    {
        var version = message.GetString();
        var boardConfigData = message.GetBoardData();
        var placeablesConfigs = message.GetPlaceablesConfigData();
        var playersIds = message.GetIntList();
        var decks = message.GetPlayerDeckDataList();
        throw new NotImplementedException();
        //return new GameStartData(version, boardConfigData, placeablesConfigs, playersIds, decks);
    }
}