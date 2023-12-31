using castledice_riptide_dto_adapters.Extensions.InternalExtensions;

namespace castledice_riptide_dto_adapters_tests.InternalMessageExtensionsTests;

public class PlayerDataMessageExtensionsTests
{
    [Fact]
    public void AddPlayerData_ShouldAddPlayerDataToMessage()
    {
        var message = GetEmptyMessage();
        var playerData = GetPlayerData();
        
        message.AddPlayerData(playerData);
        var retrievedData = message.GetPlayerData();
        
        Assert.Equal(playerData, retrievedData);
    }
    
    [Fact]
    public void AddPlacementType_ShouldAddPlacementTypeToMessage()
    {
        var message = GetEmptyMessage();
        var placementType = GetRandomPlacementType();
        
        message.AddPlacementType(placementType);
        var retrievedPlacementType = message.GetPlacementType();
        
        Assert.Equal(placementType, retrievedPlacementType);
    }
    
    [Fact]
    public void AddPlacementTypeList_ShouldAddPlacementTypeListToMessage()
    {
        var message = GetEmptyMessage();
        var placementTypes = GetRandomPlacementTypeList();
        
        message.AddPlacementTypeList(placementTypes);
        var retrievedPlacementTypes = message.GetPlacementTypeList();
        
        Assert.Equal(placementTypes, retrievedPlacementTypes);
    }
    
    [Fact]
    public void AddPlayerDataList_ShouldAddPlayerDataListToMessage()
    {
        var message = GetEmptyMessage();
        var playerDataList = GetRandomPlayerDataList();
        
        message.AddPlayerDataList(playerDataList);
        var retrievedPlayerDataList = message.GetPlayerDataList();
        
        Assert.Equal(playerDataList, retrievedPlayerDataList);
    }
}