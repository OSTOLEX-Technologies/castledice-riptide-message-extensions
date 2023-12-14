using castledice_game_data_logic.ConfigsData;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class PlaceablesConfigsMessageExtensionsTests
{
    [Theory]
    [MemberData(nameof(KnightConfigDataTestCases))]
    public void AddKnightConfigData_ShouldAddKnightConfigDataToMessage(KnightConfigData sentConfigData)
    {
        var message = GetEmptyMessage();
        
        message.AddKnightConfigData(sentConfigData);
        var retrievedConfigData = message.GetKnightConfigData();
        
        Assert.Equal(sentConfigData, retrievedConfigData);
    }

    public static IEnumerable<object[]> KnightConfigDataTestCases()
    {
        yield return new object[]
        {
            new KnightConfigData(1, 2)
        };
        yield return new object[]
        {
            new KnightConfigData(3, 4)
        };
    }
    
    [Theory]
    [MemberData(nameof(PlaceablesConfigDataTestCases))]
    public void AddPlaceablesConfigData_ShouldAddPlaceablesConfigDataToMessage(PlaceablesConfigData sentConfigData)
    {
        var message = GetEmptyMessage();
        
        message.AddPlaceablesConfigData(sentConfigData);
        var retrievedConfigData = message.GetPlaceablesConfigData();
        
        Assert.Equal(sentConfigData, retrievedConfigData);
    }
    
    public static IEnumerable<object[]> PlaceablesConfigDataTestCases()
    {
        yield return new object[]
        {
            new PlaceablesConfigData(GetKnightConfigData())
        };
        yield return new object[]
        {
            new PlaceablesConfigData(new KnightConfigData(3, 4))
        };
    }
}