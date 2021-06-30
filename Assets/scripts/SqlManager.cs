using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqlManager : MonoBehaviour
{
    [SerializeField] private sqlConnect sql = null;

    private void Start()
    {
        sql.CallRegister();
    }
}
