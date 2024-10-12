using UnityEngine;

namespace Extension
{
    public static class LayerExtensions
    {
        public static int LayerMaskToLayer(this LayerMask layerMask)
        {
            int layerNumber = 0;
            int layer = layerMask.value;
            while (layer > 0)
            {
                layer >>= 1;
                layerNumber++;
            }

            return layerNumber - 1;
        }

        public static void ChangeAllChildLayerMask(this Transform transform, LayerMask toLayer)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.layer = toLayer;
                child.ChangeAllChildLayerMask(toLayer);
            }
        }
    }
}