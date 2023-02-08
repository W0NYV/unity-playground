using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace UniTaskTest
{
    public class Example : MonoBehaviour
    {

        private float _waitTime = 3f;

        async void Start()
        {

            Debug.Log("Hey");

            //_waitTime秒待つ
            await UniTask.Delay(TimeSpan.FromSeconds(_waitTime));
            
            Debug.Log("Yo!");
        }
    }
}
