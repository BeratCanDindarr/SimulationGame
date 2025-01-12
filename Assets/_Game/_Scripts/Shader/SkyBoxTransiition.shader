Shader "Custom/SkyboxTransition"
{
    Properties
    {
        _Skybox1 ("Skybox 1", Cube) = "" {}
        _Skybox2 ("Skybox 2", Cube) = "" {}
        _Transition ("Transition", Range(0, 1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            samplerCUBE _Skybox1;
            samplerCUBE _Skybox2;
            float _Transition;

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = normalize(v.vertex.xyz);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float3 tex1 = texCUBE(_Skybox1, i.worldPos).rgb;
                float3 tex2 = texCUBE(_Skybox2, i.worldPos).rgb;
                float3 blendedColor = lerp(tex1, tex2, _Transition);
                return fixed4(blendedColor, 1.0);
            }
            ENDCG
        }
    }
}
