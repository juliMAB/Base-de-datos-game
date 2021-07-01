using System;
using System.Collections;
using System.Collections.Generic;
using MonoBehaviourSingletonScript;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{

    public string playerName;

    public int playerScore;

    public string[] partes;

    public PlayerController pj;

    public void GetPlayer()
    {
        pj.playerSaveAction += UpdateScore;
    }

    public void UpdateScore()
    {
        playerScore = pj.scoreGet;
        print("Se guardo el score en el GM");
    }

}
