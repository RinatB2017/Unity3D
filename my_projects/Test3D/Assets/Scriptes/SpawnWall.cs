using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject brick_prefab;
    public GameObject platform;

    void Start()
    {
        Vector2 temp_vector;
        temp_vector.y = 1f;
        for(int y=0; y<50; y++)
        {
            for(int cnt=0; cnt<5; cnt++)
            {
                if(y % 2 == 0)
                    temp_vector.x = cnt * 2;
                else
                    temp_vector.x = cnt * 2 + 1;

                GameObject child = Instantiate(brick_prefab, temp_vector, Quaternion.identity);        
                child.GetComponent<Rigidbody>().isKinematic = true;
                child.transform.SetParent(platform.transform);
            }
            temp_vector.y += 1f;
        }
    }

    void Update()
    {
        
    }
}
