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
    [SerializeField] private float timeToLife;
    [Range(2.0f, 6.0f)]
    [SerializeField] private float timeToRespawn;
    [Range(2.0f, 6.0f)]
    [SerializeField] private float dying;
    [Range(2.0f, 6.0f)]
    [SerializeField] private float timeDie;
    [SerializeField] private Color c1;
    [SerializeField] private Color c2;
    [SerializeField]
    private enum State
    {
        iddle,
        Muriendo,
        Muerto,
        Respawneando,

        last
    }

    [SerializeField] private State actualState;

    void Start()
    {
        mR = GetComponent<MeshRenderer>();
        mR.material.color = c1;
        bC = GetComponent<BoxCollider>();
        timeT = Random.Range(0, 20);
        actualState = State.iddle;
    }
    
    void Update()
    {
        switch (actualState)
        {
            case State.iddle:
                timeT -= Time.deltaTime;
                if (timeT > 0)
                    return;
                actualState++;
                timeT = dying;

                break;
            case State.Muriendo:
                timeT -= Time.deltaTime;
                aux = timeT / dying;
                mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, aux);

                if (timeT > 0)
                    return;
                actualState++;
                timeT = timeDie;
                mR.material.color = c2;
                mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, 0);
                bC.enabled = false;
                break;
            case State.Muerto:
                timeT -= Time.deltaTime;
                if (timeT > 0)
                    return;
                actualState++;
                timeT = timeToRespawn;

                break;
            case State.Respawneando:
                timeT -= Time.deltaTime;
                aux = ((timeT / timeToLife)-1)*-0.999f;
                print(aux);
                mR.material.color = new Color(mR.material.color.r, mR.material.color.g, mR.material.color.b, aux);

                if (timeT > 0)
                    return;
                    mR.material.color = c1;
                    actualState++ ;
                    timeT = timeToLife;
                    bC.enabled = true;
                
                break;
            case State.last:
                actualState=0;
                break;
            default:
                break;
        }

    }
}
