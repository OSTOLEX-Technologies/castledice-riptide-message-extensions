using System.Runtime.CompilerServices;
using castledice_game_data_logic;
using castledice_game_data_logic.Content.Generated;
using castledice_game_data_logic.Content.Placeable;
using castledice_game_logic;
using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using Riptide;

[assembly: InternalsVisibleTo("castledice-riptide-message-extensions-tests")]
namespace castledice_riptide_dto_adapters.Extensions;

internal static class InternalMessageExtensions
{
    internal static void AddGameStartData(this Message message, GameStartData data)
    {
        message.AddString(data.Version);
        message.AddInt(data.BoardLength);
        message.AddInt(data.BoardWidth);
        message.AddInt((int)data.CellType);
        message.Add2DBoolArray(data.CellsPresence);
        message.AddGeneratedContentDataList(data.GeneratedContent);
        message.AddPlaceableContentDataList(data.PlaceablesConfigs);
        message.AddIntList(data.PlayersIds);
        message.AddPlayerDeckDataList(data.Decks);
    }

    internal static GameStartData GetGameStartData(this Message message)
    {
        var version = message.GetString();
        var boardLength = message.GetInt();
        var boardWidth = message.GetInt();
        var cellType = (CellType)message.GetInt();
        var cellsPresence = message.Get2DBoolArray(boardLength, boardWidth);
        var generatedContent = message.GetGeneratedContentDataList();
        var placeablesConfigs = message.GetPlaceableContentDataList();
        var playersIds = message.GetIntList();
        var decks = message.GetPlayerDeckDataList();
        return new GameStartData(version, boardLength, boardWidth, cellType, cellsPresence, generatedContent, placeablesConfigs, playersIds, decks);
    } 
    
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
    
    internal static void AddIntList(this Message message, List<int> list)
    {
        AddList(message, list, (mes, num) => { mes.AddInt(num);});
    }

    internal static List<int> GetIntList(this Message message)
    {
        return GetList(message, mes => mes.GetInt());
    }

    internal static void AddPlaceableContentDataList(this Message message, List<PlaceableContentData> list)
    {
        AddList(message, list, AddPlaceableContentData);
    }

    internal static List<PlaceableContentData> GetPlaceableContentDataList(this Message message)
    {
        return GetList(message, GetPlaceableContentData);
    }
    
    internal static void AddGeneratedContentDataList(this Message message, List<GeneratedContentData> list)
    {
        AddList(message, list, AddGeneratedContentData);
    }

    internal static List<GeneratedContentData> GetGeneratedContentDataList(this Message message)
    {
        return GetList(message, GetGeneratedContentData);
    }

    private static void AddList<T>(Message message, List<T> list, Action<Message, T> addFunction)
    {
        message.AddInt(list.Count);
        foreach (var item in list)
        {
            addFunction(message, item);
        }
    }

    private static List<T> GetList<T>(Message message, Func<Message, T> getFunction)
    {
        var itemsCount = message.GetInt();
        var list = new List<T>();
        for (int i = 0; i < itemsCount; i++)
        {
            list.Add(getFunction(message));
        }
        return list;
    }

    internal static void AddPlaceableContentData(this Message message, PlaceableContentData data)
    {
        var adder = new ContentDataAdder(message);
        adder.AddPlaceableContentData(data);
    }

    internal static PlaceableContentData GetPlaceableContentData(this Message message)
    {
        var type = (PlacementType)message.GetInt();
        switch (type)
        {
            case PlacementType.Knight:
                var placementCost = message.GetInt();
                var health = message.GetInt();
                return new KnightData(placementCost, health);
            default:
                throw new ArgumentException("Unfamiliar PlacementType: " + type);
        }
    }

    internal static void AddGeneratedContentData(this Message message, GeneratedContentData data)
    {
        var adder = new ContentDataAdder(message);
        adder.AddGeneratedContentData(data);
    }

    internal static GeneratedContentData GetGeneratedContentData(this Message message)
    {
        var position = message.GetVector2Int();
        var type = (GeneratedContentDataType)message.GetInt();
        switch (type)
        {
            case GeneratedContentDataType.Castle:
                var captureHitCost = message.GetInt();
                var freeDurability = message.GetInt();
                var defaultDurability = message.GetInt();
                var durability = message.GetInt();
                var ownerId = message.GetInt();
                return new CastleData(position, captureHitCost, freeDurability, defaultDurability, durability, ownerId);
            case GeneratedContentDataType.Tree:
                var removeCost = message.GetInt();
                var canBeRemoved = message.GetBool();
                return new TreeData(position, removeCost, canBeRemoved);
            default:
                throw new ArgumentException("Unfamiliar GeneratedContentDataType: " + type);
        }
    }
    
    internal static void AddVector2Int(this Message message, Vector2Int vector)
    {
        message.AddInt(vector.X);
        message.AddInt(vector.Y);
    }

    internal static Vector2Int GetVector2Int(this Message message)
    {
        var vector = new Vector2Int();
        vector.X = message.GetInt();
        vector.Y = message.GetInt();
        return vector;
    }

    internal static void Add2DBoolArray(this Message message, bool[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                message.AddBool(array[i, j]);
            }
        }
    }

    internal static bool[,] Get2DBoolArray(this Message message, int length, int width)
    {
        var array = new bool[length, width];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = message.GetBool();
            }
        }
        return array;
    }
}