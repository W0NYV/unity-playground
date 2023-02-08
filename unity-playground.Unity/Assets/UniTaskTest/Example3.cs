using System;
using Cysharp.Threading.Tasks;

namespace UniTaskTest
{
    public class Example3
    {

        public async UniTask WaitTest()
        {
            await UniTask.Delay(1000);
        }

        public async UniTask<bool> WaitTest2()
        {
            await UniTask.Delay(1000);
            return true;
        }
    }
}
