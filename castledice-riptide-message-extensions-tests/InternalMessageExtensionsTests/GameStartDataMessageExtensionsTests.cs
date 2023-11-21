using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class GameStartDataMessageExtensionsTests
{
    
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