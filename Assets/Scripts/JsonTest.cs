using System.Collections;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;

public class JsonTest : MonoBehaviour {

    [SerializeField]
    private UserData userData = new UserData();
    
    [SerializeField]
    private ReceieveUserInfoData receiveUserInfoData = new ReceieveUserInfoData();
    
    [SerializeField]
    private string jsonName;
    
    private string url = "http://[::]:8000";
    

    IEnumerator Start () {
        string jsondata = JsonMapper.ToJson (userData);
        WWWForm form = new WWWForm ();
        form.AddField ("jsondata", jsondata);
        var www = new WWW (url, form);
        yield return www;
        receiveUserInfoData = JsonMapper.ToObject<ReceieveUserInfoData> (www.text);

        UnityWebRequest webRequest = UnityWebRequest.Get(url+ "/" + jsonName);
        //URLに接続して結果が戻ってくるまで待機
        yield return webRequest.SendWebRequest();

        Debug.Log("Get" + " : " + webRequest.downloadHandler.text);
    }
    
    void Update () {
        print (receiveUserInfoData.name);
    }
}