using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : DebugClass
{
    void OnCollisionEnter2D(Collision2D col)
    {
        debug_print("OnCollisionEnter2D");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        debug_print("OnTriggerEnter2D");
    }
}
