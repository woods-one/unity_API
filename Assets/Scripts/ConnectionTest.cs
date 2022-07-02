using System.Collections;
using UnityEngine;

public class ConnectionTest : MonoBehaviour {

    string[] url =
    {
        "https://cdn.discordapp.com/attachments/985243321167384626/992094571523743894/IMG20220521150810.jpg",
        "https://cdn.discordapp.com/attachments/985243321167384626/992094386039046194/438.png",
        "https://pbs.twimg.com/profile_images/1509986410396516352/lY-85W7c_400x400.jpg"
    };
    
    [SerializeField]
    private int index;
    
    [SerializeField]
    private Renderer renderer;

    void Start () {
        StartCoroutine (Connect ());
    }

    private IEnumerator Connect()
    {
        var www = new WWW(url[index]);
        yield return  www;
        renderer.material.mainTexture = www.texture;
    }
}