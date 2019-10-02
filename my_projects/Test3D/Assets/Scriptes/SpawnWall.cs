using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWall : MonoBehaviour
{
    public GameObject brick_prefab;
    public GameObject platform;
    public GameObject container;

    void test()
    {
        Vector3 temp_vector;
        temp_vector.x = 12.5f;
        temp_vector.y = 6.5f;
        temp_vector.z = 17.5f;

        GameObject child = Instantiate(brick_prefab, temp_vector, Quaternion.identity);
    }

    void Start()
    {
        Vector3 pos_platform = platform.transform.position;

        Vector3 temp_vector;
        temp_vector.x = pos_platform.x;
        temp_vector.y = pos_platform.y + 1f;
        temp_vector.z = pos_platform.z;

        int cnt = 0;
        for(int y=0; y<5; y++)
        {
            for(int x=0; x<5; x++)
            {
                if(y % 2 == 0)
                    temp_vector.x = pos_platform.x + x * 2;
                else
                    temp_vector.x = pos_platform.x + x * 2 + 1;

                // GameObject child = Instantiate(brick_prefab, temp_vector, Quaternion.identity);
                GameObject child = Instantiate(brick_prefab, temp_vector, Quaternion.identity, container.transform);
                // child.GetComponent<Rigidbody>().isKinematic = true;
                // child.transform.SetParent(container.transform);
                // проблема - наследуется и масштаб, в результате глюки
                cnt++;
            }
            temp_vector.y += 1f;
        }
        print("Cnt " + cnt);
    }

    void Update()
    {
        
    }
}
