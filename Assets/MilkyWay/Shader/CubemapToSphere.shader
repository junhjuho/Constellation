Shader"Custom/CubemapToSphere"
{
    Properties
    {
        _MainTex ("Skybox Cubemap", Cube) = "" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        
        Pass
        {
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "UnityCG.cginc"

struct appdata_t
{
    float4 vertex : POSITION;
};

struct v2f
{
    float3 viewDir : TEXCOORD0;
    float4 vertex : SV_POSITION;
};

samplerCUBE _MainTex;

v2f vert(appdata_t v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.viewDir = normalize(v.vertex.xyz);
    return o;
}

half4 frag(v2f i) : SV_Target
{
    return texCUBE(_MainTex, i.viewDir);
}
            ENDCG
        }
    }
}
