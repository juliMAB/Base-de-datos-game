using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    private float deltaT = 1;
    [SerializeField] private float tiempoAmarilo;
    [SerializeField] private float tiempoRojo;
    private Material material;
    public enum color
    {
        Amarillo,
        Rojo,
    }

    public color estado;
    // Start is called before the first frame update
    void Start()
    {
        estado = color.Amarillo;
        material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
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