using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        print("OnCollisionEnter2D");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("OnTriggerEnter2D");
    }
}
