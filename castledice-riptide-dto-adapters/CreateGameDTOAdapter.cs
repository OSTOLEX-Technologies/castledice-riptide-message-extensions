using casltedice_events_logic.ServerToClient;
using castledice_riptide_dto_adapters.Extensions;
using Riptide;

namespace castledice_riptide_dto_adapters;

public class CreateGameDTOAdapter : IMessageSerializable
{
    public CreateGameDTO? DTO { get; set; }

    public void Serialize(Message message)
    {
        if (DTO is null)
        {
            throw new ArgumentException("Cannot serialize DTO because it is null.");
        }
        message.AddGameStartData(DTO.GameStartData);
    }

    public void Deserialize(Message message)
    {
        var gameStartData = message.GetGameStartData();
        DTO = new CreateGameDTO(gameStartData);
    }
}