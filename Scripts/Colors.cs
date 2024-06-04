using UnityEngine;

namespace Extension
{
    public static class Colors
    {
        public static Color SetAlpha(this  Color color, float value)
        {
            return new Color(color.r, color.g, color.b, value);
        }

        public static Color SetR(this  Color color, float value)
        {
            return new Color(value, color.g, color.b, color.a);
        }

        public static Color SetG(this Color color, float value)
        {
            return new Color(color.r,value, color.b, color.a);
        }

        public static Color SetB(this Color color, float value)
        {
            return new Color(color.r, color.g, value, color.a);
        }
        
        public static bool IsSame(this Material a, Material b)
        {
            Debug.Log(
                $"{a.name.GetFirstWord()} \t {b.name.GetFirstWord()} /t isSame = {a.name.GetFirstWord() == b.name.GetFirstWord()}");
            return a.name.GetFirstWord() == b.name.GetFirstWord();
        }
    }
}