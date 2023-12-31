using castledice_events_logic.ClientToServer;
using castledice_events_logic.ServerToClient;
using castledice_game_data_logic;
using castledice_game_data_logic.ConfigsData;
using castledice_game_data_logic.Content;
using castledice_game_data_logic.Errors;
using castledice_game_data_logic.Moves;
using castledice_game_data_logic.TurnSwitchConditions;
using castledice_game_logic;
using castledice_game_logic.GameObjects;
using castledice_game_logic.TurnsLogic.TurnSwitchConditions;
using Riptide;

namespace castledice_riptide_dto_adapters_tests;

public static class ObjectCreationUtility
{
    public static ErrorData GetErrorData()
    {
        return new ErrorData(ErrorType.GameNotSaved, "Game was not saved");
    }
    
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
    
    public static KnightData GetKnightData()
    {
        return new KnightData((0, 0), 1, 1, 1);
    }
    
    public static GameStartData GetGameStartData()
    {
        var version = "1.0.0";
        var boardConfigData = GetBoardData();
        var placeablesConfigs = new PlaceablesConfigData(GetKnightConfigData());
        var playersData = new List<PlayerData>
        {
            new PlayerData(1, new List<PlacementType> { PlacementType.Knight }, new TimeSpan()),
            new PlayerData(2, new List<PlacementType> { PlacementType.Knight }, new TimeSpan())
        };
        var tscConfigData = new TscConfigData(new List<TscType> { TscType.SwitchByActionPoints });
        var data = new GameStartData(version, boardConfigData, placeablesConfigs, tscConfigData, playersData);
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
    
    public static MoveFromServerDTO GetMoveFromServerDTO(MoveData moveData)
    {
        return new MoveFromServerDTO(moveData);
    }
    
    public static MoveFromClientDTO GetMoveFromClientDTO(MoveData moveData)
    {
        return new MoveFromClientDTO(moveData, "sometoken");
    }
    
    public static RemoveMoveData GetRemoveMoveData()
    {
        return new RemoveMoveData(1, (0, 0));
    }
    
    public static ReplaceMoveData GetReplaceMoveData()
    {
        return new ReplaceMoveData(1, (0, 0), PlacementType.Knight);
    }
    
    public static UpgradeMoveData GetUpgradeMoveData()
    {
        return new UpgradeMoveData(1, (0, 0));
    }
    
    public static CaptureMoveData GetCaptureMoveData()
    {
        return new CaptureMoveData(1, (0, 0));
    }
    
    public static PlaceMoveData GetPlaceMoveData()
    {
        return new PlaceMoveData(1, (0, 0), PlacementType.Knight);
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
    
    public static List<PlayerData> GetRandomPlayerDataList()
    {
        var list = new List<PlayerData>();
        var random = new Random();
        var count = random.Next(1, 5);
        for (int i = 0; i < count; i++)
        {
            list.Add(GetPlayerData(random.Next(1, 5), new TimeSpan(), GetRandomPlacementTypeList().ToArray()));
        }

        return list;
    }
    
    
    public static PlayerData GetPlayerData(int id = 1, TimeSpan timeSpan = new(), params PlacementType[] availablePlacements)
    {
        return new PlayerData(id, availablePlacements.ToList(), timeSpan);
    }
    
    public static List<PlacementType> GetRandomPlacementTypeList()
    {
        var list = new List<PlacementType>();
        var random = new Random();
        var count = random.Next(1, 5);
        for (int i = 0; i < count; i++)
        {
            list.Add(GetRandomPlacementType());
        }

        return list;
    }

    public static PlacementType GetRandomPlacementType()
    {
        var values = Enum.GetValues(typeof(PlacementType));
        var random = new Random();
        var randomIndex = random.Next(values.Length);
        return (PlacementType)values.GetValue(randomIndex);
    }
    
    public static TimeSpan GetRandomTimeSpan()
    {
        var random = new Random();
        return new TimeSpan(random.Next());
    }
}