using UnityEngine;

namespace Extensions
{
    public static class MathfDegrees
    {
        public static float Clamp(this float degree)
        {
            if (degree < 0)
                degree += 360;

            if (degree > 360)
                degree -= 360;

            return degree;
        }

        public static Vector2 GetRangeOfDegrees(this float degree, float multiply)
        {
            float rangeDifference = degree * 0.1f;

            Vector2 rangeValues = new Vector2
            {
                x = degree - rangeDifference,
                y = degree + rangeDifference
            };

            rangeValues.x = rangeValues.x.Clamp();
            rangeValues.y = rangeValues.y.Clamp();
            
            return rangeValues;
        }

        public static bool IsOutOfRange(this Vector2 range, float degree)
        {
            return range.x < degree || range.y > degree;
        }
    }
}