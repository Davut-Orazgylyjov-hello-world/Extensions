using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public static class MonoBehaviourExtensions
{
    public static void RebuildLayout(this MonoBehaviour monoBehaviour)
    {
        monoBehaviour.StartCoroutine(RebuildLayout(monoBehaviour.transform as RectTransform));
    }

    private static IEnumerator RebuildLayout(RectTransform rectTransform)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        yield return new WaitForEndOfFrame();
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
    }
}