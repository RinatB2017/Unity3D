using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : DebugClass
{
    public Rigidbody2D obj;

    void rotate()
    {
        // debug_print("rotate");
        // obj.rotation = 45f;
        obj.rotation += 1f;
    }
}
