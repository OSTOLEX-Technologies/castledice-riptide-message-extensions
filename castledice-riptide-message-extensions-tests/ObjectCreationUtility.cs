using castledice_game_data_logic;
using castledice_game_data_logic.ConfigsData;
using castledice_game_data_logic.Content;
using castledice_game_logic;
using castledice_game_logic.GameObjects;
using Riptide;

namespace castledice_riptide_dto_adapters_tests;

public static class ObjectCreationUtility
{
    //This method reads UShort two times in order to remove additional information from the message.
    //This information is usually handled by riptide, but it is unnecessary in unit tests.
    public static Message GetEmptyMessage()
    {
        var message = Message.Create(MessageSendMode.Unreliable, 1);
        message.GetByte();
        message.GetByte();
        return message;
    }
    
    public static CastleData GetCastleData()
    {
        return new CastleData((0, 0), 1, 1, 3, 3, 1);
    }

    public static TreeData GetTreeData()
    {
        return new TreeData((0, 0), 3, false);
    }
    
    public static GameStartData GetGameStartData()
    {
        var version = "1.0.0";
        var playerIds = new List<int> { 1, 2 };
        var boardConfigData = GetBoardData();
        var placeablesConfigs = new PlaceablesConfigData(GetKnightConfigData());
        var playerDecks = new List<PlayerDeckData>
        {
            new(playerIds[0], new List<PlacementType> { PlacementType.Knight }),
            new (playerIds[1], new List<PlacementType> { PlacementType.Knight })
        };
        var data = new GameStartData(version, boardConfigData, placeablesConfigs, playerIds, playerDecks);
        return data;
    }

    public static BoardData GetBoardData()
    {
        var boardLength = 10;
        var boardWidth = 10;
        var cellType = CellType.Square;
        var cellsPresence = GetNByNTrueBoolMatrix(10);
        var firstCastle = new CastleData((0, 0), 1, 1, 3, 3, 1);
        var secondCastle = new CastleData((9, 9), 1, 1, 3, 3, 2);
        var content = new List<ContentData>
        {
            firstCastle, 
            secondCastle
        };
        return new BoardData(boardLength, boardWidth, cellType, cellsPresence, content);
    }
    
    public static KnightConfigData GetKnightConfigData()
    {
        return new KnightConfigData(1, 2);
    }

    public static bool[,] GetNByNTrueBoolMatrix(int size)
    {
        var matrix = new bool[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                matrix[i, j] = true;
            }
        }

        return matrix;
    }
}