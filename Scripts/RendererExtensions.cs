using UnityEngine;

namespace Extension
{
    public static class RendererExtensions
    {
        public static readonly Color NoColor = Color.clear;
        public static Material[] GetMaterials(this Renderer[] renderers)
        {
            Material[] materials = new Material [renderers.Length];

            for (int i = 0; i < renderers.Length; i++)
                materials[i] = renderers[i].material;

            return materials;
        }

        public static Color[] GetMaterialsColor(this Renderer[] renderers)
        {
            Color[] colors = new Color[renderers.Length];

            for (int i = 0; i < renderers.Length; i++)
            {
                if (renderers[i].material.HasColor("_Color"))
                    colors[i] = renderers[i].material.color;
                else 
                    colors[i] = NoColor;
            }

            return colors;
        }

        public static void SetMaterial(this Renderer[] renderers, Material material)
        {
            foreach (var renderer in renderers)
                renderer.material = material;
        }
        
        public static void SetColorLerp(this Renderer[] renderers, Color color , Color[] renderersColors, float lerp, string ignoreTag)
        {
            for (var i = 0; i < renderers.Length; i++)
            {
                if (!renderers[i].CompareTag(ignoreTag))
                {
                    if (renderersColors[i] != RendererExtensions.NoColor)
                        renderers[i].material.color = Color.Lerp(renderersColors[i], color, lerp);
                }
            }
        }
    }
}