using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonedas : MonoBehaviour
{
    [SerializeField] private GameObject prefabCoint;
    [SerializeField] private GameObject[] pisos;
    [SerializeField] private List<GameObject> coints;
    [SerializeField] private float tiempoParaMoneda;
    private GameObject monedas;
    private Vector3 locateIn;
    private float deltaT;
    void Start()
    {
        pisos = GameObject.FindGameObjectsWithTag("Piso");
        deltaT = tiempoParaMoneda;
        monedas = new GameObject(name = "monedas");
    }

    // Update is called once per frame
    void Update()
    {
        deltaT -= Time.deltaTime;
        if (deltaT < 0)
        {
            deltaT = tiempoParaMoneda;

            locateIn = pisos[Random.Range(0, pisos.Length)].transform.position;

            coints.Add(Instantiate(prefabCoint, locateIn + Vector3.up * 2, Quaternion.identity, monedas.transform));
        }
    }
}


