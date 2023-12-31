using castledice_game_logic.Math;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class GeneralMessageExtensionsTests
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
    
    [Fact]
    public void AddTimeSpan_ShouldAddTimeSpanToMessage()
    {
        var message = GetEmptyMessage();
        var sentTimeSpan = new TimeSpan(new Random().Next());
        
        message.AddTimeSpan(sentTimeSpan);
        var retrievedTimeSpan = message.GetTimeSpan();
        
        Assert.Equal(sentTimeSpan, retrievedTimeSpan);
    }
}