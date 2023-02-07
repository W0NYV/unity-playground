using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace ProfilerTest
{

    public class Example2 : MonoBehaviour
    {
        [SerializeField] bool _useGCAlloc = true;
        
        private int _num = 0;
        static private int _sNum = 0;

        void Update()
        {

            if(_useGCAlloc)
            {

                //ラムダ式内でメンバ変数を参照するとGC Allocが発生
                InvokeAction(() => {
                    _num++;
                });
            }
            else
            {

                //static変数だとGC Allocが発生しない
                //オブジェクトを新たに割り当てることが発生しない
                InvokeAction(() => {
                    _sNum++;
                });
            }
        }

        private void InvokeAction(System.Action action)
        {
            action.Invoke();
        }
    }
}