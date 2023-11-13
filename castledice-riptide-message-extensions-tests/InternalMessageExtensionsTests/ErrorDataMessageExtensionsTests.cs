using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class ErrorDataMessageExtensionsTests
{
    [Fact]
    public void AddErrorData_ShouldAddErrorDataToMessage()
    {
        var sentErrorData = GetErrorData();
        var message = GetEmptyMessage();
        
        message.AddErrorData(sentErrorData);
        var retrievedErrorData = message.GetErrorData();
        
        Assert.Equal(sentErrorData, retrievedErrorData);
    }
}