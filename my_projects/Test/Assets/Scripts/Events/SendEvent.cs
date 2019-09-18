using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendEvent : MonoBehaviour
{
    void OnMouseDown()
    {
        EventManager.TriggerEvent ("Spawn");
    }
}
