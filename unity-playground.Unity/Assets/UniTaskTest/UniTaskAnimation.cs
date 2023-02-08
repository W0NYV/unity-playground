using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

namespace UniTaskTest
{
    public class UniTaskAnimation : MonoBehaviour
    {
        async void Start()
        {
            await Animation();
        }


        private async UniTask Animation()
        {
            float elapsed = 1f;

            while(elapsed < 3f)
            {
                elapsed += Time.deltaTime;
                transform.localScale = new Vector3(elapsed, elapsed, elapsed);
                await UniTask.DelayFrame(1);
            }

        }
    }
}
