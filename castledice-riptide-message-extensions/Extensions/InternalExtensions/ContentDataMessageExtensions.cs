using castledice_game_data_logic.Content;
using castledice_game_logic.Math;
using Riptide;
using static castledice_riptide_dto_adapters.Extensions.InternalExtensions.GeneralMessageExtensions;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class ContentDataMessageExtensions
{
    internal static void AddContentDataList(this Message message, List<ContentData> list)
    {
        AddList(message, list, AddContentData);
    }

    internal static List<ContentData> GetContentDataList(this Message message)
    {
        return GetList(message, GetContentData);
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
}