using castledice_game_data_logic.TurnSwitchConditions;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class TscDataMessageExtensionsTests
{
    [Theory]
    [MemberData(nameof(TscDataCases))]
    public void AddTscData_ShouldAddGivenTscDataToMessage(TscData data)
    {
        var message = GetEmptyMessage();
        
        message.AddTscData(data);
        var retrievedData = message.GetTscData();
        
        Assert.Equal(data, retrievedData);
    }

    public static IEnumerable<object[]> TscDataCases()
    {
        yield return new object[]
        {
            GetActionPointsConditionData()
        };
        yield return new object[]
        {
            GetTimeConditionData()
        };
    }

    [Theory]
    [MemberData(nameof(TscDataListCases))]
    public void AddTscDataList_ShouldAddGivenListToMessage(List<TscData> dataList)
    {
        var message = GetEmptyMessage();
        
        message.AddTscDataList(dataList);
        var retrievedList = message.GetTscDataList();
        
        Assert.Equal(dataList, retrievedList);
    }

    public static IEnumerable<object[]> TscDataListCases()
    {
        yield return new object[]
        {
            new List<TscData> { GetActionPointsConditionData(), GetTimeConditionData() },
        };
        yield return new object[]
        {
            new List<TscData> { GetActionPointsConditionData(), GetTimeConditionData(125), GetActionPointsConditionData() },
        };
        yield return new object[]
        {
            new List<TscData> { GetTimeConditionData() }
        };
    }
}