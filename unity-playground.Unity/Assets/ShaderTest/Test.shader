//シェーダ名を記載
Shader "Custom/Test"
{

    //プロパティを記載する箇所
    Properties
    {
        //Color型のプロパティ
        _Color ("Color", Color) = (1,1,1,1)

        //sampler2D型のプロパティ
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        //float型のプロパティ
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    
    //シェーダ本体を各部分
    SubShader
    {

        //レンダリング方法の指定、ここでは不透明だよと伝えている
        Tags { "RenderType"="Opaque" }

        //シェーダを切り替えるためのやつ
        //切り替えるシェーダを用意してないので今回は書かないでもいい
        LOD 200

        //シェーダプログラムを書くよ～～
        CGPROGRAM

        //surf関数がsurfaceシェーダにあたります、PBRでライティングとかします
        //vert関数がvertexにあたります（なんでvartexの方はこう書くんだ？？？）
        //フォワードレンダリングパスですべてのライトシャドウをサポートするよ
        #pragma surface surf Standard vertex:vert fullforwardshadows

        //シェーダの仕様として、3.0を指定するよ
        #pragma target 3.0
        
        //変数を使うために定義するよ
        sampler2D _MainTex;

        //Input構造体
        //こいつ自体がないとダメっぽい
        //ダメとは？
        struct Input
        {
            //今回は使ってないけど、構造体が空だったらコンパイルが通らないので書くよ
            //この名前で定義すると、自動でテクスチャのuv座標を入れてくれるっぽい
            float2 uv_MainTex;
        };

        //変数らを定義するよ
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        //頂点シェーダ
        //Unityが用意してくれた、appdata_full構造体を使って、入力と出力を行うよ
        //これ出力ってこの値を元にラスタライズしまっせってことでいいんだよな
        void vert(inout appdata_full v)
        {
            //頂点のxの値にyの値を加算するよ
            v.vertex.x += v.vertex.y;
        }

        //サーフェスシェーダ
        //Input構造体を受け取り、SurfaceOutputStandard構造体を使って入力と出力を行うよ
        //出力とは、ライティングステージに渡すみたいな感じか
        //SurfaceOutputStandardのinはなんだ？？？
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            //白色だよ
            fixed4 c = fixed4(1.0, 1.0, 1.0, 1.0); //tex2D (_MainTex, IN.uv_MainTex) * _Color;

            //構造体の変数らに値をぶち込んでいくよ
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;
        }

        //これにてシェーダコードはおしまい！
        ENDCG
    }
}
