using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : DebugClass
{
    public float thrust;
    public Rigidbody2D rb;

    private bool flag = true;

    private Vector3 old_position;
    private Vector3 new_position;

    void check_vectors()
    {
        old_position = new Vector3(0, 0, 0);
        new_position = new Vector3(0, 0, 1);

        if(old_position != new_position)
        {
            print("No");
        }
    }
    
    void Start()
    {
        debug_print("Test started!");
    }

    void Update()
    {
        if(flag)
        {
            Vector3 force = new Vector3(50f, 50f, 0);
            rb.AddForce(force);
            //rb.AddForce(transform.right * thrust);
            flag = false;
        }
        if(rb.transform.position.y > 5)
        {
            flag = true;
            if(flag)
            {
                Vector3 force = new Vector3(50f, -50f, 0);
                rb.AddForce(force);
                flag = false;
            }
        }
    }
}
