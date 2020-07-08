// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.33 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.33;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:34715,y:33072,varname:node_3138,prsc:2|emission-2588-OUT,alpha-5833-OUT,voffset-3858-OUT;n:type:ShaderForge.SFN_Cubemap,id:7901,x:32289,y:32785,ptovrint:False,ptlb:Cubemap,ptin:_Cubemap,varname:_Cubemap,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,pvfc:0|DIR-1284-OUT,MIP-2049-OUT;n:type:ShaderForge.SFN_Vector1,id:2049,x:31739,y:32943,varname:node_2049,prsc:2,v1:0;n:type:ShaderForge.SFN_Fresnel,id:4178,x:31954,y:33121,varname:node_4178,prsc:2|EXP-5469-OUT;n:type:ShaderForge.SFN_OneMinus,id:7673,x:32149,y:33088,varname:node_7673,prsc:2|IN-4178-OUT;n:type:ShaderForge.SFN_Fresnel,id:3150,x:31923,y:33329,varname:node_3150,prsc:2|EXP-9776-OUT;n:type:ShaderForge.SFN_Vector1,id:9776,x:31683,y:33349,varname:node_9776,prsc:2,v1:34;n:type:ShaderForge.SFN_Multiply,id:4656,x:32218,y:33433,varname:node_4656,prsc:2|A-3150-OUT,B-5301-OUT,C-8739-OUT;n:type:ShaderForge.SFN_Vector3,id:5301,x:31817,y:33490,varname:node_5301,prsc:2,v1:0.5367647,v2:0.731643,v3:1;n:type:ShaderForge.SFN_Add,id:1782,x:32649,y:32830,varname:node_1782,prsc:2|A-7901-RGB,B-4656-OUT;n:type:ShaderForge.SFN_Add,id:6542,x:32322,y:33110,varname:node_6542,prsc:2|A-7673-OUT,B-3150-OUT;n:type:ShaderForge.SFN_Multiply,id:9923,x:33127,y:33065,varname:node_9923,prsc:2|A-6542-OUT,B-6542-OUT,C-4910-OUT,D-4814-OUT,E-4814-OUT;n:type:ShaderForge.SFN_Vector1,id:5469,x:31712,y:33145,varname:node_5469,prsc:2,v1:1;n:type:ShaderForge.SFN_Clamp01,id:5833,x:33354,y:33051,varname:node_5833,prsc:2|IN-9923-OUT;n:type:ShaderForge.SFN_Vector1,id:8739,x:31936,y:33621,varname:node_8739,prsc:2,v1:333333;n:type:ShaderForge.SFN_Sin,id:4788,x:32490,y:34023,varname:node_4788,prsc:2|IN-4632-OUT;n:type:ShaderForge.SFN_NormalVector,id:7518,x:32450,y:34206,prsc:2,pt:False;n:type:ShaderForge.SFN_Multiply,id:3858,x:33553,y:34036,varname:node_3858,prsc:2|A-6806-OUT,B-5900-OUT,C-7518-OUT;n:type:ShaderForge.SFN_FragmentPosition,id:130,x:30267,y:34270,varname:node_130,prsc:2;n:type:ShaderForge.SFN_Vector1,id:7576,x:32681,y:34405,varname:node_7576,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Time,id:7015,x:31060,y:33656,varname:node_7015,prsc:2;n:type:ShaderForge.SFN_RemapRange,id:6806,x:33209,y:34093,varname:node_6806,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-4788-OUT;n:type:ShaderForge.SFN_Multiply,id:3919,x:31075,y:34455,varname:node_3919,prsc:2|A-2828-OUT,B-242-OUT;n:type:ShaderForge.SFN_Vector1,id:242,x:30814,y:34538,varname:node_242,prsc:2,v1:20;n:type:ShaderForge.SFN_Add,id:7770,x:32310,y:34078,varname:node_7770,prsc:2|A-7015-T,B-3919-OUT;n:type:ShaderForge.SFN_ComponentMask,id:3171,x:31392,y:34351,varname:node_3171,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-3919-OUT;n:type:ShaderForge.SFN_Append,id:4632,x:32138,y:34091,varname:node_4632,prsc:2|A-2172-OUT,B-9058-OUT,C-8792-OUT;n:type:ShaderForge.SFN_Add,id:9058,x:31934,y:34051,varname:node_9058,prsc:2|A-4251-OUT,B-3171-OUT;n:type:ShaderForge.SFN_Add,id:2172,x:31934,y:34203,varname:node_2172,prsc:2|A-3300-OUT,B-9772-OUT;n:type:ShaderForge.SFN_ComponentMask,id:9772,x:31392,y:34513,varname:node_9772,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-3919-OUT;n:type:ShaderForge.SFN_ComponentMask,id:660,x:31380,y:34660,varname:node_660,prsc:2,cc1:2,cc2:-1,cc3:-1,cc4:-1|IN-3919-OUT;n:type:ShaderForge.SFN_Add,id:8792,x:31934,y:34381,varname:node_8792,prsc:2|A-660-OUT,B-7670-OUT;n:type:ShaderForge.SFN_Multiply,id:4251,x:31414,y:33845,varname:node_4251,prsc:2|A-7015-T,B-5506-OUT;n:type:ShaderForge.SFN_Vector1,id:5506,x:31122,y:33902,varname:node_5506,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3300,x:31601,y:33958,varname:node_3300,prsc:2|A-4251-OUT,B-8645-OUT;n:type:ShaderForge.SFN_Vector1,id:8645,x:31288,y:34033,varname:node_8645,prsc:2,v1:0.8;n:type:ShaderForge.SFN_Multiply,id:7670,x:31654,y:34124,varname:node_7670,prsc:2|A-4251-OUT,B-5881-OUT;n:type:ShaderForge.SFN_Vector1,id:5881,x:31352,y:34097,varname:node_5881,prsc:2,v1:0.6;n:type:ShaderForge.SFN_Slider,id:5900,x:32529,y:34501,ptovrint:False,ptlb:Deformation,ptin:_Deformation,varname:_Deformation,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.05299145,max:1;n:type:ShaderForge.SFN_Code,id:1284,x:31739,y:32664,varname:node_1284,prsc:2,code:cgBlAHQAdQByAG4AIAByAGUAZgByAGEAYwB0ACgAaQAsAG4ALABpAG8AcgApADsA,output:2,fname:Refract,width:248,height:132,input:2,input:2,input:0,input_1_label:i,input_2_label:n,input_3_label:ior|A-1537-OUT,B-9448-OUT,C-1387-OUT;n:type:ShaderForge.SFN_Slider,id:1387,x:31306,y:32474,ptovrint:False,ptlb:ior,ptin:_ior,varname:_ior,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.6581197,max:1;n:type:ShaderForge.SFN_Negate,id:9448,x:31316,y:32658,varname:node_9448,prsc:2|IN-1866-OUT;n:type:ShaderForge.SFN_DepthBlend,id:4910,x:32832,y:33160,varname:node_4910,prsc:2|DIST-2578-OUT;n:type:ShaderForge.SFN_Vector1,id:2578,x:32621,y:33363,varname:node_2578,prsc:2,v1:0.05;n:type:ShaderForge.SFN_ViewVector,id:1866,x:31139,y:32669,varname:node_1866,prsc:2;n:type:ShaderForge.SFN_ViewReflectionVector,id:1537,x:31164,y:32825,varname:node_1537,prsc:2;n:type:ShaderForge.SFN_Fresnel,id:6709,x:32813,y:33565,varname:node_6709,prsc:2|EXP-8823-OUT;n:type:ShaderForge.SFN_OneMinus,id:4814,x:33008,y:33532,varname:node_4814,prsc:2|IN-6709-OUT;n:type:ShaderForge.SFN_Vector1,id:8823,x:32571,y:33589,varname:node_8823,prsc:2,v1:6;n:type:ShaderForge.SFN_Multiply,id:2588,x:33588,y:33233,varname:node_2588,prsc:2|A-1782-OUT,B-4814-OUT;n:type:ShaderForge.SFN_TexCoord,id:4967,x:32058,y:33670,varname:node_4967,prsc:2,uv:0;n:type:ShaderForge.SFN_Multiply,id:1522,x:32426,y:33666,varname:node_1522,prsc:2|A-4967-UVOUT;n:type:ShaderForge.SFN_ObjectPosition,id:4697,x:30296,y:34488,varname:node_4697,prsc:2;n:type:ShaderForge.SFN_Subtract,id:2828,x:30503,y:34423,varname:node_2828,prsc:2|A-130-XYZ,B-4697-XYZ;proporder:7901-5900-1387;pass:END;sub:END;*/

