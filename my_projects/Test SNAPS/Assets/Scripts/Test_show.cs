using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_show : MonoBehaviour
{
    public float angle = .0f;
    public float angle_delta = 1.0f;
    public float radius = 5.0f;

    public GameObject go;

    void Start()
    {
        
    }

    void Update()
    {
        if(angle >= 360)
        {
            angle = 0;
        }
        else
        {
            angle += angle_delta;
        }

        Vector3 pos;
        // pos.x = radius * Mathf.Sin(angle * Mathf.PI / 180.0f);
        pos.x = radius * Mathf.Cos(angle * Mathf.PI / 180.0f);
        pos.y = 0;
        // pos.z = radius * Mathf.Cos(angle * Mathf.PI / 180.0f);
        pos.z = radius * Mathf.Sin(angle * Mathf.PI / 180.0f);

        go.transform.position = pos;
        go.transform.Rotate(0, angle_delta, 0, Space.Self);
    }
}
