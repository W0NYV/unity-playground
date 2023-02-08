using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

namespace UniTaskTest
{
    public class UniTaskTest : MonoBehaviour
    {

        private Example3 _example3;

        private async void Start()
        {
            _example3 = new Example3();

            await _example3.WaitTest();

            bool result = false;

            Debug.Log(result);

            result = await _example3.WaitTest2(); 

            Debug.Log(result);
            Debug.Log("hoe~~");

        }

    }
}
