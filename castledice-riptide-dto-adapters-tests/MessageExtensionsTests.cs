using castledice_game_data_logic;
using castledice_game_data_logic.Content;
using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;
namespace castledice_riptide_dto_adapters_tests;

public class MessageExtensionsTests
{
    [Fact]
    public void AddVector2Int_ShouldAddVector2IntToMessage()
    {
        var message = GetEmptyMessage();
        var sentVector = new Vector2Int(1, 2);
        
        message.AddVector2Int(sentVector);
        var receivedVector = message.GetVector2Int();
        
        Assert.Equal(sentVector, receivedVector);
    }

    [Fact]
    public void Add2DBoolArray_ShouldAdd2DBoolArrayToMessage()
    {
        var message = GetEmptyMessage();
        var sentArray = new [,] {{true, false}, {false, true}};
        
        message.Add2DBoolArray(sentArray);
        var receivedArray = message.Get2DBoolArray(sentArray.GetLength(0), sentArray.GetLength(1));

        for (int i = 0; i < sentArray.GetLength(0); i++)
        {
            for (int j = 0; j < sentArray.GetLength(1); j++)
            {
                Assert.Equal(sentArray[i, j], receivedArray[i, j]);
            }
        }       
    }

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

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(0, 1, 2, 3, 4)]
    [InlineData]
    [InlineData(1)]
    public void AddIntList_ShouldAddIntListToMessage(params int[] sentIntegers)
    {
        var message = GetEmptyMessage();
        var sentList = new List<int>(sentIntegers);
        
        message.AddIntList(sentList);
        var retrievedList = message.GetIntList();
        
        Assert.Equal(sentList, retrievedList);
    }

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
            new List<PlayerDeckData>()
        };
    }

    [Fact]
    public void AddGameStartData_ShouldAddGameStartDataToMessage()
    {
        var sentStartData = GetGameStartData();
        var message = GetEmptyMessage();
        
        message.AddGameStartData(sentStartData);
        var retrievedStartData = message.GetGameStartData();
        
        Assert.Equal(sentStartData, retrievedStartData);
    }
}