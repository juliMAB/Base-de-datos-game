using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public PlayerController pj;
    public Text vidasText;
    public Text puntosText;
    public Text saltarText;

    void Awake()
    {
        pj.playerChangeAction += UpdateUI;
    }
    void UpdateUI()
    {
        vidasText.text = "Vidas: " + pj.vidasGet.ToString();
        puntosText.text = "Puntos: " + pj.scoreGet.ToString();
        saltarText.text = pj.saltarGet ? "Saltar: Si" : "Saltar: No";
        
    }


}
