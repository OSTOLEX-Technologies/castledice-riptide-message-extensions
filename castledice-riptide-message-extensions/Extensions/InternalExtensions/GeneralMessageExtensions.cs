using System.Runtime.CompilerServices;
using castledice_game_logic.Math;
using Riptide;

[assembly: InternalsVisibleTo("castledice-riptide-message-extensions-tests")]
namespace castledice_riptide_dto_adapters.Extensions.InternalExtensions;

internal static class GeneralMessageExtensions
{
    internal static void AddIntList(this Message message, List<int> list)
    {
        AddList(message, list, (mes, num) => { mes.AddInt(num);});
    }

    internal static List<int> GetIntList(this Message message)
    {
        return GetList(message, mes => mes.GetInt());
    }

    internal static void AddList<T>(Message message, List<T> list, Action<Message, T> addFunction)
    {
        message.AddInt(list.Count);
        foreach (var item in list)
        {
            addFunction(message, item);
        }
    }

    internal static List<T> GetList<T>(Message message, Func<Message, T> getFunction)
    {
        var itemsCount = message.GetInt();
        var list = new List<T>();
        for (int i = 0; i < itemsCount; i++)
        {
            list.Add(getFunction(message));
        }
        return list;
    }
    
    internal static void AddVector2Int(this Message message, Vector2Int vector)
    {
        message.AddInt(vector.X);
        message.AddInt(vector.Y);
    }

    internal static Vector2Int GetVector2Int(this Message message)
    {
        var vector = new Vector2Int();
        vector.X = message.GetInt();
        vector.Y = message.GetInt();
        return vector;
    }

    internal static void Add2DBoolArray(this Message message, bool[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                message.AddBool(array[i, j]);
            }
        }
    }

    internal static bool[,] Get2DBoolArray(this Message message, int length, int width)
    {
        var array = new bool[length, width];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = message.GetBool();
            }
        }
        return array;
    }
    
    internal static void AddTimeSpan(this Message message, TimeSpan timeSpan)
    {
        message.AddLong(timeSpan.Ticks);
    }
    
    internal static TimeSpan GetTimeSpan(this Message message)
    {
        return new TimeSpan(message.GetLong());
    }
}