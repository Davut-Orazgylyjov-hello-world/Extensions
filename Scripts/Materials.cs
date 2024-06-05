using UnityEngine;

namespace Extension
{
    public static class Materials
    {
        public static bool IsSame(this Material a, Material b)
        {
            Debug.Log(
                $"{a.name.GetFirstWord()} \t {b.name.GetFirstWord()} /t isSame = {a.name.GetFirstWord() == b.name.GetFirstWord()}");
            return a.name.GetFirstWord() == b.name.GetFirstWord();
        }
    }
}