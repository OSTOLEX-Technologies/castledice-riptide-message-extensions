﻿using casltedice_events_logic.ClientToServer;
using casltedice_events_logic.ServerToClient;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions;

public static class MessageExtensions
{
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
}