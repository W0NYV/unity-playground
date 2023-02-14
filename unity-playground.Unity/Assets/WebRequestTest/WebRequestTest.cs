using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace W0NYV.WebRequestTest
{
    public class WebRequestTest : MonoBehaviour
    {

        [SerializeField] string _uri;

        async void Start()
        {

            var request = UnityWebRequestTexture.GetTexture(_uri);
            await request.SendWebRequest();

            var texture =  DownloadHandlerTexture.GetContent(request);

            gameObject.GetComponent<Renderer>().material.mainTexture = texture;
        }

    }
}
