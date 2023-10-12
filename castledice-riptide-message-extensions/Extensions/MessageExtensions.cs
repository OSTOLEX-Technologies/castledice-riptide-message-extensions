using casltedice_events_logic.ClientToServer;
using casltedice_events_logic.ServerToClient;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions;

public static class MessageExtensions
{
    public static void AddInitializeClientDTO(this Message message, InitializePlayerDTO dto)
    {
        message.AddString(dto.VerificationKey);
    }

    public static InitializePlayerDTO GetInitializeClientDTO(this Message message)
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
    }

    public static CancelGameResultDTO GetCancelGameResultDTO(this Message message)
    {
        return new CancelGameResultDTO(message.GetBool());
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
    
    public static MatchFoundDTO  GetMatchFoundDTO(this Message message)
    {
        var playerIds = message.GetIntList();
        return new MatchFoundDTO(playerIds);
    }
}