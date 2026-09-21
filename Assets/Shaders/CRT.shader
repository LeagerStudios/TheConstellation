Shader "Custom/CRT"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}

        _ScreenInset ("Screen Border", Range(0, 0.2)) = 0.05
        _CornerRadius ("Corner Radius", Range(0, 0.5)) = 0.08

        _Scanlines ("Scanlines", Range(0, 1)) = 0.2
        _RGBOffset ("RGB Separation", Range(0, 0.01)) = 0.001
        _Curvature ("Curvature", Range(0, 0.5)) = 0.1
        _Vignette ("Vignette", Range(0, 1)) = 0.2
        _Brightness ("Brightness", Range(0, 2)) = 1
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Opaque"
            "Queue"="Overlay"
        }

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;

            float _ScreenInset;
            float _CornerRadius;

            float _Scanlines;
            float _RGBOffset;
            float _Curvature;
            float _Vignette;
            float _Brightness;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                return o;
            }

            float2 CurveUV(float2 uv)
            {
                float2 p = uv * 2.0 - 1.0;

                p.x *= 1.0 + p.y * p.y * _Curvature;
                p.y *= 1.0 + p.x * p.x * _Curvature;

                return p * 0.5 + 0.5;
            }

            // Rectángulo con esquinas redondeadas
            float RoundedBox(
                float2 uv,
                float2 center,
                float2 halfSize,
                float radius)
            {
                float2 q = abs(uv - center)
                         - halfSize
                         + radius;

                return length(max(q, 0.0))
                       + min(max(q.x, q.y), 0.0)
                       - radius;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;

                // Curvatura de la pantalla
                uv = CurveUV(uv);

                // Centro de la pantalla
                float2 center = float2(0.5, 0.5);

                // Tamaño de la zona visible
                float2 halfSize =
                    float2(
                        0.5 - _ScreenInset,
                        0.5 - _ScreenInset
                    );

                // Máscara de pantalla
                float distance =
                    RoundedBox(
                        uv,
                        center,
                        halfSize,
                        _CornerRadius
                    );

                // Fuera de la pantalla = negro
                if (distance > 0.0)
                {
                    return fixed4(0, 0, 0, 1);
                }

                // =========================
                // IMAGEN
                // =========================

                // Convertimos la zona interior
                // nuevamente a coordenadas 0-1
                float2 screenUV =
                    (uv - _ScreenInset) /
                    (1.0 - _ScreenInset * 2.0);

                // RGB separado
                float r = tex2D(
                    _MainTex,
                    screenUV + float2(_RGBOffset, 0)
                ).r;

                float g = tex2D(
                    _MainTex,
                    screenUV
                ).g;

                float b = tex2D(
                    _MainTex,
                    screenUV - float2(_RGBOffset, 0)
                ).b;

                float3 color = float3(r, g, b);

                // =========================
                // SCANLINES
                // =========================

                float scanline =
                    sin(screenUV.y * 900.0)
                    * 0.5 + 0.5;

                color *=
                    1.0 -
                    scanline * _Scanlines;

                // =========================
                // VIÑETA
                // =========================

                float2 centered =
                    screenUV * 2.0 - 1.0;

                float vignette =
                    1.0 -
                    dot(centered, centered)
                    * _Vignette;

                color *= vignette;

                // Brillo
                color *= _Brightness;

                return fixed4(color, 1);
            }

            ENDCG
        }
    }
}