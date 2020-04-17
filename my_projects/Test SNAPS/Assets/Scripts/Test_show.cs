using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_show : MonoBehaviour
{
    public GameObject go;
    public GameObject planet;
    public float speed = 30;

    public Vector3 target;

    void Start()
    {
        
    }

    void Update()
    {
        go.transform.RotateAround(target, Vector3.up, speed * Time.deltaTime);
        planet.transform.RotateAround(target, Vector3.up, -speed * Time.deltaTime);
    }
}
