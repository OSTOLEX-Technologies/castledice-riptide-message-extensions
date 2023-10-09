using casltedice_events_logic.ClientToServer;
using casltedice_events_logic.ServerToClient;
using castledice_riptide_dto_adapters;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

//Important note: in this tests before retrieving data from message we use GetByte method twice.
//It is done like this because there is some default message data in these first two bytes.
public class RequestGameDTOAdapterTests
{
    [Fact]
    public void Serialize_ShouldThrowArgumentException_IfDTOIsNull()
    {
        var adapter = new RequestGameDTOAdapter();
        var message = GetEmptyMessage();
        
        Assert.Throws<ArgumentException>(() => adapter.Serialize(message));
    }
    
    [Fact]
    public void DeserializingDTOFromMessage_ShouldGiveDTOWithSameProperties()
    {
        var key = "somekey";
        var DTOToSend = new RequestGameDTO(key);
        var message = GetEmptyMessage();
        var sentAdapter = new RequestGameDTOAdapter()
        {
            DTO = DTOToSend
        };
        message.AddSerializable(sentAdapter);
        
        var receivedAdapter = message.GetSerializable<RequestGameDTOAdapter>();
        var receivedDTO = receivedAdapter.DTO;
        
        Assert.Equal(DTOToSend.VerificationKey, receivedDTO.VerificationKey);
    }
}