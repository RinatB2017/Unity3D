using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : DebugClass
{
    public Transform prefab;

    void Start()
    {
        for(int y=-5; y<5; y++)
        {
            for(int x=-8; x<=8; x++)
            {
                Vector3 temp_vector = new Vector3(x, y, 0);
                Instantiate(prefab, temp_vector, Quaternion.identity);
            }
        }
    }

    void Update()
    {
        
    }
}
