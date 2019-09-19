using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEvent : MonoBehaviour
{
    private int x = 0;

    void Awake()
    {
        print("child is " + transform.childCount);  // кол-во дочерних объектов
    }

    void OnEnable()
    {
        print("OnEnable");
    }
    void OnDisable()
    {
        print("OnDisable");
    }

    void OnMouseDown()
    {
        string text = "Cnt = " + x++;

        // transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(transform.up * 100.0f);
        transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));

        EventManager.SendEvent ("MyEvent", text);
    }
}
