using casltedice_events_logic.ClientToServer;
using Riptide;

namespace castledice_riptide_dto_adapters;

public class RequestGameDTOAdapter : IMessageSerializable
{
    public RequestGameDTO? DTO { get; set; }
    
    public void Serialize(Message message)
    {
        if (DTO is null)
        {
            throw new ArgumentException("Cannot serialize DTO because it is null.");
        }
        message.AddString(DTO.VerificationKey);
    }

    public void Deserialize(Message message)
    {
        var verificationKey = message.GetString();
        DTO = new RequestGameDTO(verificationKey);
    }
}