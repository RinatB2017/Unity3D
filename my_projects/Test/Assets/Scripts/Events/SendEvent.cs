using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEvent : MonoBehaviour
{
    void OnMouseDown()
    {
        float x = 1f / 3f;
        string text = "X = " + x;

        EventManager.SendEvent ("MyEvent", text);
    }
}
