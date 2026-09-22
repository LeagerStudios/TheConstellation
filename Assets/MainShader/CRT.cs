using UnityEngine;

[ExecuteAlways]
public class CRT : MonoBehaviour
{
    public Material material;

    private void OnRenderImage(
        RenderTexture source,
        RenderTexture destination)
    {
        if (material != null)
            Graphics.Blit(source, destination, material);
        else
            Graphics.Blit(source, destination);
    }
}