using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inputs : MonoBehaviour
{
    [SerializeField] private InputField inputName;
    [SerializeField] private Button playButton;
    void Update()
    {
        if (inputName.text=="")
        {
            playButton.gameObject.SetActive(false);
        }
        else
        {
            playButton.gameObject.SetActive(true);
        }
    }
    public void CallButton()
    {
        GameManager.Get().playerName = inputName.text;
    }
}
