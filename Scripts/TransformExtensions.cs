using System.Collections;
using UnityEngine;

namespace Extension
{
    public static class TransformExtensions
    {
        public static IEnumerator ScaleLerpTo(this Transform transform, float newScale, float timeScale)
        {
            Vector3 currentScale = transform.localScale;
            Vector3 finalScale = currentScale * newScale;

            float time = 0;

            while (time < timeScale)
            {
                time += Time.deltaTime;

                transform.localScale = Vector3.Lerp(currentScale, finalScale, time / timeScale);
                
                yield return null;
            }
        }
    }
}