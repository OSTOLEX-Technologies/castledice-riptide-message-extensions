using castledice_game_data_logic.TurnSwitchConditions;
using castledice_game_logic.TurnsLogic.TurnSwitchConditions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class TscDataMessageExtensionsTests
{
    [Fact]
    public void AddTscConfigData_ShouldAddTscConfigDataToMessage()
    {
        var message = GetEmptyMessage();
        var tscTypes = new List<TscType> { TscType.SwitchByActionPoints };
        var tscConfigData = new TscConfigData(tscTypes);
        
        message.AddTscConfigData(tscConfigData);
        
        Assert.Equal(tscConfigData, message.GetTscConfigData());
    }
}