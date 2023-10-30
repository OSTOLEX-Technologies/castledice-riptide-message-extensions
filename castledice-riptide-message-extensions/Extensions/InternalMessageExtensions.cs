﻿using System.Runtime.CompilerServices;
using castledice_game_data_logic;
using castledice_game_data_logic.ConfigsData;
using castledice_game_data_logic.Content;
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
        return new GameStartData(version, boardConfigData, placeablesConfigs, playersIds, decks);
    }

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
    
    internal static void AddContentDataList(this Message message, List<ContentData> list)
    {
        AddList(message, list, AddContentData);
    }

    internal static List<ContentData> GetContentDataList(this Message message)
    {
        return GetList(message, GetContentData);
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

    internal static void AddContentData(this Message message, ContentData data)
    {
        var adder = new ContentDataAdder(message);
        adder.AddContentData(data);
    }

    internal static ContentData GetContentData(this Message message)
    {
        var position = message.GetVector2Int();
        var type = (ContentDataType)message.GetInt();
        switch (type)
        {
            case ContentDataType.Castle:
                return message.GetCastleData(position);
            case ContentDataType.Tree:
                return message.GetTreeData(position);
            case ContentDataType.Knight:
                return message.GetKnightData(position);
            default:
                throw new ArgumentException("Unfamiliar ContentDataType: " + type);
        }
    }
    
    private static CastleData GetCastleData(this Message message, Vector2Int position)
    {
        var captureHitCost = message.GetInt();
        var maxFreeDurability = message.GetInt();
        var maxDurability = message.GetInt();
        var durability = message.GetInt();
        var ownerId = message.GetInt();
        return new CastleData(position, captureHitCost, maxFreeDurability, maxDurability, durability, ownerId);
    }
    
    private static TreeData GetTreeData(this Message message, Vector2Int position)
    {
        var removeCost = message.GetInt();
        var canBeRemoved = message.GetBool();
        return new TreeData(position, removeCost, canBeRemoved);
    }
    
    private static KnightData GetKnightData(this Message message, Vector2Int position)
    {
        var health = message.GetInt();
        var placeCost = message.GetInt();
        var ownerId = message.GetInt();
        return new KnightData(position, health, placeCost, ownerId);
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