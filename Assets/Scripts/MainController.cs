using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class MainController : MonoBehaviour {

    //接続するURL
    private const string URL = "http://localhost:5000/";

    public void OnClicked()
    {
        //コルーチンを呼び出す
        StartCoroutine("OnSend", URL);
    }

    IEnumerator OnSend(string url)
    {
        //指定したURLでGET
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();
        
        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
        }
        else
        {
            //通信成功
            Debug.Log("Get" + " : "+webRequest.downloadHandler.text);
        }
    }
}