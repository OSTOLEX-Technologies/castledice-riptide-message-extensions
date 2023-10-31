using castledice_game_data_logic.Moves;
using castledice_riptide_dto_adapters.Extensions;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters;

public class MoveDataAdder : IMoveDataVisitor<int>
{
    private readonly Message _message;

    internal MoveDataAdder(Message message)
    {
        _message = message;
    }
    
    internal void AddMoveData(MoveData data)
    {
        _message.AddInt((int)data.MoveType);
        _message.AddVector2Int(data.Position);
        _message.AddInt(data.PlayerId);
        data.Accept(this);
    }

    public int VisitRemoveMoveData(RemoveMoveData data)
    {
        return 1;
    }

    public int VisitPlaceMoveData(PlaceMoveData data)
    {
        _message.AddInt((int)data.PlacementType);
        return 1;
    }

    public int VisitUpgradeMoveData(UpgradeMoveData data)
    {
        return 1;
    }

    public int VisitReplaceMoveData(ReplaceMoveData data)
    {
        _message.AddInt((int)data.ReplacementType);
        return 1;
    }

    public int VisitCaptureMoveData(CaptureMoveData data)
    {
        return 1;
    }
}