Shader "Custom/WorldSpaceTexture" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (0,0,0,1)
    }
 
    SubShader {
        Tags { "RenderType"="Opaque" }
 
        CGPROGRAM
        #pragma surface surf Standard
 
        sampler2D _MainTex;
		fixed4 _MainTex_ST;
		fixed4 _Color;

        struct Input 
		{
            float3 worldPos;
			float2 uv_MainTex;
        };
 
        void surf (Input IN, inout SurfaceOutputStandard o) 
		{ 
            o.Albedo = tex2D(_MainTex, IN.worldPos.xy * _MainTex_ST.xy + _MainTex_ST.zw) * _Color;
        } 
        ENDCG
    }
    FallBack "Diffuse"
}
