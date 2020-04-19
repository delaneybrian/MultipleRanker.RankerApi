using System;

namespace MultipleRanker.RankerApi.Interfaces
{
    public interface ISerializer
    {
        string Serialize(object obj);

        T Deserialize<T>(string content);

        object Deserialize(Type type, string content);
    }
}
