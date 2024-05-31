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
            float smoothOn = canvasGroup.alpha;

            canvasGroup.interactable = true;

            canvasGroup.blocksRaycasts = true;

            while (smoothOn < 1)
            {
                smoothOn += Time.deltaTime * speed;

                canvasGroup.alpha = smoothOn;

                yield return null;
            }
        }

        public static IEnumerator DeactivateSmooth(this CanvasGroup canvasGroup, float speed = 1f)
        {
            float smoothOff = canvasGroup.alpha;

            canvasGroup.interactable = false;

            canvasGroup.blocksRaycasts = false;

            while (smoothOff > 0)
            {
                smoothOff -= Time.deltaTime * speed;

                canvasGroup.alpha = smoothOff;

                yield return null;
            }
        }

        public static void SetActive(this CanvasGroup canvasGroup, bool active)
        {
            canvasGroup.interactable = active;

            canvasGroup.blocksRaycasts = active;

            canvasGroup.alpha = active ? 1 : 0;
        }
    }
}