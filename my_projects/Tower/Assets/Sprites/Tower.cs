using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform prefab;

    void Start()
    {
        for(float z=0.5f; z<3.5f; z+=1.0f)
        {
            for(float y=0.5f; y<5.5f; y+=1.0f)
            {
                for(float x=0.5f; x<3.5f; x+=1.0f)
                {
                    Vector3 temp_vector = new Vector3(x, y, z);
                    Instantiate(prefab, temp_vector, Quaternion.identity);
                }
            }
        }
        // Vector3 temp_vector = new Vector3(1, 0.5f, 1);
        // Instantiate(prefab, temp_vector, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
