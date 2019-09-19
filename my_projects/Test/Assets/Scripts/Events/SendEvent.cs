using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEvent : MonoBehaviour
{
    private int x = 0;

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

        EventManager.SendEvent ("MyEvent", text);
    }
}
