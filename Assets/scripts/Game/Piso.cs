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
    public Color c1;
    public Color c2;
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
        mR.material.color = c1;
        bC = GetComponent<BoxCollider>();
        timeT = Random.Range(0, 20);
        actualState = (State)Random.Range(0, 3);
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
                    mR.material.color = c2;
                    mR.material.color =new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, aux);
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
                    mR.material.color = c1;
                    mR.material.color = c1;
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
