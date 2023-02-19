using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace W0NYV.WebRequestTest
{

    [System.Serializable]
    public class MyName
    {
        public string name;
    }

    public class WebRequestPostTest : MonoBehaviour
    {

        private MyName _myName;

        async private void Start() {
            
            _myName = new MyName();
            _myName.name = "John";

            //シリアライズ
            string json = JsonUtility.ToJson(_myName);

            //バイナリに変換する必要がある
            byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
            
            var request = new UnityWebRequest("http://localhost:3000/unity", UnityWebRequest.kHttpVerbPOST);

            request.uploadHandler = (UploadHandler)new UploadHandlerRaw(postData);
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();

            request.SetRequestHeader("Content-Type", "application/json");

            await request.SendWebRequest();

            Debug.Log("Done!");
            
            Debug.Log(request.downloadHandler.text);

            //デシリアライズ
            var resultMyName = JsonUtility.FromJson<MyName>(request.downloadHandler.text);

            Debug.Log(resultMyName.name);

        }

    }
}
