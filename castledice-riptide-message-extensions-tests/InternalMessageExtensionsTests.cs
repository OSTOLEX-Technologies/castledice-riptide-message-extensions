using castledice_game_data_logic;
using castledice_game_data_logic.Content.Generated;
using castledice_game_data_logic.Content.Placeable;
using castledice_game_logic.GameObjects;
using castledice_game_logic.Math;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;
namespace castledice_riptide_dto_adapters_tests;

public class InternalMessageExtensionsTests
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
    [MemberData(nameof(AddGeneratedContentDataTestCases))]
    public void AddGeneratedContentData_ShouldAddGeneratedContentDataToMessage(GeneratedContentData sentData)
    {
        var message = GetEmptyMessage();
        
        message.AddGeneratedContentData(sentData);
        var retrievedData = message.GetContentData();
        
        Assert.Equal(sentData, retrievedData);
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

    [Theory]
    [MemberData(nameof(AddGeneratedContentDataListTestCases))]
    public void AddGeneratedContentDataList_ShouldAddGeneratedContentDataListToMessage(List<GeneratedContentData> sentList)
    {
        var message = GetEmptyMessage();
        
        message.AddGeneratedContentDataList(sentList);
        var retrievedList = message.GetGeneratedContentDataList();
        
        Assert.Equal(sentList, retrievedList);
    }
    
    public static IEnumerable<object[]> AddGeneratedContentDataListTestCases()
    {
        yield return new object[]
        {
            new List<GeneratedContentData>
            {
                GetCastleData(), 
                GetTreeData()
            }
        };
        yield return new object[]
        {
            new List<GeneratedContentData>
            {
                GetCastleData(), 
                GetCastleData()
            }
        };
        yield return new object[]
        {
            new List<GeneratedContentData>
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

    [Fact]
    public void AddGameStartData_ShouldAddGameStartDataToMessage()
    {
        var sentStartData = GetGameStartData();
        var message = GetEmptyMessage();
        
        message.AddGameStartData(sentStartData);
        var retrievedStartData = message.GetGameStartData();
        
        Assert.Equal(sentStartData, retrievedStartData);
    }
    
    
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
    
    [Fact]
    public void AddBoardData_ShouldAddBoardConfigDataToMessage()
    {
        var sentConfigData = GetBoardData();
        var message = GetEmptyMessage();
        
        message.AddBoardData(sentConfigData);
        var retrievedConfigData = message.GetBoardData();
        
        Assert.Equal(sentConfigData, retrievedConfigData);
    }
}