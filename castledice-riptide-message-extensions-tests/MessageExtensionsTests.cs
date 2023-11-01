using casltedice_events_logic.ClientToServer;
using casltedice_events_logic.ServerToClient;
using castledice_game_data_logic.Moves;
using castledice_riptide_dto_adapters.Extensions;
using static castledice_riptide_dto_adapters_tests.ObjectCreationUtility;

namespace castledice_riptide_dto_adapters_tests;

public class MessageExtensionsTests
{
    [Fact]
    public void AddInitializePlayerDTO_ShouldAddInitializePlayerDTOToMessage()
    {
        var DTOToSend = new InitializePlayerDTO("somekey");
        var message = GetEmptyMessage();
        
        message.AddInitializePlayerDTO(DTOToSend);
        var receivedDTO = message.GetInitializePlayerDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }
    
    [Fact]
    public void AddCancelGameDTO_ShouldAddCancelGameDTOToMessage()
    {
        var DTOToSend = new CancelGameDTO("somekey");
        var message = GetEmptyMessage();
        
        message.AddCancelGameDTO(DTOToSend);
        var receivedDTO = message.GetCancelGameDTO();
        
        Assert.Equal(DTOToSend, receivedDTO); 
    }
    
    [Fact]
    public void AddCancelGameResultDTO_ShouldAddCancelGameResultDTOToMessage()
    {
        var DTOToSend = new CancelGameResultDTO(true, 1);
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

    [Theory]
    [MemberData(nameof(MoveDataCases))]
    public void AddMoveFromClientDTO_ShouldAddMoveFromClientDTOToMessage(MoveData moveData)
    {
        var DTOToSend = GetMoveFromClientDTO(moveData);
        var message = GetEmptyMessage();
        
        message.AddMoveFromClientDTO(DTOToSend);
        var receivedDTO = message.GetMoveFromClientDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }

    [Theory]
    [MemberData(nameof(MoveDataCases))]
    public void AddMoveFromServerDTO_ShouldAddMoveFromServerDTOToMessage(MoveData moveData)
    {
        var DTOToSend = GetMoveFromServerDTO(moveData);
        var message = GetEmptyMessage();
        
        message.AddMoveFromServerDTO(DTOToSend);
        var receivedDTO = message.GetMoveFromServerDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }

    public static IEnumerable<object[]> MoveDataCases()
    {
        yield return new[]
        {
            GetRemoveMoveData()
        };
        yield return new[]
        {
            GetCaptureMoveData()
        };
        yield return new[]
        {
            GetPlaceMoveData()
        };
        yield return new[]
        {
            GetReplaceMoveData()
        };
        yield return new[]
        {
            GetUpgradeMoveData()
        };
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void AddApproveMoveDTO_ShouldAddApproveMoveDTOToMessage(bool isMoveValid)
    {
        var DTOToSend = new ApproveMoveDTO(isMoveValid);
        var message = GetEmptyMessage();
        
        message.AddApproveMoveDTO(DTOToSend);
        var receivedDTO = message.GetApproveMoveDTO();
        
        Assert.Equal(DTOToSend, receivedDTO);
    }
}