using System;
using System.Linq;

namespace Extension
{
    public static class StringExtensions
    {
        public static string GetFirstWord(this string text)
        {
            var candidate = text.Trim();
            if (!candidate.Any(Char.IsWhiteSpace))
                return text;

            return candidate.Split(' ').FirstOrDefault();
        }
    }
}