Shader "Custom/VertexColorTest"
{
    Properties
    {
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        Pass 
        {
            CGPROGRAM
            #pragma target 5.0
            #include "UnityCG.cginc"

            #pragma vertex vert
            #pragma fragment frag

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float4 color : COLOR;
            };

            v2f vert(appdata_full v)
            {
                v2f o;

                float4 pos = v.vertex;

                pos.y += sin(_Time.y) * v.color.r;

                o.vertex = UnityObjectToClipPos(pos);
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                return i.color;
            }

            ENDCG
        }
    }
}
