using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    public  float time_kill = 1.5f;
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= time_kill)
        {
            Destroy(gameObject);
        }
    }
}
