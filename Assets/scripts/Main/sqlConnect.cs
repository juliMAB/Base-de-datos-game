using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class sqlConnect : MonoBehaviour
{
    public Action OnReadEnd;
    public void CallRegister()
    {
        StartCoroutine(Register());
    }
    public void CallRegister(string name, int score)
    {
        StartCoroutine(Register(name, score));
    }
    public void CallLeer()
    {
        StartCoroutine (Leer());
    }
    IEnumerator Register(string name, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", name);
        form.AddField("Score", score);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Monedas/register.php", form);

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username", GameManager.Get().playerName);
        form.AddField("Score", GameManager.Get().playerScore);

        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Monedas/register.php", form);

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);
    }
    IEnumerator Leer()
    {
        WWWForm form = new WWWForm();
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/Monedas/LeerPorScore.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.result);
        if (www.result == UnityWebRequest.Result.Success)
        {
            string textOringinal = www.downloadHandler.text;
           var partes = textOringinal.Split('\t');
            GameManager.Get().partes = partes;
            OnReadEnd?.Invoke();
            Debug.Log(www.downloadHandler.text);

        }
        Debug.Log(www.downloadHandler.text);
    }
}
    
