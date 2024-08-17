using System;
using Random = UnityEngine.Random;

namespace Extensions
{
    public static class Enum
    {
        public static T RandomEnum<T>(this T en) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("random enum variable is not an enum");
            }
            
            var values = System.Enum.GetValues(typeof(T));
            return (T) values.GetValue(Random.Range(0, values.Length));
        }
    }
}