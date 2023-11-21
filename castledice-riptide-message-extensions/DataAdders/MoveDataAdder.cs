using castledice_game_data_logic.Moves;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters;

public class MoveDataAdder : DataAdder<MoveData>, IMoveDataVisitor<int>
{
    internal MoveDataAdder(Message message) : base(message) {}
    
    internal override void AddData(MoveData data)
    {
        Message.AddInt((int)data.MoveType);
        Message.AddVector2Int(data.Position);
        Message.AddInt(data.PlayerId);
        data.Accept(this);
    }

    public int VisitRemoveMoveData(RemoveMoveData data)
    {
        return 1;
    }

    public int VisitPlaceMoveData(PlaceMoveData data)
    {
        Message.AddInt((int)data.PlacementType);
        return 1;
    }

    public int VisitUpgradeMoveData(UpgradeMoveData data)
    {
        return 1;
    }

    public int VisitReplaceMoveData(ReplaceMoveData data)
    {
        Message.AddInt((int)data.ReplacementType);
        return 1;
    }

    public int VisitCaptureMoveData(CaptureMoveData data)
    {
        return 1;
    }
}