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

        Material newMat = Resources.Load("/Yughues Fabric Materials/Carpet 01/Carpet pattern 01", typeof(Material)) as Material;
        // Material newMat = Resources.Load<Material>("Yughues Fabric Materials/Carpet 01/Carpet pattern 01");
        sphere.GetComponent<MeshRenderer>().material = newMat;

        // sphere.GetComponent<MeshRenderer>().material.color = Color.blue; // .GetTexture("Assets/Yughues Fabric Materials/Carpet 01/Carpet pattern 01.mat");
        // sphere.GetComponent<MeshRenderer>().material.GetTexture("Carpet pattern 01");
        // meshRenderer.material.GetTexture("_MainTex")

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
