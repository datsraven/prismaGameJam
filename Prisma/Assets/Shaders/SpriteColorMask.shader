Shader "Sprites/SpriteColorMask"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
        _GrayScaleFactor("GrayScale", Range(0, 1)) = 0.5
        _RedScaleFactor("Red Scale", Range(0, 1)) = 0.5
        _GreenScaleFactor("Green Scale", Range(0, 1)) = 0.5
        _BlueScaleFactor("Blue Scale", Range(0, 1)) = 0.5
        [MaterialToggle] PixelSnap("Pixel snap", Float) = 0
        [HideInInspector] _RendererColor("RendererColor", Color) = (1,1,1,1)
        [HideInInspector] _Flip("Flip", Vector) = (1,1,1,1)
        [PerRendererData] _AlphaTex("External Alpha", 2D) = "white" {}
        [PerRendererData] _EnableExternalAlpha("Enable External Alpha", Float) = 0
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Cull Off
            Lighting Off
            ZWrite Off
            Blend One OneMinusSrcAlpha

            Pass
            {
            CGPROGRAM
                #pragma vertex SpriteVert
                #pragma fragment MaskedSpriteFrag
                #pragma target 2.0
                #pragma multi_compile_instancing
                #pragma multi_compile_local _ PIXELSNAP_ON
                #pragma multi_compile _ ETC1_EXTERNAL_ALPHA
                #include "UnitySprites.cginc"

                float _GrayScaleFactor;
                float _RedScaleFactor;
                float _GreenScaleFactor;
                float _BlueScaleFactor;


                fixed4 MaskedSpriteFrag(v2f IN) : SV_Target
                {
                    fixed4 c = SampleSpriteTexture(IN.texcoord) * IN.color;
                    c.rgb *= c.a;
                    fixed4 finalCol = c;

                    finalCol.r = lerp(c.r, (c.r + c.g + c.b) / 3.0f, _RedScaleFactor );                    
                    finalCol.g = lerp(c.g, (c.r + c.g + c.b) / 3.0f, _GreenScaleFactor );
                    finalCol.b = lerp(c.b, (c.r + c.g + c.b) / 3.0f, _BlueScaleFactor  );

                    float coFactor = min(min(c.r, c.g), c.b);

                    finalCol.r = lerp(c.r, min((c.r + c.g + c.b) / 3.0f, coFactor), _RedScaleFactor);
                    finalCol.g = lerp(c.g, min((c.r + c.g + c.b) / 3.0f, coFactor), _GreenScaleFactor);
                    finalCol.b = lerp(c.b, min((c.r + c.g + c.b) / 3.0f, coFactor), _BlueScaleFactor);

                    

                    return finalCol;
                }
            ENDCG
            }
        }
}
