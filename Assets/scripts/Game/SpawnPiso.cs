using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiso : MonoBehaviour
{
    [SerializeField] private GameObject spawnBox;
    [SerializeField] private GameObject piso;
    [SerializeField] private int maxLarge;
    [SerializeField] private int maxHigh;

    void OnValidate()
    {
        if (maxLarge<0)
        {
            maxLarge = 1;
        }

        if (maxHigh < 0)
        {
            maxHigh = 1;
        }
    }
    void Start()
    {
        GameObject papa = new GameObject {name = "Pisos"};
        for (int i = 0; i < maxHigh; i++)
        {
            for (int j = 0; j < maxLarge; j++)
            {
                GameObject go = Instantiate(piso);
                go.transform.localScale = new Vector3(spawnBox.transform.localScale.x / maxLarge,
                    spawnBox.transform.localScale.y, spawnBox.transform.localScale.z / maxHigh);
                go.transform.position += new Vector3(
                    spawnBox.transform.position.x - (spawnBox.transform.localScale.x / 2) + (go.transform.localScale.x * j) + go.transform.localScale.x / 2,
                    spawnBox.transform.position.y, -(spawnBox.transform.localScale.z / 2) + (go.transform.localScale.z * i) + go.transform.localScale.z / 2);
                go.name = "piso " + (j + (i * maxLarge));
                go.tag = "Piso";
                go.transform.parent = papa.transform;
            }
        }
        Destroy(spawnBox);
    }
}