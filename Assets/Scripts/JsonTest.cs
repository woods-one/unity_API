using System.Collections;
using UnityEngine;
using LitJson;

public class JsonTest : MonoBehaviour {

    [SerializeField]
    private UserData userData = new UserData();
    
    [SerializeField]
    private ReceieveUserInfoData receiveUserInfoData = new ReceieveUserInfoData();
    
    [SerializeField]
    private string url = "https://unity-api-falcon.herokuapp.com/api/users";

    IEnumerator Start () {
        string jsondata = JsonMapper.ToJson (userData);
        print (jsondata);
        WWWForm form = new WWWForm ();
        form.AddField ("jsondata", jsondata);
        var www = new WWW (url, form);
        yield return www;
        print (www.text);
        receiveUserInfoData = JsonMapper.ToObject<ReceieveUserInfoData> (www.text);
    }
    
    void Update () {
        print (receiveUserInfoData.name);
    }
}