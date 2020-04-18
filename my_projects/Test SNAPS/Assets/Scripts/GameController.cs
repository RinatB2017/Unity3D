using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector3 pos = new Vector3(0, 0, 0);

    void Start()
    {
        int size = 10;
        for(int x=0; x<size; x++)        
        {
            for(int y=0; y<size; y++)        
            {
                for(int z=0; z<size; z++)        
                {
                    pos.x = x;
                    pos.y = y;
                    pos.z = z;

                    Material newMat = Resources.Load("Carpet pattern 02", typeof(Material)) as Material;
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.GetComponent<MeshRenderer>().material = newMat;
                    cube.transform.position = pos;
                }
            }
        }
    }

    void Update()
    {
        
    }
}
