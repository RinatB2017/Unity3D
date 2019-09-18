using UnityEngine;
using System.Collections;

public class EventTriggerTest : MonoBehaviour 
{
    void Update () 
    {
        if (Input.GetKeyDown ("q"))
        {
            print("q");
            EventManager.TriggerEvent ("test");
        }

        if (Input.GetKeyDown ("o"))
        {
            print("o");
            EventManager.TriggerEvent ("Spawn");
        }

        if (Input.GetKeyDown ("p"))
        {
            print("p");
            EventManager.TriggerEvent ("Destroy");
        }

        if (Input.GetKeyDown ("x"))
        {
            print("x");
            EventManager.TriggerEvent ("Junk");
        }
    }
}
