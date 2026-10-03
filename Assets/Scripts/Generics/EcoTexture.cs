using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EcoTexture
{
    public int width = 0;
    public int height = 0;
    float[] r;
    float[] g;
    float[] b;
    float[] a;

    public EcoTexture(int texWidth, int texHeight)
    {
        width = texWidth;
        height = texHeight;
        r = new float[width * height];
        g = new float[width * height];
        b = new float[width * height];
        a = new float[width * height];
    }

    public void SetPixel(int x, int y, float pr, float pg, float pb, float pa)
    {
        if ((x >= 0 && y >= 0) && (x < width && y < height))
        {
            int index = (y * width) + x;
            r[index] = pr;
            g[index] = pg;
            b[index] = pb;
            a[index] = pa;
        }
    }

    public void FillWith(Color color)
    {
        for (int i = 0; i < width * height; i++)
        {
            r[i] = color.r;
            g[i] = color.g;
            b[i] = color.b;
            a[i] = color.a;
        }
    }

    public void Alpha1()
    {
        for (int i = 0; i < width * height; i++)
        {
            a[i] = 1;
        }
    }

    public Color GetPixel(int x, int y)
    {
        if ((x >= 0 && y >= 0) && (x < width && y < height))
        {
            int idx = (y * width) + x;

            return new Color(r[idx], g[idx], b[idx], a[idx]);
        }
        else
        {
            return new Color(-1f, -1f, -1f, -1f);
        }
    }

    public Texture2D Export(FilterMode filterMode)
    {
        Texture2D texture2D = new Texture2D(width, height);
        Color[] coolArray = new Color[width * height];
        for (int i = 0; i < width * height; i++)
        {
            coolArray[i] = new Color(r[i], g[i], b[i], a[i]);
        }
        texture2D.SetPixels(coolArray);
        texture2D.filterMode = filterMode;
        texture2D.Apply();
        return texture2D;
    }
}

