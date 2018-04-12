// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "FlatWorld/WorldPosition" {
	Properties {
			_Color ("Color", Color) = (1,1,1,1)
			_MainTex ("Albedo (RGB)", 2D) = "white" {}			
		}
   SubShader {
      Pass {
         CGPROGRAM

         #pragma vertex vert  
         #pragma fragment frag 
 
         struct vertexInput {
            float4 vertex : POSITION;
			float4 texcoord : TEXCOORD0;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            half2 uv : TEXCOORD0;
         };

		 sampler2D _MainTex;
		 float4 _MainTex_ST;

         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output; 
			
            output.pos = mul(unity_ObjectToWorld, input.vertex);
			output.uv =  input.texcoord.xy * _MainTex_ST.xy + _MainTex_ST.zw;
            return output;
         }
 
         float4 frag(vertexOutput input) : COLOR 
         {
			
			fixed4 c = (tex2D( _MainTex, input.uv ).rgb, 1.0);

			return c;
         }
 
         ENDCG  
      }
   }
}