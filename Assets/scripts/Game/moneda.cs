using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    private float deltaT = 1;
    private Material material;

    [SerializeField] private float tiempoAmarilo;
    [SerializeField] private float tiempoRojo;
   
    
    //es publico para que el player pueda saber que agarro una.
    public enum color
    {
        Amarillo,
        Rojo,
    }

    public color estado;
   
    void Start()
    {
        estado = color.Amarillo;
        material = GetComponent<MeshRenderer>().material;
    }

    void Update()
    {
        deltaT -= Time.deltaTime;
        if (deltaT < 0)
        {
            
            switch (estado)
            {
                case color.Amarillo:
                    estado = color.Rojo;
                    material.color = Color.red;
                    deltaT = tiempoRojo;
                    break;
                case color.Rojo:
                    estado = color.Amarillo;
                    material.color = Color.yellow;
                    deltaT = tiempoAmarilo;
                    break;
            }
        }
    }
}