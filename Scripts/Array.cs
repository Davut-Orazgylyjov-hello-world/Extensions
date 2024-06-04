using Random = System.Random;

namespace Extension
{
    public static class Array
    {
        public static void Shuffle<T>(this T[] array)
        {
            Random rng = new Random();

            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                (array[n], array[k]) = (array[k], array[n]);
            }
        }
    }
}