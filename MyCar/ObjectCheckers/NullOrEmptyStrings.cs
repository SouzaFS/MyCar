using System.Reflection;

namespace MyCar.ObjectCheckers
{
    public class NullOrEmptyStrings
    {
        public static bool IsAnyNullOrEmpty(object myObject)
        {
            foreach (PropertyInfo propertyInfo in myObject.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    string value = (string)propertyInfo.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
