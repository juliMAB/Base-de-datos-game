using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputName;
    [SerializeField] private TMP_InputField inputScore;
    [SerializeField] private Button AddButton;
    [SerializeField] private sqlConnect sql;
    int cant = 5;
    int[] scores = new int[5];
    string[] names = new string[5];

    [SerializeField] private List<TMP_Text> num = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> namesT = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> scoresT = new List<TMP_Text>();

    void Start()
    {
        sql.OnReadEnd += ShowScores;
    }

    public void CallButton()
    {
        sql.CallRegister();
    }
    public void LeerDeLaBase()
    {
        sql.CallLeer();
    }

    public void ShowScores()
    {
        for (int i = 0; i < cant; i++)
        {
            num[i].text = i.ToString();
            string score = GameManager.Get().partes[i + i + 1];
            string names = GameManager.Get().partes[i + i];
            scoresT[i].text = score;
            namesT[i].text = names;
        }
    }
}
