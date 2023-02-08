using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace UniTaskTest
{

    //Spaceキーを押すたびに、順番に「こんにちは」「お元気ですか」「さようなら」とデバッグログ表示する
    public class Example2 : MonoBehaviour
    {
        private async void Start()
        {

            //GameObjectが破棄された時にキャンセルを飛ばすトークンを作成
            var token = this.GetCancellationTokenOnDestroy();

            //WaitUntil Trueになるまで待つ

            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: token);
            Debug.Log("こんにちは");
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: token);
            Debug.Log("お元気ですか");
            await UniTask.WaitUntil(() => Input.GetKeyDown(KeyCode.Space), cancellationToken: token);
            Debug.Log("さようなら");
        }

    }
}
