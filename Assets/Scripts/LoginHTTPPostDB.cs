using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class LoginHTTPPostDB : MonoBehaviour
{
    [SerializeField, Header("LogText")]
    Text m_logText;

    [SerializeField, Header("IDInputField")]
    InputField m_idInputField;

    [SerializeField, Header("PassInputField")]
    InputField m_passInputField;
    
    private const string RegistrationURL = "http://localhost:5000/login";
    
    public void Login()
    {
        StartCoroutine(LoginCoroutine(RegistrationURL));
    }
    
    IEnumerator LoginCoroutine(string url)
    {
        //POSTする情報
        WWWForm form = new WWWForm();
        form.AddField("user_id", m_idInputField.text, Encoding.UTF8);
        form.AddField("password", m_passInputField.text, Encoding.UTF8);

        //URLをPOSTで用意
        UnityWebRequest webRequest = UnityWebRequest.Post(url, form);
        //UnityWebRequestにバッファをセット
        webRequest.downloadHandler = new DownloadHandlerBuffer();
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        //エラーが出ていないかチェック
        if (webRequest.isNetworkError)
        {
            //通信失敗
            Debug.Log(webRequest.error);
            m_logText.text = "通信エラー";
        }
        else
        {
            //通信成功
            Debug.Log("Post"+" : "+webRequest.downloadHandler.text);
            m_logText.text = webRequest.downloadHandler.text;
        }
    }
}
