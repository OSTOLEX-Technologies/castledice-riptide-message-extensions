using castledice_game_data_logic.Content.Generated;
using castledice_riptide_dto_adapters;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class GeneratedContentDataAdderTests
{
    [Theory]
    [MemberData(nameof(AddGeneratedContentDataTestCases))]
    public void AddGeneratedContentData_ShouldAddGeneratedContentDataToMessage(GeneratedContentData addedData)
    {
        var message = GetEmptyMessage();
        var contentDataAdder = new GeneratedContentDataAdder(message);
        
        contentDataAdder.AddGeneratedContentData(addedData);
        var retrievedData = message.GetContentData();
        
        Assert.Equal(addedData, retrievedData);
    }

    public static IEnumerable<object[]> AddGeneratedContentDataTestCases()
    {
        yield return new object[]
        {
            GetCastleData()
        };
        yield return new object[]
        {
            GetTreeData()
        };
    }
}