using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Piso : MonoBehaviour
{
    private float aux;
    private float timeT;
    private MeshRenderer mR;
    private BoxCollider bC;
    [Range(2.0f, 6.0f)]
    public float timeToLife;
    [Range(2.0f, 6.0f)]
    public float timeToRespawn;
    public enum State
    {
        iddle,
        Muriendo,
        Respawneando,
        last
    }

    private State actualState;

    void Start()
    {
        mR = GetComponent<MeshRenderer>();
        mR.material.color = Color.green;
        bC = GetComponent<BoxCollider>();
        timeT = Random.Range(0, 20);
        actualState = (State)Random.Range(0, 2);
        if (actualState==State.Respawneando)
        {
            mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, 0);
        }
    }
    
    void Update()
    {
        switch (actualState)
        {
            case State.Muriendo:
                timeT -= Time.deltaTime;
                aux = timeT / timeToLife;
                mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, aux);
                
                if (timeT <= 0)
                {
                    actualState = State.Respawneando;
                    timeT = timeToRespawn;
                    mR.material.color = Color.red;
                    mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, 0);
                    bC.enabled = false;
                }
                break;
            case State.Respawneando:
                timeT -= Time.deltaTime;
                aux = (((timeT / timeToLife)*-1) +1);
                if (aux<0)
                {
                    aux = 0;
                }
                mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, aux);
                if (timeT < 0)
                {
                    mR.material.color = Color.green;
                    mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, 1);
                    actualState = State.Muriendo;
                    timeT = timeToLife;
                    bC.enabled = true;
                }
                break;
            default:
                break;
        }

    }
}
