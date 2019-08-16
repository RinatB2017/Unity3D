using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float thrust;
    public Rigidbody2D rb;

    private bool flag = true;

    private Vector3 old_position;
    private Vector3 new_position;
    
    void Start()
    {
        print("Test started!");

        old_position = new Vector3(0, 0, 0);
        new_position = new Vector3(0, 0, 1);

        if(old_position != new_position)
        {
            print("No");
        }
    }

    void Update()
    {
        if(flag)
        {
            rb.AddForce(transform.right * thrust);
            flag = false;
        }
    }
}
