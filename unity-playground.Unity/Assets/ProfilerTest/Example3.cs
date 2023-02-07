using UnityEngine;
using UnityEngine.Profiling;

namespace ProfilerTest
{
    public class Example3 : MonoBehaviour
    {

        void Update()
        {

            //環境
            //Mono
            //.NET Standard 2.1
            //C# 8.0

            //BOXINGする方がいいやんけ
            //なんで？？？？

            //文字列補間式 $"{}" をじゃないと結果が変わらん
            //なんで？？？？

            int n = 7;

            Profiler.BeginSample("BOXING TEST");
            
            //GC Alloc 50B
            //string s = "a" + n;

            //GC Alloc 48B
            string s = $"a {n}";
            
            Profiler.EndSample();


            Profiler.BeginSample("UN BOXING TEST");
            
            //GC Alloc 50B
            //string s2 = "a" + n.ToString();

            //GC Alloc 52B
            string s2 = $"a {n.ToString()}";
            
            Profiler.EndSample();

        }
    }
}
