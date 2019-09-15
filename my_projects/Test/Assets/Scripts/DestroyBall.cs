using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : DebugClass
{
    void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
