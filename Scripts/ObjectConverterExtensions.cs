using UnityEngine;

namespace Extension
{
    public static class ObjectConverterExtensions
    {
        public static object ConvertObjectTo<T>(this object convertObject)
        {
            if (convertObject is T convertedObject)
                return convertedObject;

            Debug.LogError($"{convertObject.GetType().Name} is not {typeof(T).Name}");
            Debug.Break();

            return null;
        }
    }
}