// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "Custom/CellShader" {
	Properties{
		//The user defined properties of the shader, which you can change in unity to the settings you wish to use.
		_Color("Color", Color) = (1,1,1,1)
		_UnlitColor("UnlitColor", Color) = (0.5, 0.5, 0.5, 1)
		_DiffuseThreshold("Lighting Threshold", Range(-1.1, 1)) = 0.1
		_SpecColor("Specular Color", Color)=(1, 1, 1, 1)
		_Shininess("Shininess", Range(0.5, 1)) = 1
		_OutlineThickness("Outline Thickness", Range(0, 1)) = 0.1
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
	}
		SubShader{
			Pass{
			CGPROGRAM
			//lighting based on view normal and surface normals
			#pragma vertex vert
			#pragma fragment frag

			//Define the variables of the shader
			uniform float4 _Color;
		uniform float4 _UnlitColor;
		uniform float _DiffuseThreshold;
		uniform float4 _SpecColor;
		uniform float _OutlineThickness;
		uniform float4 _LightColor;
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float _Shininess;

		//the variables put into the vertexOutput function
			struct vertexInput {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 texcoord : TEXCOORD0;
			};

			//variables of the output of the vertexOutput function
			struct vertexOutput {
				float4 pos : SV_POSITION;
				float3 normalDir : TEXCOORD1;
				float4 lightDir : TEXCOORD2;
				float3 viewDir : TEXCOORD3;
				float2 uv : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;
				//calculating the vertex normal direction
				output.normalDir = normalize(mul(float4(input.normal, 0.0), unity_WorldToObject).xyz);

				//getting the worldposition of the vertex
				float4 PosWorld = mul(unity_ObjectToWorld, input.vertex);

				//getting the viewdirection of the camera
				output.viewDir = normalize(_WorldSpaceCameraPos.xyz - PosWorld.xyz);

				//getting the lightdirection
				float3 fragmentToLightSource = (_WorldSpaceCameraPos.xyz - PosWorld.xyz);
				output.lightDir = float4(normalize(lerp(_WorldSpaceLightPos0.xyz, fragmentToLightSource, _WorldSpaceLightPos0.w)), lerp(1.0, 1.0 / length(fragmentToLightSource), _WorldSpaceLightPos0.w));
				
				//Fragmentinput output
				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);
				output.uv = input.texcoord;
				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{
				float nDotL = saturate(dot(input.normalDir, input.lightDir.xyz));
			//calculation for unlit or lit parts, threshold between the two using calculated normals
			float diffuseCutOff = saturate(max(_DiffuseThreshold, nDotL) - _DiffuseThreshold) * 1000;
			//same calculation, but now between specular and lit parts
			float specularCutOff = saturate(max(_Shininess, dot(reflect(-input.lightDir.xyz, input.normalDir), input.viewDir)) - _Shininess) * 1000;
			float outlineStrength = saturate(dot(input.normalDir, input.viewDir) - _OutlineThickness) * 1000;
			float3 ambientLight = (1 - diffuseCutOff)*_UnlitColor.xyz;
			float3 diffuseReflection = (1 - specularCutOff) * _Color.xyz * diffuseCutOff;
			float3 specularReflection = _SpecColor.xyz * specularCutOff;
			float3 combinedLight = (ambientLight + diffuseReflection)*outlineStrength + specularReflection;
			return float4(combinedLight, 1.0);
			}
		ENDCG
			}
	}
	FallBack "Diffuse"
}
