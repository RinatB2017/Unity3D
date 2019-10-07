using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTime : MonoBehaviour
{
    public GameObject prefab;

    private float begin_time = 0f;
    private float end_time = 0f;
    private float elapsed_time = 0f;

    void Start()
    {
        Vector3 temp_vector = new Vector3(0, 0, 0);

        begin_time = Time.realtimeSinceStartup; //Time.time;
        for(int n=0; n<10000; n++)
        {
            GameObject clone = Instantiate(prefab, temp_vector, Quaternion.identity);
            clone.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        end_time = Time.realtimeSinceStartup;   //Time.time;
        elapsed_time = end_time - begin_time;

        print("elapsed_time " + elapsed_time);
    }
}
