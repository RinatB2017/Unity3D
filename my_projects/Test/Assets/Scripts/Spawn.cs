using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Rigidbody2D obj;
    private Vector2 pos;

    void Awake()
    {
        pos = obj.position;
    }

    void OnTriggerExit2D(Collider2D other) 
	{
        obj.MovePosition(pos);
    }
}
