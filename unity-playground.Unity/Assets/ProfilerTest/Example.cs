using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace ProfilerTest
{
    
    public class Example : MonoBehaviour
    {
        void Update()
        {
            Profiler.BeginSample("This is the example");

            //textにHogeをガンガン加えてるからGC Allocしまくる
            //マネージヒープにオブジェクトを割り当てること = GC Alloc

            var text = string.Empty;
            for(int i = 0; i < 100; i++)
            {
                text += "Hoge";
            }

            Profiler.EndSample();
        }
    }

}