using casltedice_events_logic.ServerToClient;
using castledice_riptide_dto_adapters;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class CreateGameDTOAdapterTests
{
    [Fact]
    public void Serialize_ShouldThrowArgumentException_IfDTOIsNull()
    {
        var adapter = new CreateGameDTOAdapter();
        var message = GetEmptyMessage();
        
        Assert.Throws<ArgumentException>(() => adapter.Serialize(message));
    }
    
    [Fact]
    public void DeserializingDTOFromMessage_ShouldGiveDTOWithSameProperties()
    {
        var DTOToSend = new CreateGameDTO(GetGameStartData());
        var message = GetEmptyMessage();
        var sentAdapter = new CreateGameDTOAdapter()
        {
            DTO = DTOToSend
        };
        
        message.AddSerializable(sentAdapter);
        var receivedAdapter = message.GetSerializable<CreateGameDTOAdapter>();
        var receivedDTO = receivedAdapter.DTO;
        
        Assert.Equal(DTOToSend.GameStartData, receivedDTO.GameStartData);
    }
}