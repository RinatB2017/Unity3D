using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public GameObject l_prefab;
    public GameObject r_prefab;

    void Start()
    {
        float xAngle = 0f;
        float yAngle = 45f;
        float zAngle = 0f;

        l_prefab.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        r_prefab.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }

    void Update()
    {
        
    }
}
