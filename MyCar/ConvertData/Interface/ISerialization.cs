namespace MyCar.ConvertData.Interface
{
    public interface ISerialization <T> where T : class
    {
        public string ObjSerialize(T obj);
        public T ObjDeserialize(string obj);
    }
}
