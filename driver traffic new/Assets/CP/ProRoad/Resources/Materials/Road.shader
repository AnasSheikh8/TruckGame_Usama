Shader "CP/Road" {
	Properties {
		_MainTex ("Albedo (RGBA)", 2D) = "white" {}
		_NormalTex ("Normal", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Cutoff ("Cutoff", Range(0,1)) = 0.5
	}
	SubShader {
		Tags { "Queue"="AlphaTest+5" "RenderType"="TransparentCutout" }
		LOD 200
		OFFSET -1,-1

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		// #pragma surface surf Standard fullforwardshadows
		#pragma surface surf Standard fullforwardshadows alphatest:_Cutoff
		
		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _NormalTex;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;

		void surf (Input IN, inout SurfaceOutputStandard o) 
		{
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Normal = UnpackNormal(tex2D(_NormalTex, IN.uv_MainTex));
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}

