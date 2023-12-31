﻿using System.Runtime.CompilerServices;
using castledice_game_data_logic;
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
        message.AddInt(data.BoardLength);
        message.AddInt(data.BoardWidth);
        message.AddInt((int)data.CellType);
        message.Add2DBoolArray(data.CellsPresence);
        message.AddContentDataList(data.GeneratedContent);
        message.AddInt(data.KnightHealth);
        message.AddInt(data.KnightPlaceCost);
        message.AddIntList(data.PlayersIds);
        message.AddPlayerDeckDataList(data.Decks);
    }

    internal static GameStartData GetGameStartData(this Message message)
    {
        var boardLength = message.GetInt();
        var boardWidth = message.GetInt();
        var cellType = (CellType)message.GetInt();
        var cellsPresence = message.Get2DBoolArray(boardLength, boardWidth);
        var generatedContent = message.GetContentDataList();
        var knightHealth = message.GetInt();
        var knightPlaceCost = message.GetInt();
        var playersIds = message.GetIntList();
        var decks = message.GetPlayerDeckDataList();
        return new GameStartData(boardLength, boardWidth, cellType, cellsPresence, generatedContent, knightHealth, knightPlaceCost, playersIds, decks);
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
                var captureHitCost = message.GetInt();
                var freeDurability = message.GetInt();
                var defaultDurability = message.GetInt();
                var durability = message.GetInt();
                var ownerId = message.GetInt();
                return new CastleData(position, captureHitCost, freeDurability, defaultDurability, durability, ownerId);
            case ContentDataType.Tree:
                var removeCost = message.GetInt();
                var canBeRemoved = message.GetBool();
                return new TreeData(position, removeCost, canBeRemoved);
            default:
                throw new ArgumentException("Unfamiliar ContentDataType: " + type);
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