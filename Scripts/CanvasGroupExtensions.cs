using System.Collections;
using UnityEngine;

namespace Extension
{
    public static class CanvasGroupExtensions
    {
        public static IEnumerator SetActiveSmooth(this CanvasGroup canvasGroup, bool active, float speed = 1f)
        {
            yield return active ? ActivateSmooth(canvasGroup, speed) : DeactivateSmooth(canvasGroup, speed);
        }

        public static IEnumerator ActivateSmooth(this CanvasGroup canvasGroup, float speed = 1f)
        {
            float startAlpha = canvasGroup.alpha;
            float elapsedTime = 0f;
            float duration = (1f - startAlpha) / speed;

            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.unscaledDeltaTime;
                float smoothOn = Mathf.Lerp(startAlpha, 1f, elapsedTime / duration);
                canvasGroup.alpha = smoothOn;

                yield return null;
            }

            canvasGroup.alpha = 1;
        }

        public static IEnumerator DeactivateSmooth(this CanvasGroup canvasGroup, float speed = 1f)
        {
            float startAlpha = canvasGroup.alpha;
            float elapsedTime = 0f;
            float duration = startAlpha / speed;

            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;

            while (elapsedTime < duration)
            {
                elapsedTime += Time.unscaledDeltaTime;
                float smoothOff = Mathf.Lerp(startAlpha, 0f, elapsedTime / duration);
                canvasGroup.alpha = smoothOff;

                yield return null;
            }

            canvasGroup.alpha = 0;
        }

        public static void SetActive(this CanvasGroup canvasGroup, bool active)
        {
            canvasGroup.interactable = active;

            canvasGroup.blocksRaycasts = active;

            canvasGroup.alpha = active ? 1 : 0;
        }
    }
}