using castledice_game_data_logic.Content;
using castledice_riptide_dto_adapters;
using castledice_riptide_dto_adapters.Extensions;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class ContentDataAdderTests
{
    [Theory]
    [MemberData(nameof(AddContentDataTestCases))]
    public void AddContentData_ShouldAddContentDataToMessage(ContentData addedData)
    {
        var message = GetEmptyMessage();
        var contentDataAdder = new ContentDataAdder(message);
        
        contentDataAdder.AddContentData(addedData);
        var retrievedData = message.GetContentData();
        
        Assert.Equal(addedData, retrievedData);
    }

    public static IEnumerable<object[]> AddContentDataTestCases()
    {
        yield return new object[]
        {
            GetCastleData()
        };
        yield return new object[]
        {
            GetTreeData()
        };
        yield return new object[]
        {
            GetKnightData()
        };
    }
}