Shader "Fog Volume/TeleportSphere" {
    Properties {
        _Cubemap ("Cubemap", Cube) = "_Skybox" {}
        _Deformation ("Deformation", Range(0, 1)) = 0.05299145
        _ior ("ior", Range(0, 1)) = 0.6581197
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform sampler2D _CameraDepthTexture;
            uniform float4 _TimeEditor;
            uniform samplerCUBE _Cubemap;
            uniform float _Deformation;
            float3 Refract( float3 i , float3 n , float ior ){
            return refract(i,n,ior);
            }
            
            uniform float _ior;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
                float3 normalDir : TEXCOORD1;
                float4 projPos : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_7015 = _Time + _TimeEditor;
                float node_4251 = (node_7015.g*1.0);
                float3 node_3919 = ((mul(unity_ObjectToWorld, v.vertex).rgb-objPos.rgb)*20.0);
                v.vertex.xyz += ((sin(float3(((node_4251*0.8)+node_3919.g),(node_4251+node_3919.r),(node_3919.b+(node_4251*0.6))))*0.5+0.5)*_Deformation*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                o.projPos = ComputeScreenPos (o.pos);
                COMPUTE_EYEDEPTH(o.projPos.z);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 viewReflectDirection = reflect( -viewDirection, normalDirection );
                float sceneZ = max(0,LinearEyeDepth (UNITY_SAMPLE_DEPTH(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)))) - _ProjectionParams.g);
                float partZ = max(0,i.projPos.z - _ProjectionParams.g);
////// Lighting:
////// Emissive:
                float node_3150 = pow(1.0-max(0,dot(normalDirection, viewDirection)),34.0);
                float node_4814 = (1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),6.0));
                float3 emissive = ((texCUBElod(_Cubemap,float4(Refract( viewReflectDirection , (-1*viewDirection) , _ior ),0.0)).rgb+(node_3150*float3(0.5367647,0.731643,1)*333333.0))*node_4814);
                float3 finalColor = emissive;
                float node_6542 = ((1.0 - pow(1.0-max(0,dot(normalDirection, viewDirection)),1.0))+node_3150);
                return fixed4(finalColor,saturate((node_6542*node_6542*saturate((sceneZ-partZ)/0.05)*node_4814*node_4814)));
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 metal 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _Deformation;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_7015 = _Time + _TimeEditor;
                float node_4251 = (node_7015.g*1.0);
                float3 node_3919 = ((mul(unity_ObjectToWorld, v.vertex).rgb-objPos.rgb)*20.0);
                v.vertex.xyz += ((sin(float3(((node_4251*0.8)+node_3919.g),(node_4251+node_3919.r),(node_3919.b+(node_4251*0.6))))*0.5+0.5)*_Deformation*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
