using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{
    [SerializeField] float Maxtime= 2*60;
    [SerializeField] PlayerController player;

    private void Update()
    {
        Maxtime -= Time.deltaTime;
        if (Maxtime<0)
        {
            player.vidasGet = -1;
        }
    }
}
