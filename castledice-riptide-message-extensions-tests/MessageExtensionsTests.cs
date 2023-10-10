using casltedice_events_logic.ClientToServer;
using casltedice_events_logic.ServerToClient;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class MessageExtensionsTests
{
    [Fact]
    public void AddCancelGameResultDTO_ShouldAddCancelGameResultDTOToMessage()
    {
        var DTOToSend = new CancelGameResultDTO(true);
        var message = GetEmptyMessage();
        
        message.AddCancelGameResultDTO(DTOToSend);
        var receivedDTO = message.GetCancelGameResultDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }
    
    [Fact]
    public void AddCreateGameDTO_ShouldAddCreateGameDTOToMessage()
    {
        var DTOToSend = new CreateGameDTO(GetGameStartData());
        var message = GetEmptyMessage();
        
        message.AddCreateGameDTO(DTOToSend);
        var receivedDTO = message.GetCreateGameDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }
    
    [Fact]
    public void AddRequestGameDTO_ShouldAddRequestGameDTOToMessage()
    {
        var DTOToSend = new RequestGameDTO("somekey");
        var message = GetEmptyMessage();
        
        message.AddRequestGameDTO(DTOToSend);
        var receivedDTO = message.GetRequestGameDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }

    [Fact]
    public void AddMatchFoundDTO_ShouldAddMatchFoundDTOToMessage()
    {
        var DTOToSend = new MatchFoundDTO(new List<int>(){3, 5});
        var message = GetEmptyMessage();
        
        message.AddMatchFoundDTO(DTOToSend);
        var receivedDTO = message.GetMatchFoundDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }
}