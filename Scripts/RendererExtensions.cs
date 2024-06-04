using System.Collections.Generic;
using UnityEngine;

namespace Extension
{
    public static class RendererExtensions
    {
        public static readonly Color NoColor = Color.clear;
        
        public static Material[] GetMaterials(this Renderer[] renderers)
        {
            List<Material> materials = new List<Material>();

            foreach (var t in renderers)
                materials.AddRange(t.materials);

            return materials.ToArray();
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

        public static void SetMaterials(this Renderer[] renderers, params Material[] materials)
        {
            int indexMaterial = 0;

            foreach (var renderer in renderers)
            {
                int lengthMaterialsInMesh = renderer.materials.Length;
                var materialsMesh = new Material[lengthMaterialsInMesh];

                for (int i = 0; i < lengthMaterialsInMesh; i++, indexMaterial++)
                {
                    if (indexMaterial >= materials.Length)
                        materialsMesh[i] = materials[^1];
                    else
                        materialsMesh[i] = materials[indexMaterial];
                }

                renderer.materials = materialsMesh;
            }
        }
        
        public static void SetMaterialColors(this Renderer[] renderers, params Color[] materials)
        {
            int indexMaterial = 0;

            foreach (var renderer in renderers)
            {
                var materialsMesh = renderer.materials;

                for (int i = 0; i < materialsMesh.Length; i++, indexMaterial++)
                {
                    materialsMesh[i].color =
                        indexMaterial >= materials.Length ? materials[^1] : materials[indexMaterial];
                }

                renderer.materials = materialsMesh;
            }
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