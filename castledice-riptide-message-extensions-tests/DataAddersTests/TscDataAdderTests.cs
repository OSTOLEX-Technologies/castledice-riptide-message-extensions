using castledice_game_data_logic.TurnSwitchConditions;
using castledice_riptide_dto_adapters;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class TscDataAdderTests
{
    [Theory]
    [MemberData(nameof(TscDataCases))]
    public void AddData_ShouldAddGivenTscDataToMessage(TscData data)
    {
        var message = GetEmptyMessage();
        var tscDataAdder = new TscDataAdder(message);
        
        tscDataAdder.AddData(data);
        
        Assert.Equal(data, message.GetTscData());
    }
    
    public static IEnumerable<object[]> TscDataCases()
    {
        yield return new[]
        {
            GetActionPointsConditionData()
        };
        yield return new[]
        {
            GetTimeConditionData()
        };
    }
}