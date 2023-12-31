using castledice_events_logic.ServerToClient;
using castledice_events_logic.ClientToServer;
using castledice_riptide_dto_adapters.DataAdders;
using castledice_riptide_dto_adapters.Extensions.InternalExtensions;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions;

public static class MessageExtensions
{
    public static void AddSwitchTimerDTO(this Message message, SwitchTimerDTO dto)
    {
        message.AddInt(dto.PlayerId);
        message.AddTimeSpan(dto.TimeLeft);
        message.AddBool(dto.Switch);
    }
    
    public static SwitchTimerDTO GetSwitchTimerDTO(this Message message)
    {
        var playerId = message.GetInt();
        var timeLeft = message.GetTimeSpan();
        var switchTimer = message.GetBool();
        return new SwitchTimerDTO(timeLeft, playerId, switchTimer);
    }
    
    public static void AddInitializePlayerDTO(this Message message, InitializePlayerDTO dto)
    {
        message.AddString(dto.VerificationKey);
    }

    public static InitializePlayerDTO GetInitializePlayerDTO(this Message message)
    {
        return new InitializePlayerDTO(message.GetString());
    }

    public static void AddCancelGameDTO(this Message message, CancelGameDTO dto)
    {
        message.AddString(dto.VerificationKey);
    }

    public static CancelGameDTO GetCancelGameDTO(this Message message)
    {
        return new CancelGameDTO(message.GetString());
    }

    public static void AddCancelGameResultDTO(this Message message, CancelGameResultDTO dto)
    {
        message.AddBool(dto.IsCanceled);
        message.AddInt(dto.PlayerId);
    }

    public static CancelGameResultDTO GetCancelGameResultDTO(this Message message)
    {
        return new CancelGameResultDTO(message.GetBool(), message.GetInt());
    }

    public static void AddCreateGameDTO(this Message message, CreateGameDTO dto)
    {
        message.AddGameStartData(dto.GameStartData);
    }

    public static CreateGameDTO GetCreateGameDTO(this Message message)
    {
        var startData = message.GetGameStartData();
        return new CreateGameDTO(startData);
    }

    public static void AddRequestGameDTO(this Message message, RequestGameDTO dto)
    {
        message.AddString(dto.VerificationKey);
    }

    public static RequestGameDTO GetRequestGameDTO(this Message message)
    {
        var verificationKey = message.GetString();
        return new RequestGameDTO(verificationKey);
    }

    public static void AddMatchFoundDTO(this Message message, MatchFoundDTO dto)
    {
        message.AddIntList(dto.PlayerIds);
    }

    public static MatchFoundDTO GetMatchFoundDTO(this Message message)
    {
        var playerIds = message.GetIntList();
        return new MatchFoundDTO(playerIds);
    }

    public static void AddMoveFromClientDTO(this Message message, MoveFromClientDTO dto)
    {
        var moveDataAdder = new MoveDataAdder(message);
        message.AddString(dto.VerificationKey);
        moveDataAdder.AddData(dto.MoveData);
    }

    public static MoveFromClientDTO GetMoveFromClientDTO(this Message message)
    {
        var verificationKey = message.GetString();
        var moveData = message.GetMoveData();
        return new MoveFromClientDTO(moveData, verificationKey);
    }

    public static void AddMoveFromServerDTO(this Message message, MoveFromServerDTO dto)
    {
        var moveDataAdder = new MoveDataAdder(message);
        moveDataAdder.AddData(dto.MoveData);
    }

    public static MoveFromServerDTO GetMoveFromServerDTO(this Message message)
    {
        var moveData = message.GetMoveData();
        return new MoveFromServerDTO(moveData);
    }

    public static void AddApproveMoveDTO(this Message message, ApproveMoveDTO dto)
    {
        message.AddBool(dto.IsMoveValid);
    }

    public static ApproveMoveDTO GetApproveMoveDTO(this Message message)
    {
        var isMoveValid = message.GetBool();
        return new ApproveMoveDTO(isMoveValid);
    }

    public static void AddGiveActionPointsDTO(this Message message, GiveActionPointsDTO dto)
    {
        message.AddInt(dto.PlayerId);
        message.AddInt(dto.Amount);
    }

    public static GiveActionPointsDTO GetGiveActionPointsDTO(this Message message)
    {
        var playerId = message.GetInt();
        var amount = message.GetInt();
        return new GiveActionPointsDTO(playerId, amount);
    }

    public static void AddPlayerReadyDTO(this Message message, PlayerReadyDTO dto)
    {
        message.AddString(dto.VerificationKey);
    }

    public static PlayerReadyDTO GetPlayerReadyDTO(this Message message)
    {
        var verificationKey = message.GetString();
        return new PlayerReadyDTO(verificationKey);
    }
    
    public static void AddServerErrorDTO(this Message message, ServerErrorDTO dto)
    {
        message.AddErrorData(dto.ErrorData);
    }
    
    public static ServerErrorDTO GetServerErrorDTO(this Message message)
    {
        var errorData = message.GetErrorData();
        return new ServerErrorDTO(errorData);
    }
}