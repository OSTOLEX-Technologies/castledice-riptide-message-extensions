using castledice_game_data_logic.TurnSwitchConditions;
using Riptide;

namespace castledice_riptide_dto_adapters;

public class TscDataAdder : DataAdder<TscData>, ITscDataVisitor<int>
{
    public TscDataAdder(Message message) : base(message) {}

    internal override void AddData(TscData data)
    {
        Message.AddInt((int)data.Type);
        data.Accept(this);
    }

    public int VisitActionPointsConditionData(ActionPointsConditionData data)
    {
        return 1;
    }

    public int VisitTimeConditionData(TimeConditionData data)
    {
        Message.AddInt(data.TurnDuration);
        return 1;
    }
}