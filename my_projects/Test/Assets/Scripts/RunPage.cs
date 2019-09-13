using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPage : MonoBehaviour
{
    public GameObject page;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 pos = page.transform.position;
            GameObject obj = Instantiate(page, pos, Quaternion.identity);

            Destroy(gameObject);
        }        
    }
}
