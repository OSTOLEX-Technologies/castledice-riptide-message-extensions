using castledice_game_data_logic;
using castledice_game_logic.GameObjects;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class PlayerDeckDataMessageExtensionsTests
{
    [Theory]
    [MemberData(nameof(AddPlayerDeckDataTestCases))]
    public void AddPlayerDeckData_ShouldAddPlayerDeckDataToMessage(PlayerDeckData sentData)
    {
        var message = GetEmptyMessage();
        
        message.AddPlayerDeckData(sentData);
        var retrievedData = message.GetPlayerDeckData();
        
        Assert.Equal(sentData, retrievedData);
    }
    
    public static IEnumerable<object[]> AddPlayerDeckDataTestCases()
    {
        yield return new object[]
        {
            new PlayerDeckData(1, new List<PlacementType>{ PlacementType.Knight })
        };
        yield return new object[]
        {
            new PlayerDeckData(3, new List<PlacementType>{ PlacementType.Knight, PlacementType.Bridge })
        };
    }
    
    [Theory]
    [MemberData(nameof(AddPlayerDeckDataListTestCases))]
    public void AddPlayerDeckDataList_ShouldAddPlayerDeckDataListToMessage(List<PlayerDeckData> sentList)
    {
        var message = GetEmptyMessage();
        
        message.AddPlayerDeckDataList(sentList);
        var retrievedList = message.GetPlayerDeckDataList();
        
        Assert.Equal(sentList, retrievedList);
    }

    public static IEnumerable<object[]> AddPlayerDeckDataListTestCases()
    {
        yield return new object[]
        {
            new List<PlayerDeckData>
            {
                new (1, new List<PlacementType>{ PlacementType.Knight }),
                new (3, new List<PlacementType>{ PlacementType.Knight, PlacementType.Bridge })
            }
        };
        yield return new object[]
        {
            new List<PlayerDeckData>
            {
                new (3, new List<PlacementType>{ PlacementType.Knight, PlacementType.Bridge })
            }
        };
        yield return new object[]
        {
            new List<PlayerDeckData>
            {
                new (1, new List<PlacementType>{ PlacementType.Knight })
            }
        };
        yield return new object[]
        {
            new List<PlayerDeckData>()
        };
    }
}