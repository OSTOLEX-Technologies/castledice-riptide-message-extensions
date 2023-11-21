using castledice_game_data_logic.Content;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class ContentDataMessageExtensionsTests
{
    [Theory]
    [MemberData(nameof(AddContentDataTestCases))]
    public void AddContentData_ShouldAddContentDataToMessage(ContentData sentData)
    {
        var message = GetEmptyMessage();
        
        message.AddContentData(sentData);
        var retrievedData = message.GetContentData();
        
        Assert.Equal(sentData, retrievedData);
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
    }

    [Theory]
    [MemberData(nameof(AddContentDataListTestCases))]
    public void AddContentDataList_ShouldAddContentDataListToMessage(List<ContentData> sentList)
    {
        var message = GetEmptyMessage();
        
        message.AddContentDataList(sentList);
        var retrievedList = message.GetContentDataList();
        
        Assert.Equal(sentList, retrievedList);
    }
    
    public static IEnumerable<object[]> AddContentDataListTestCases()
    {
        yield return new object[]
        {
            new List<ContentData>
            {
                GetCastleData(), 
                GetTreeData()
            }
        };
        yield return new object[]
        {
            new List<ContentData>
            {
                GetCastleData(), 
                GetCastleData()
            }
        };
        yield return new object[]
        {
            new List<ContentData>
            {
                GetCastleData(),
                GetTreeData(),
                GetTreeData(),
                GetTreeData(),
                GetCastleData()
            }
        };
    }
}