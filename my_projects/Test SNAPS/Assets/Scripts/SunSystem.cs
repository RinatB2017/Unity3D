using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSystem : MonoBehaviour
{
    public GameObject[] planets;
    public Vector3[] vectors;
    public float speed = 30;

    private Vector3 target = new Vector3(0, 0, 0);

    void Start()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Vector3 pos = new Vector3(3, 3, 3);

        Material newMat = Resources.Load("Carpet pattern 02", typeof(Material)) as Material;
        sphere.GetComponent<MeshRenderer>().material = newMat;

        sphere.transform.position = pos;
    }

    void Update()
    {
        for(int n=0; n<planets.Length; n++)
        {
            planets[n].transform.RotateAround(
                target, 
                // Vector3.up, 
                vectors[n],
                speed * Time.deltaTime + 1.0f/((float)n + 1) 
                );
        }
    }
}
