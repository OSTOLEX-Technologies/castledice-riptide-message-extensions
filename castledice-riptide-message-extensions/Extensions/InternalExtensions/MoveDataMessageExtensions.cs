using castledice_game_data_logic.Moves;
using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_game_logic.MovesLogic;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions;

public static class MoveDataMessageExtensions
{
    public static MoveData GetMoveData(this Message message)
    {
        var moveType = (MoveType)message.GetInt();
        var position = message.GetVector2Int();
        var playerId = message.GetInt();
        switch (moveType)
        {
            case MoveType.Place:
                return message.GetPlaceMoveData(position, playerId);
            case MoveType.Upgrade:
                return message.GetUpgradeMoveData(position, playerId);
            case MoveType.Replace:
                return message.GetReplaceMoveData(position, playerId);
            case MoveType.Remove:
                return message.GetRemoveMoveData(position, playerId);
            case MoveType.Capture:
                return message.GetCaptureMoveData(position, playerId);
            default:
                throw new ArgumentException("Unfamiliar MoveType: " + moveType);
        }
    }

    private static PlaceMoveData GetPlaceMoveData(this Message message, Vector2Int position, int playerId)
    {
        var placementType = (PlacementType)message.GetInt();
        return new PlaceMoveData(playerId, position, placementType);
    }
    
    private static UpgradeMoveData GetUpgradeMoveData(this Message message, Vector2Int position, int playerId)
    {
        return new UpgradeMoveData(playerId, position);
    }
    
    private static ReplaceMoveData GetReplaceMoveData(this Message message, Vector2Int position, int playerId)
    {
        var replacementType = (PlacementType)message.GetInt();
        return new ReplaceMoveData(playerId, position, replacementType);
    }
    
    private static RemoveMoveData GetRemoveMoveData(this Message message, Vector2Int position, int playerId)
    {
        return new RemoveMoveData(playerId, position);
    }
    
    private static CaptureMoveData GetCaptureMoveData(this Message message, Vector2Int position, int playerId)
    {
        return new CaptureMoveData(playerId, position);
    }
}