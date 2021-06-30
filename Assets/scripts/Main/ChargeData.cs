using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeData : MonoBehaviour
{



    [Header("Display Script Reference")]
    [Tooltip("a reference to the sqlConect script on a gameObject in the scene somewhere.")]
    private sqlConnect SqlConnectScript;

    void Start()
    {

        SqlConnectScript = GetComponent<sqlConnect>();
        //SqlConnectScript.CallRegister();
    }

}

