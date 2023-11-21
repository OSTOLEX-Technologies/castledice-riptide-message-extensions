using castledice_game_data_logic.TurnSwitchConditions;
using Riptide;

namespace castledice_riptide_dto_adapters;

public class TscDataAdder : DataAdder<TscData>, ITscDataVisitor<int>
{
    public TscDataAdder(Message message) : base(message) {}

    internal override void AddData(TscData data)
    {
        throw new NotImplementedException();
    }

    public int VisitActionPointsConditionData(ActionPointsConditionData data)
    {
        throw new NotImplementedException();
    }

    public int VisitTimeConditionData(TimeConditionData data)
    {
        throw new NotImplementedException();
    }
}