using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class BoardDataMessageExtensionsTests
{
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