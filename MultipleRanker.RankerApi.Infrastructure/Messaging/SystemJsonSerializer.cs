using System;
using System.Text.Json;
using MultipleRanker.RankerApi.Interfaces;


namespace MultipleRanker.RankerApi.Infrastructure.Messaging
{
    public class SystemJsonSerializer : ISerializer
    {
        public string Serialize(object obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public T Deserialize<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content);
        }

        public object Deserialize(Type type, string content)
        {
            return JsonSerializer.Deserialize(content, type);
        }
    }
}
