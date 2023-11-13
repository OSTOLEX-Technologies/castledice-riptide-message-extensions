using castledice_game_data_logic.Errors;
using Riptide;

namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

public static class ErrorDataMessageExtensions
{
    public static void AddErrorData(this Message message, ErrorData data)
    {
        message.AddInt((int)data.ErrorType);
        message.AddString(data.Message);
    }
    
    public static ErrorData GetErrorData(this Message message)
    {
        var errorType = (ErrorType)message.GetInt();
        var errorMessage = message.GetString();
        return new ErrorData(errorType, errorMessage);
    }
}