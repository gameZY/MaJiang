Shader "Custom/DoubleDiffuse" {
    Properties {
	    _Color("Main Color", Color) = (1,1,1,1)
	    _MainTex("Base (RGB)", 2D) = "white" {}
		_BackColor("Back Color",Color) = (1,1,1,1)
		_BackTex("Base (RGB)", 2D) = "white" {}
    }
    SubShader {
		Tags{ "RenderType" = "Opaque"}
		pass
		{
			Cull back
			CGPROGRAM
			#include "UnityCG.cginc"

			#pragma vertex vertFront
			#pragma fragment fragFront

			uniform sampler2D _MainTex;
			uniform float4 _MainTex_ST;
			uniform fixed4 _Color;

			struct vertexInputFront {
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv 	  : TEXCOORD0;
			};

			struct vertexOutputFront {
				float4 pos : SV_POSITION;
				float4 col : COLOR;
				float2 uv  : TEXCOORD0;
			};

			vertexOutputFront vertFront(vertexInputFront input) {
				vertexOutputFront output;
                output.col = float4(1.0, 1.0, 1.0, 1.0);
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				output.uv = TRANSFORM_TEX(input.uv, _MainTex);
				return output;
			}

			float4 fragFront(vertexOutputFront input) : COLOR
			{
				fixed4 mainTex = tex2D(_MainTex, input.uv) * input.col;
				fixed4 color;
				color.rgb = mainTex.rgb;
				color.a = mainTex.a;
				return color;
			}
			ENDCG
		}
		pass
		{
			Cull front
			CGPROGRAM
			#include "UnityCG.cginc"

			#pragma vertex vertBack
			#pragma fragment fragBack

			uniform sampler2D _BackTex;
			uniform float4 _BackTex_ST;
			uniform fixed4 _BackColor;

			struct vertexInputBack {
				float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				float2 uv 	  : TEXCOORD0;
			};

			struct vertexOutputBack {
				float4 pos : SV_POSITION;
				float4 col : COLOR;
				float2 uv  : TEXCOORD0;
			};

			vertexOutputBack vertBack(vertexInputBack input) {
				vertexOutputBack output;
                output.col = float4(1.0, 1.0, 1.0, 1.0);
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				output.uv = TRANSFORM_TEX(input.uv, _BackTex);
				return output;
			}

			float4 fragBack(vertexOutputBack input) : COLOR
			{
				fixed4 mainTex = tex2D(_BackTex, input.uv) * input.col;
				fixed4 color;
				color.rgb = mainTex.rgb;
				color.a = mainTex.a;
				return color;
			}
			ENDCG
        }
    }
    Fallback "Diffuse"
}
