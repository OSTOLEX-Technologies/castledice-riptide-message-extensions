using castledice_game_data_logic.Content;
using castledice_game_data_logic.Content.Generated;
using castledice_game_data_logic.Content.Placeable;
using castledice_riptide_dto_adapters;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class ContentDataAdderTests
{
    [Theory]
    [MemberData(nameof(GeneratedContentDataTestCases))]
    public void AddGeneratedContentData_ShouldAddGeneratedContentDataToMessage(GeneratedContentData addedData)
    {
        var message = GetEmptyMessage();
        var contentDataAdder = new ContentDataAdder(message);
        
        contentDataAdder.AddGeneratedContentData(addedData);
        var retrievedData = message.GetGeneratedContentData();
        
        Assert.Equal(addedData, retrievedData);
    }

    public static IEnumerable<object[]> GeneratedContentDataTestCases()
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
    [MemberData(nameof(PlaceableContentDataTestCases))]
    public void AddPlaceableContentData_ShouldAddPlaceableContentDataToMessage(PlaceableContentData addedData)
    {
        var message = GetEmptyMessage();
        var contentDataAdder = new ContentDataAdder(message);
        
        contentDataAdder.AddPlaceableContentData(addedData);
        var retrievedData = message.GetPlaceableContentData();
        
        Assert.Equal(addedData, retrievedData);
    }
    
    public static IEnumerable<object[]> PlaceableContentDataTestCases()
    {
        yield return new object[]
        {
            GetKnightData()
        };
    }
}