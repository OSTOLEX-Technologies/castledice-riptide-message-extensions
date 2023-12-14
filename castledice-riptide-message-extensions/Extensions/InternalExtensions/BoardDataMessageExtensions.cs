using castledice_game_data_logic.ConfigsData;
using castledice_game_logic;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class BoardDataMessageExtensions
{
    internal static void AddBoardData(this Message message, BoardData data)
    {
        message.AddInt(data.BoardLength);
        message.AddInt(data.BoardWidth);
        message.AddInt((int)data.CellType);
        message.Add2DBoolArray(data.CellsPresence);
        message.AddContentDataList(data.GeneratedContent);
    }
    
    internal static BoardData GetBoardData(this Message message)
    {
        var boardLength = message.GetInt();
        var boardWidth = message.GetInt();
        var cellType = (CellType)message.GetInt();
        var cellsPresence = message.Get2DBoolArray(boardLength, boardWidth);
        var Content = message.GetContentDataList();
        return new BoardData(boardLength, boardWidth, cellType, cellsPresence, Content);
    }
}