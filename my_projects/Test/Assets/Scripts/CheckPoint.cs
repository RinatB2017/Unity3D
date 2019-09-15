using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : DebugClass
{
    public GameObject obj;
    public string f_name;

    void OnCollisionEnter2D(Collision2D col)
    {
        obj.SendMessage(f_name);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        obj.SendMessage(f_name);
    }
}
