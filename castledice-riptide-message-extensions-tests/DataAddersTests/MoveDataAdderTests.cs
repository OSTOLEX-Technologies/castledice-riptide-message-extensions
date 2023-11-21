using castledice_game_data_logic.Moves;
using castledice_riptide_dto_adapters;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class MoveDataAdderTests
{
    [Theory]
    [MemberData(nameof(MoveDataCases))]
    public void AddData_ShouldAddGivenMoveDataToMessage(MoveData addedData)
    {
        var message = GetEmptyMessage();
        var moveDataAdder = new MoveDataAdder(message);

        moveDataAdder.AddData(addedData);
        var retrievedData = message.GetMoveData();

        Assert.Equal(addedData, retrievedData);
    }

    public static IEnumerable<object[]> MoveDataCases()
    {
        yield return new[]
        {
            GetCaptureMoveData()
        };
        yield return new[]
        {
            GetPlaceMoveData()
        };
        yield return new[]
        {
            GetRemoveMoveData()
        };
        yield return new[]
        {
            GetReplaceMoveData()
        };
        yield return new[]
        {
            GetUpgradeMoveData()
        };
    }

}