using System.Collections;
using UnityEngine;

namespace Extension
{
    public static class FadeOut
    {
        public static IEnumerator FadeAndOut(this CanvasGroup canvasGroup, float speed)
        {
            canvasGroup.gameObject.SetActive(true);

            canvasGroup.alpha = 1;

            while (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime * speed;
                yield return null;
            }

            canvasGroup.gameObject.SetActive(false);
        }
    }
}
