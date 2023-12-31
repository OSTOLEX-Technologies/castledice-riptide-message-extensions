﻿using castledice_game_data_logic.Content;
using castledice_riptide_dto_adapters.Extensions;
using Riptide;

namespace castledice_riptide_dto_adapters;

/// <summary>
/// This class adds content data to a message.
/// </summary>
internal class ContentDataAdder : IContentDataVisitor<int>
{
    private readonly Message _message;

    internal ContentDataAdder(Message message)
    {
        _message = message;
    }

    internal void AddContentData(ContentData data)
    {
        _message.AddVector2Int(data.Position);
        _message.AddInt((int)data.Type);
        data.Accept(this);
    }
    
    public int VisitCastleData(CastleData data)
    {
        _message.AddInt(data.CastleCaptureHitCost);
        _message.AddInt(data.FreeDurability);
        _message.AddInt(data.DefaultDurability);
        _message.AddInt(data.Durability);
        _message.AddInt(data.OwnerId);
        return 0;
    }

    public int VisitTreeData(TreeData data)
    {
        _message.AddInt(data.RemoveCost);
        _message.AddBool(data.CanBeRemoved);
        return 0;
    }
}