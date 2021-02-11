using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace rav3d
{
    public class NetworkController : MonoBehaviour
    {
        public string auth = "BMeHG5xqJeB4qCjpuJCTQLsqNGaqkfB6";
        public string RpcUrl = "https://dev3r02.elysium.today/inventory/status";


        public void SendEvent(Dictionary<string, string> itemData)
        {
            StartCoroutine(SendData(itemData));
        }

        private IEnumerator SendData(Dictionary<string, string> data)
        {
            
            using (var www = UnityWebRequest.Post(RpcUrl, data))
            {
                www.method = UnityWebRequest.kHttpVerbPOST;
                www.SetRequestHeader("auth", auth);
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                    // Debug.Log(www.GetResponseHeaders());
                    yield break;
                }

                Debug.Log("Server batch sent");
                var result = www.downloadHandler.data;
                Debug.Log(Encoding.UTF8.GetString(result));
            }
        }
    }
}