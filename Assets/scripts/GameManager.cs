using System.Collections;
using System.Collections.Generic;
using MonoBehaviourSingletonScript;
using UnityEditor.SearchService;
using UnityEngine;

public class GameManager : MonoBehaviourSingleton<GameManager>
{

    public string playerName;

    public float playerScore;

    private PlayerController pj;

    public void GetPlayer()
    {
        pj = FindObjectOfType<PlayerController>();
        pj.playerSaveAction += UpdateScore;
    }


    void UpdateScore()
    {
        playerScore = pj.scoreGet;
        print("Se guardo el score en el GM");
    }
}
