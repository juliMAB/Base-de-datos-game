using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class sqlConnect : MonoBehaviour
{

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", GameManager.Get().playerName);
        form.AddField("Score", GameManager.Get().playerScore.ToString());

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Monedas/register.php", form);

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
    }
    IEnumerator Leer()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", GameManager.Get().playerName);
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Monedas/register.php", form);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            string textOringinal = www.downloadHandler.text;
            string[] partes = textOringinal.Split('\t');
            GameManager.Get().playerName = partes[0];
            GameManager.Get().playerScore = int.Parse(partes[1]);
            Debug.Log(GameManager.Get().playerName + " , " + GameManager.Get().playerScore);
            Debug.Log(www.downloadHandler.text);
        }
    }
}
