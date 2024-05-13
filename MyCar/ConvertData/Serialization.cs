using MyCar.ConvertData.Interface;
using MyCar.DTOs;
using Newtonsoft.Json;

namespace MyCar.ConvertData
{
    public class Serialization<T> : ISerialization<T> where T : class
    {
        public string ObjSerialize(T obj)
        {
            var serializedObj = JsonConvert.SerializeObject(obj, Formatting.Indented);

            return serializedObj;
        }

        public T ObjDeserialize(string str)
        {
            var deserializedObj = JsonConvert.DeserializeObject<T>(str);

            return deserializedObj;
        }
    }
}
